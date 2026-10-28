using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace GIBDD_System
{
    public partial class MainForm : Form
    {
        private Shtraf _currentShtrafForPrint;

        // Глобальный список для хранения всех загруженных штрафов
        private List<Shtraf> allShtrafy = new List<Shtraf>();

        public MainForm()
        {
            InitializeComponent();
        }

        // Событие загрузки формы (если нужно что-то инициализировать при старте)
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Можно добавить приветствие или настройку грида
        }

        // --- ПУНКТ МЕНЮ: ВЫХОД ---
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); // Закрываем текущую форму
        }

        // --- ПУНКТ МЕНЮ: ЗАГРУЗИТЬ JSON ---
        // Убедитесь, что в дизайнере этот пункт меню называется menuItemLoadJson 
        // или перепривяжите событие Click на этот метод
        private void menuItemLoadJson_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON файлы (*.json)|*.json|Все файлы (*.*)|*.*";
                openFileDialog.Title = "Выберите файл с данными штрафов";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string jsonContent = File.ReadAllText(openFileDialog.FileName);

                        // Десериализация
                        List<Shtraf> shtrafyList = JsonConvert.DeserializeObject<List<Shtraf>>(jsonContent);

                        if (shtrafyList != null)
                        {
                            allShtrafy = shtrafyList; // Сохраняем в глобальную переменную

                            MessageBox.Show($"Успешно загружено {shtrafyList.Count} записей.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Отображаем все загруженные данные
                            dataGridView1.DataSource = null; // Сброс
                            dataGridView1.DataSource = allShtrafy;
                        }
                        else
                        {
                            MessageBox.Show("Файл пуст или имеет неверный формат.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при чтении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // --- ПУНКТ МЕНЮ: НЕОБРАБОТАННЫЕ ШТРАФЫ ---
        // Этот метод вызывается из designer-метода ниже
        private void ShowUnprocessedShtrafy()
        {
            if (allShtrafy == null || allShtrafy.Count == 0)
            {
                MessageBox.Show("Сначала загрузите данные через меню 'Загрузить JSON'.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Фильтруем: оставляем только те, где IsPaid == false
            List<Shtraf> unprocessed = allShtrafy.Where(s => !s.IsPaid).ToList();

            if (unprocessed.Count == 0)
            {
                MessageBox.Show("Нет необработанных штрафов. Все оплачено!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = null;
                return;
            }

            dataGridView1.DataSource = null; // Сброс источника
            dataGridView1.DataSource = unprocessed;

            MessageBox.Show($"Найдено {unprocessed.Count} необработанных штрафов.", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Обработчик клика по пункту меню "Необработанные штрафы" (из Designer.cs)
        private void необработанныеШтрафыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUnprocessedShtrafy();
        }

        // Если у вас есть отдельная кнопка на форме для этого, она тоже может вызывать ShowUnprocessedShtrafy()

        // --- ПУНКТ МЕНЮ: ДОБАВИТЬ ВОДИТЕЛЯ (Заглушка) ---
        private void добавитьВодителяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Функция добавления водителя пока не реализована.", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // --- ПУНКТ МЕНЮ: СПИСОК ВОДИТЕЛЕЙ (Заглушка) ---
        private void списокВодителейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Функция просмотра списка водителей пока не реализована.", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void списокВодителейToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
        {
            DriversListForm listForm = new DriversListForm();
            listForm.ShowDialog(); // Открывает окно и ждет, пока вы его закроете
        }
        }

        private void добавитьВодителяToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DriverForm addDriverForm = new DriverForm();

            addDriverForm.ShowDialog();
        }

        private void загрузитьJSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON файлы (*.json)|*.json|Все файлы (*.*)|*.*";
                openFileDialog.Title = "Выберите файл с данными штрафов";

                // Если пользователь нажал ОК
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // 2. Читаем текст из файла
                        string jsonContent = File.ReadAllText(openFileDialog.FileName);

                        // 3. Превращаем текст JSON в список объектов Shtraf
                        List<Shtraf> shtrafyList = JsonConvert.DeserializeObject<List<Shtraf>>(jsonContent);

                        if (shtrafyList != null && shtrafyList.Count > 0)
                        {
                            // 4. Сохраняем в глобальную переменную (чтобы потом фильтровать)
                            allShtrafy = shtrafyList;

                            // 5. Показываем данные в таблице
                            dataGridView1.DataSource = null; // Сброс
                            dataGridView1.DataSource = allShtrafy;

                            MessageBox.Show($"Успешно загружено {shtrafyList.Count} записей!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Файл пуст или имеет неверный формат.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при чтении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void необработанныеШтрафыToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // 1. Проверяем, есть ли вообще данные
            if (allShtrafy == null || allShtrafy.Count == 0)
            {
                MessageBox.Show("Сначала загрузите данные через меню 'Загрузить JSON'.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Фильтруем список: оставляем только те, где IsPaid == false
            List<Shtraf> unprocessed = allShtrafy.Where(s => !s.IsPaid).ToList();

            // 3. Если ничего не найдено
            if (unprocessed.Count == 0)
            {
                MessageBox.Show("Нет необработанных штрафов. Все оплачено!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = null; // Очищаем таблицу
                return;
            }

            // 4. Показываем отфильтрованный список в таблице
            dataGridView1.DataSource = null; // Сброс источника данных (важно для обновления)
            dataGridView1.DataSource = unprocessed;

            MessageBox.Show($"Найдено {unprocessed.Count} необработанных штрафов.", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void экспортВФССПCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null || ((List<Shtraf>)dataGridView1.DataSource).Count == 0)
            {
                MessageBox.Show("Нет данных для экспорта. Загрузите штрафы или выберите необработанные.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV файлы (*.csv)|*.csv|Все файлы (*.*)|*.*";
                saveFileDialog.Title = "Сохранить отчет для ФССП";
                saveFileDialog.FileName = "export_fssp.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        List<Shtraf> list = (List<Shtraf>)dataGridView1.DataSource;

                        using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName, false, System.Text.Encoding.UTF8))
                        {
                            // Заголовки столбцов (можно настроить под требования ФССП)
                            sw.WriteLine("ID;ФИО;Госномер;Дата нарушения;Сумма;Статья;Статус");

                            foreach (Shtraf s in list)
                            {
                                // Форматируем дату и статус для читаемости
                                string statusText = s.IsPaid ? "Оплачен" : "Не оплачен";
                                string dateText = s.Date.ToString("dd.MM.yyyy HH:mm");

                                // Записываем строку данных
                                sw.WriteLine($"{s.Id};{s.DriverName};{s.CarNumber};{dateText};{s.Amount};{s.ViolationType};{statusText}");
                            }
                        }

                        MessageBox.Show("Файл успешно сохранен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void печатьКарточкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Выберите штраф в таблице для печати карточки.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем данные выбранной строки
            Shtraf selectedShtraf = (Shtraf)dataGridView1.CurrentRow.DataBoundItem;

            // Настраиваем документ для печати
            printDocument1.DocumentName = $"Карточка штрафа {selectedShtraf.Id}";

            // Сохраняем данные во временную переменную, чтобы использовать их в событии печати
            _currentShtrafForPrint = selectedShtraf;

            // Открываем диалог печати
            using (PrintDialog printDialog = new PrintDialog())
            {
                printDialog.Document = printDocument1;
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            { 
            if (_currentShtrafForPrint == null) return;

            Font font = new Font("Arial", 14);
            Font titleFont = new Font("Arial", 18, FontStyle.Bold);
            Brush brush = Brushes.Black;

            float y = 50; // Отступ сверху
            float x = 50; // Отступ слева
            float lineHeight = 30; // Расстояние между строками

            // Рисуем заголовок
            e.Graphics.DrawString("КАРТОЧКА ШТРАФА ГИБДД", titleFont, brush, x, y);
            y += lineHeight * 2;

            // Рисуем данные
            e.Graphics.DrawString($"Номер постановления: {_currentShtrafForPrint.Id}", font, brush, x, y); y += lineHeight;
            e.Graphics.DrawString($"Водитель: {_currentShtrafForPrint.DriverName}", font, brush, x, y); y += lineHeight;
            e.Graphics.DrawString($"Автомобиль: {_currentShtrafForPrint.CarNumber}", font, brush, x, y); y += lineHeight;
            e.Graphics.DrawString($"Дата нарушения: {_currentShtrafForPrint.Date:dd.MM.yyyy}", font, brush, x, y); y += lineHeight;
            e.Graphics.DrawString($"Нарушение: {_currentShtrafForPrint.ViolationType}", font, brush, x, y); y += lineHeight;
            e.Graphics.DrawString($"Сумма штрафа: {_currentShtrafForPrint.Amount} руб.", font, brush, x, y); y += lineHeight;

            string status = _currentShtrafForPrint.IsPaid ? "ОПЛАЧЕН" : "НЕ ОПЛАЧЕН";
            e.Graphics.DrawString($"Статус: {status}", font, brush, x, y);

            // Освобождаем ресурсы шрифтов
            font.Dispose();
            titleFont.Dispose();
        }
    }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
        {
            string message =
                "АИС ГИБДД: Система учета штрафов\n" +
                "Версия: 1.0\n\n" +
                "Программа предназначена для:\n" +
                "- Загрузки данных о штрафах из JSON\n" +
                "- Фильтрации необработанных штрафов\n" +
                "- Экспорта отчетов для ФССП\n" +
                "- Печати карточек нарушений\n\n" +
                "Разработано в рамках учебного проекта.\n" +
                "© 2026 GIBDD System";

            MessageBox.Show(message, "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

        private void выходToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
        {
            this.Close();
        }
    }
    }
    }

    // === КЛАСС МОДЕЛИ ДАННЫХ ===
    public class Shtraf
    {
        public string Id { get; set; }
        public string DriverName { get; set; }
        public string CarNumber { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string ViolationType { get; set; }
        public bool IsPaid { get; set; }
        public string Status { get; set; }
    }