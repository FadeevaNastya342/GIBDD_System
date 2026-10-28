using System;
using System.Data;
using System.Data.SQLite; 
using System.Windows.Forms;

namespace GIBDD_System
{
    public partial class DriversListForm : Form
    {
        public DriversListForm()
        {
            InitializeComponent();

            // Запускаем загрузку данных сразу при открытии формы
            LoadDriversFromDb();
        }

        private void LoadDriversFromDb()
        {
            string dbPath = @"C:\Users\Анастасия\OneDrive\Desktop\гибдд\GIBDD_System\GIBDD_System\bin\x86\Debug\gibdd.db";

            try
            {
                // Подключаемся к базе
                using (SQLiteConnection conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
                {
                    conn.Open();

                    // Запрос: берем только основные поля, чтобы таблица была красивой
                    string query = "SELECT Id, LastName, FirstName, Patronymic, Phone, Workplace FROM Drivers";

                    // Используем адаптер для заполнения таблицы
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Показываем данные в нашем DataGridView
                        dataGridViewDrivers.DataSource = dt;

                        // Делаем заголовки на русском языке (опционально)
                        if (dataGridViewDrivers.Columns.Count > 0)
                        {
                            dataGridViewDrivers.Columns["Id"].HeaderText = "ID";
                            dataGridViewDrivers.Columns["LastName"].HeaderText = "Фамилия";
                            dataGridViewDrivers.Columns["FirstName"].HeaderText = "Имя";
                            dataGridViewDrivers.Columns["Patronymic"].HeaderText = "Отчество";
                            dataGridViewDrivers.Columns["Phone"].HeaderText = "Телефон";
                            dataGridViewDrivers.Columns["Workplace"].HeaderText = "Работа";

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить список: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Добавьте это внутрь класса DriversListForm
        private void DriversListForm_Load(object sender, EventArgs e)
        {
            // Можно оставить пустым, так как мы загружаем данные в конструкторе
            // Или вызовите LoadDriversFromDb(); здесь, если хотите
        }
    }
}