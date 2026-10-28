using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GIBDD_System
{
    public partial class DriverForm : Form
    {
        public string DriverIdToEdit { get; set; } = null;

        public DriverForm()
        {
            InitializeComponent();
            SetupCityAutoComplete();
        }

        private void btnSelectPhoto_Click(object sender, EventArgs e)
        {
            if (ofdPhoto.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofdPhoto.FileName;

                FileInfo fileInfo = new FileInfo(filePath);
                if (fileInfo.Length > 2 * 1024 * 1024)
                {
                    MessageBox.Show("Размер фотографии не должен превышать 2 МБ.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    using (System.Drawing.Image img = System.Drawing.Image.FromFile(filePath))
                    {
                        string ext = System.IO.Path.GetExtension(filePath).ToLower();
                        if (ext != ".jpg" && ext != ".jpeg" && ext != ".png")
                        {
                            MessageBox.Show("Допустимы только форматы JPG и PNG.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        double aspectRatio = (double)img.Width / img.Height;
                        if (aspectRatio < 0.70 || aspectRatio > 0.80)
                        {
                            MessageBox.Show($"Соотношение сторон должно быть 3x4.\nТекущее: {img.Width}x{img.Height}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        pbPhoto.Image = System.Drawing.Image.FromFile(filePath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось загрузить изображение: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Проверка обязательных полей
            if (string.IsNullOrWhiteSpace(txtLastName.Text) || string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Фамилия и Имя обязательны!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string dbPath = "gibdd.db";
                string newId = Guid.NewGuid().ToString();

                // SQL запрос (15 колонок)
                string sql = @"INSERT INTO Drivers 
              (Id, LastName, FirstName, Patronymic, 
               PassportSeries, PassportNumber, 
               RegCity, RegAddressFull, 
               LiveCity, LiveAddressFull, 
               Workplace, Position, Phone, Email, Notes) 
              VALUES 
              (@id, @last, @first, @patr, 
               @pSeries, @pNumber, 
               @rCity, @rAddr, 
               @lCity, @lAddr, 
               @work, @pos, @phone, @email, @notes)";

                using (System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection($"Data Source={dbPath};Version=3;"))
                {
                    conn.Open();

                    using (System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand(sql, conn))
                    {
                        // Основные данные
                        cmd.Parameters.AddWithValue("@id", newId);
                        cmd.Parameters.AddWithValue("@last", txtLastName.Text.Trim());
                        cmd.Parameters.AddWithValue("@first", txtFirstName.Text.Trim());
                        cmd.Parameters.AddWithValue("@patr", txtPatronymic.Text.Trim());

                        // Паспорт (ИСПРАВЛЕНО: теперь берем из разных полей)
                        // Убедитесь, что у вас есть поля txtPassportSeries и txtPassportNumber!
                        // Если у вас одно общее поле, разделите строку или используйте одно значение.
                        cmd.Parameters.AddWithValue("@pSeries", txtPassport.Text.Trim());
                        cmd.Parameters.AddWithValue("@pNumber", txtPassport.Text.Trim());

                        // Адреса
                        cmd.Parameters.AddWithValue("@rCity", txtRegCity.Text.Trim());
                        cmd.Parameters.AddWithValue("@rAddr", txtRegAddress.Text.Trim());

                        cmd.Parameters.AddWithValue("@lCity", txtLiveCity.Text.Trim());
                        cmd.Parameters.AddWithValue("@lAddr", txtLiveAddress.Text.Trim());

                        // Работа и контакты
                        cmd.Parameters.AddWithValue("@work", txtWorkplace.Text.Trim());
                        cmd.Parameters.AddWithValue("@pos", txtPosition.Text.Trim());
                        cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());

                        // Замечания (ТЕПЕРЬ РАСКОММЕНТИРОВАНО!)
                        // Если на форме нет поля txtNotes, замените на "" (пустая строка)
                        cmd.Parameters.AddWithValue("@notes", txtNotes.Text.Trim());

                        // Выполняем запрос
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Водитель успешно сохранен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка БД: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

            string email = txtEmail.Text.Trim();
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!System.Text.RegularExpressions.Regex.IsMatch(email, emailPattern))
            {
                MessageBox.Show("Введите корректный адрес Email (например: name@mail.ru)", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                errorProvider1.SetError(txtEmail, "Неверный формат");
                return;
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
            }
        }
        private void SetupCityAutoComplete()
        {
            string[] cities = new string[]
            {
        "Москва", "Санкт-Петербург", "Новосибирск", "Екатеринбург",
        "Казань", "Нижний Новгород", "Челябинск", "Самара",
        "Омск", "Ростов-на-Дону", "Уфа", "Красноярск",
        "Воронеж", "Пермь", "Волгоград", "Краснодар"
            };

            AutoCompleteStringCollection cityCollection = new AutoCompleteStringCollection();
            cityCollection.AddRange(cities);

            txtRegCity.AutoCompleteCustomSource = cityCollection;
            txtRegCity.AutoCompleteMode = AutoCompleteMode.SuggestAppend; // Предлагать и дописывать
            txtRegCity.AutoCompleteSource = AutoCompleteSource.CustomSource;

            txtLiveCity.AutoCompleteCustomSource = cityCollection;
            txtLiveCity.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtLiveCity.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        private void LoadDriverData(string driverId)
        {
            try
            {
                string sql = "SELECT * FROM Drivers WHERE Id = @id";

                using (SqliteConnection connection = new SqliteConnection(DatabaseHelper.ConnectionString))
                {
                    connection.Open();
                    using (SqliteCommand command = new SqliteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", driverId);

                        using (SqliteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtLastName.Text = reader["LastName"].ToString();
                                txtFirstName.Text = reader["FirstName"].ToString();
                                txtPatronymic.Text = reader["Patronymic"].ToString();

                                string passport = $"{reader["PassportSeries"]} {reader["PassportNumber"]}";
                                txtPassport.Text = passport.Trim();

                                txtRegCity.Text = reader["RegCity"].ToString();
                                txtRegAddress.Text = reader["RegAddressFull"].ToString();
                                txtLiveCity.Text = reader["LiveCity"].ToString();
                                txtLiveAddress.Text = reader["LiveAddressFull"].ToString();

                                txtWorkplace.Text = reader["Workplace"].ToString();
                                txtPosition.Text = reader["Position"].ToString();

                                txtPhone.Text = reader["Phone"].ToString();
                                txtEmail.Text = reader["Email"].ToString();

                                txtNotes.Text = reader["Notes"].ToString();

                                string photoFileName = reader["PhotoPath"].ToString();
                                if (!string.IsNullOrEmpty(photoFileName))
                                {
                                    string photoFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Photos");
                                    string photoFullPath = Path.Combine(photoFolder, photoFileName);

                                    if (File.Exists(photoFullPath))
                                    {
                                        pbPhoto.Image = Image.FromFile(photoFullPath);
                                    }
                                }

                                this.Text = $"Карточка водителя: {txtLastName.Text} {txtFirstName.Text}";
                            }
                            else
                            {
                                MessageBox.Show("Водитель не найден в базе данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.DialogResult = DialogResult.Cancel;
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных водителя:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
        private void DriverForm_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DriverIdToEdit))
            {
                LoadDriverData(DriverIdToEdit);
            }
            else
            {
                this.Text = "Новый водитель";
            }
        }

        private void txtRegCity_TextChanged(object sender, EventArgs e)
        {

        }
    }
}