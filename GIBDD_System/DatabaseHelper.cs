using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GIBDD_System
{
    internal class DatabaseHelper
    {
        // Путь к файлу базы данных в папке запуска программы
        public static string DbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "gibdd.db");

        // ИСПРАВЛЕНО: Используем полный путь DbPath в строке подключения
        public static string ConnectionString = $"Data Source={DbPath}";

        public static void Initialize()
        {

            try
            {
                if (!File.Exists(DbPath))
                {
                    File.WriteAllBytes(DbPath, new byte[0]);
                }

                    using (SqliteConnection connection = new SqliteConnection(ConnectionString))
                    {
                        connection.Open();

                        // Читаем скрипт создания таблиц
                        // Убедитесь, что файл CreateDatabase.sql лежит в папке bin\Debug 
                        // или настройте его копирование в свойствах файла
                        string scriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CreateDatabase.sql");

                        if (!File.Exists(scriptPath))
                        {
                            MessageBox.Show($"Файл скрипта не найден: {scriptPath}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string sqlScript = File.ReadAllText(scriptPath);

                        using (SqliteCommand command = new SqliteCommand(sqlScript, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при создании базы данных:\n{ex.Message}\n\nПроверьте наличие файла CreateDatabase.sql в папке программы.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
    }

    }