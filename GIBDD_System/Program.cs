using System;
using System.Windows.Forms;
using System.Threading;

namespace GIBDD_System
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // --- ДОБАВЛЯЕМ ПЕРЕХВАТЧИК ОШИБОК ---
            // Он поймает любую ошибку, которая происходит в потоках интерфейса
            Application.ThreadException += (sender, e) =>
            {
                MessageBox.Show($"КРИТИЧЕСКАЯ ОШИБКА ПРИЛОЖЕНИЯ:\n\n{e.Exception.Message}\n\nДетали:\n{e.Exception.StackTrace}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            // Ловит ошибки, которые происходят до запуска формы
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                Exception ex = (Exception)e.ExceptionObject;
                MessageBox.Show($"НЕОБРАБОТАННОЕ ИСКЛЮЧЕНИЕ:\n\n{ex.Message}\n\nДетали:\n{ex.StackTrace}",
                    "Фатальная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            };
            // ------------------------------------

            try
            {
                // Инициализация базы данных
                DatabaseHelper.Initialize();

                // Запуск формы авторизации
                Application.Run(new LoginForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при старте программы:\n{ex.Message}\n\n{ex.StackTrace}",
                    "Стартовая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}