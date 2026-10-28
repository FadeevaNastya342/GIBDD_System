using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Data.SQLite;
using GIBDD_System.Models;

namespace GIBDD_System
{
    public partial class UnprocessedFinesForm : Form
    {
        private List<FineDto> _loadedFines = new List<FineDto>();

        private readonly string _allowedPlateLetters = "АВЕКМНОРСТУХ";

        public UnprocessedFinesForm()
        {
            InitializeComponent();
            ApplyStyles();

            dgvFines.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFines.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFines.ReadOnly = false;

            backgroundWorker1.DoWork += BackgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += BackgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;
        }

        private void ApplyStyles()
        {
            this.Font = new Font("Microsoft Sans Serif", 10F);
            lblTitle.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;

            btnLoad.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular);
            btnSave.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular);

            lblStatus.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Italic);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (!backgroundWorker1.IsBusy)
                {
                    // Сброс интерфейса
                    btnLoad.Enabled = false;
                    btnSave.Enabled = false;
                    progressBar1.Value = 0;
                    lblStatus.Text = "Инициализация загрузки...";
                    dgvFines.DataSource = null;
                    _loadedFines.Clear();

                    // Проверка наличия файла перед запуском (для отладки)
                    string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "fines_test.json");
                    if (!File.Exists(jsonPath))
                    {
                        MessageBox.Show($"Файл не найден по пути:\n{jsonPath}\n\nПожалуйста, убедитесь, что файл fines_test.json скопирован в папку программы.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnLoad.Enabled = true;
                        return;
                    }

                    lblStatus.Text = "Запуск процесса загрузки...";

                    // ЗАПУСК ФОНОВОГО ПРОЦЕССА
                    backgroundWorker1.RunWorkerAsync();
                }
                else
                {
                    MessageBox.Show("Загрузка уже выполняется!", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Критическая ошибка при запуске:\n{ex.Message}\n\n{ex.StackTrace}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnLoad.Enabled = true;
            }
        }

        private void BackgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "fines_test.json");

                if (!File.Exists(jsonPath))
                {
                    throw new FileNotFoundException("Файл fines_test.json не найден в папке программы!");
                }

                string jsonContent = File.ReadAllText(jsonPath);

                Thread.Sleep(1000);
                backgroundWorker1.ReportProgress(20, "Обработка JSON данных...");

                _loadedFines = JsonConvert.DeserializeObject<List<FineDto>>(jsonContent);

                if (_loadedFines == null)
                {
                    throw new Exception("Не удалось десериализовать данные JSON.");
                }

                int count = _loadedFines.Count;
                for (int i = 0; i < count; i++)
                {
                    FineDto fine = _loadedFines[i];

                    if (!string.IsNullOrWhiteSpace(fine.CarPlate))
                    {
                        fine.CarPlate = NormalizePlate(fine.CarPlate);
                    }

                    Thread.Sleep(150);
                    int percent = 20 + ((i + 1) * 70 / count);
                    backgroundWorker1.ReportProgress(percent, $"Загружено штрафов: {i + 1} из {count}");
                }

                e.Result = true;
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        private void BackgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lblStatus.Text = e.UserState.ToString();
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            btnLoad.Enabled = true;

            if (e.Error != null)
            {
                MessageBox.Show($"Ошибка: {e.Error.Message}", "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Ошибка загрузки";
                return;
            }

            if (e.Result is bool success && success)
            {
                lblStatus.Text = "Загрузка завершена! Проверьте данные (особенно пустые номера).";
                btnSave.Enabled = true;

                dgvFines.DataSource = null;
                dgvFines.DataSource = _loadedFines;

                SetupGridColumns();

                ColorEvenOddRows();

                MessageBox.Show($"Успешно загружено штрафов: {_loadedFines.Count}", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SetupGridColumns()
        {
            if (dgvFines.Columns["CarPlate"] != null)
            {
                dgvFines.Columns["CarPlate"].HeaderText = "Госномер РФ (ред.)";
                dgvFines.Columns["CarPlate"].Width = 100;
            }
            if (dgvFines.Columns["LicenseNumber"] != null)
            {
                dgvFines.Columns["LicenseNumber"].HeaderText = "Номер ВУ";
                dgvFines.Columns["LicenseNumber"].Width = 100;
            }
            if (dgvFines.Columns["Amount"] != null)
            {
                dgvFines.Columns["Amount"].HeaderText = "Сумма (₽)";
                dgvFines.Columns["Amount"].DefaultCellStyle.Format = "N2";
            }
            if (dgvFines.Columns["ViolationDate"] != null)
            {
                dgvFines.Columns["ViolationDate"].HeaderText = "Дата нарушения";
                dgvFines.Columns["ViolationDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
            }
            if (dgvFines.Columns["ViolationType"] != null)
            {
                dgvFines.Columns["ViolationType"].HeaderText = "Тип нарушения";
            }

            foreach (DataGridViewColumn col in dgvFines.Columns)
            {
                if (col.Name == "Id" || col.Name == "PhotoUrl" || col.Name == "Status")
                    col.Visible = false;
            }
        }

        private void ColorEvenOddRows()
        {
            foreach (DataGridViewRow row in dgvFines.Rows)
            {
                if (row.Index % 2 == 0)
                    row.DefaultCellStyle.BackColor = Color.White;
                else
                    row.DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);

                if (string.IsNullOrWhiteSpace(row.Cells["CarPlate"].Value?.ToString()) &&
                    string.IsNullOrWhiteSpace(row.Cells["LicenseNumber"].Value?.ToString()))
                {
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                    row.DefaultCellStyle.Font = new Font(dgvFines.Font, FontStyle.Bold);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_loadedFines == null || _loadedFines.Count == 0) return;

            int savedCount = 0;
            int notFoundCount = 0;
            int manualInputCount = 0;

            using (SQLiteConnection conn = new SQLiteConnection(DatabaseHelper.ConnectionString))
            {
                conn.Open();

                foreach (FineDto fine in _loadedFines)
                {

                    string driverId = FindDriverId(conn, fine.CarPlate, fine.LicenseNumber);

                    if (driverId != null)
                    {
                        SaveFineToDb(conn, fine, driverId);
                        savedCount++;
                    }
                    else
                    {
                        notFoundCount++;
                        manualInputCount++;
                    }
                }
            }

            string msg = $"Сохранено штрафов: {savedCount}.\n\nНе найдено владельцев: {notFoundCount}.";
            if (notFoundCount > 0)
            {
                msg += "\n\nВнимание: Штрафы без распознанного номера требуют ручной проверки фото и ввода данных оператором.";
            }

            MessageBox.Show(msg, "Результат импорта", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private string NormalizePlate(string plate)
        {
            if (string.IsNullOrWhiteSpace(plate)) return "";
            return plate.Trim().ToUpper();
        }

        private bool IsValidRusPlate(string plate)
        {
            if (string.IsNullOrWhiteSpace(plate)) return false;

            string letters = new string(plate.Where(char.IsLetter).ToArray());
            string digits = new string(plate.Where(char.IsDigit).ToArray());

            if (letters.Length < 3 || digits.Length < 3) return false;

            foreach (char c in letters.Take(3))
            {
                if (!_allowedPlateLetters.Contains(c)) return false;
            }
            return true;
        }

        private string FindDriverId(SQLiteConnection conn, string plate, string licenseNum)
        {
            if (!string.IsNullOrWhiteSpace(licenseNum))
            {
                string sql = "SELECT Id FROM Drivers WHERE LicenseNumber = @lic LIMIT 1";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@lic", licenseNum.Replace(" ", ""));
                    object res = cmd.ExecuteScalar();
                    if (res != null) return res.ToString();
                }
            }

            return null;
        }

        private void SaveFineToDb(SQLiteConnection conn, FineDto fine, string driverId)
        {
            string sql = @"INSERT OR REPLACE INTO Fines (Id, DriverId, CarPlate, Amount, ViolationDate, ViolationType, IsPaid)
                           VALUES (@id, @did, @plate, @amt, @date, @type, 0)";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", fine.Id);
                cmd.Parameters.AddWithValue("@did", driverId);
                cmd.Parameters.AddWithValue("@plate", string.IsNullOrWhiteSpace(fine.CarPlate) ? (object)DBNull.Value : fine.CarPlate);
                cmd.Parameters.AddWithValue("@amt", fine.Amount);
                cmd.Parameters.AddWithValue("@date", fine.ViolationDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@type", fine.ViolationType);

                cmd.ExecuteNonQuery();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}