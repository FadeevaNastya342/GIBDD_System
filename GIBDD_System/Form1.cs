using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.Windows.Forms;

namespace GIBDD_System
{
    public partial class LoginForm : Form
    {
        // Переменные для логики
        private int _failedAttempts = 0;
        private const int MAX_ATTEMPTS = 3;
        private const int LOCKOUT_MINUTES = 1;

        public LoginForm()
        {
            InitializeComponent();

            // 1. Настройка подсказок (если не сделали в Designer)
            SetupTooltips();

            // 2. Настройка справки (если не сделали в Designer)
            SetupHelp();

            // 3. Проверка блокировки при запуске
            CheckLockoutStatus();

            // 4. Запуск таймеров
            timerInactivity.Start();
            timerLockout.Start();
        }

        private void SetupTooltips()
        {
            toolTip1.SetToolTip(txtLogin, "Введите логин: inspector");
            toolTip1.SetToolTip(txtPassword, "Введите пароль (совпадает с логином)");
            toolTip1.SetToolTip(btnEnter, "Нажмите для входа в систему");
        }

        private void SetupHelp()
        {
            helpProvider1.SetHelpString(txtLogin, "Поле для ввода имени пользователя");
            helpProvider1.SetHelpString(txtPassword, "Поле для ввода секретного пароля");
            helpProvider1.SetShowHelp(txtLogin, true);
            helpProvider1.SetShowHelp(txtPassword, true);
        }

        // --- ЛОГИКА БЛОКИРОВКИ ---

        private void CheckLockoutStatus()
        {
            DateTime? lockUntil = LockoutManager.GetLockoutTime();

            // Если есть запись о блокировке и время еще не вышло
            if (lockUntil.HasValue && DateTime.Now < lockUntil.Value)
            {
                BlockForm(lockUntil.Value);
            }
            else
            {
                // Если время вышло или записи нет - разрешаем вход
                if (lockUntil.HasValue)
                {
                    LockoutManager.ClearLockout();
                    _failedAttempts = 0;
                }
                EnableForm();
            }
        }

        private void BlockForm(DateTime unlockTime)
        {
            // Блокируем поля
            txtLogin.Enabled = false;
            txtPassword.Enabled = false;
            btnEnter.Enabled = false;

            // Показываем статус
            lblStatus.Text = $"Слишком много попыток.\nРазблокировка в {unlockTime.ToShortTimeString()}";
            lblStatus.ForeColor = System.Drawing.Color.DarkRed;

            // Меняем фон полей для наглядности
            txtLogin.BackColor = System.Drawing.Color.LightGray;
            txtPassword.BackColor = System.Drawing.Color.LightGray;
        }

        private void EnableForm()
        {
            txtLogin.Enabled = true;
            txtPassword.Enabled = true;
            btnEnter.Enabled = true;

            lblStatus.Text = "";

            txtLogin.BackColor = System.Drawing.Color.White;
            txtPassword.BackColor = System.Drawing.Color.White;
        }

        private void timerLockout_Tick(object sender, EventArgs e)
        {
            CheckLockoutStatus();
        }

        private void timerInactivity_Tick(object sender, EventArgs e)
        {
            if (btnEnter.Enabled)
            {
                MessageBox.Show("Сессия завершена из-за неактивности.", "Время вышло",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                foreach (Form f in Application.OpenForms)
                {
                    if (f != this) f.Close();
                }

                txtLogin.Clear();
                txtPassword.Clear();
                lblStatus.Text = "";
                _failedAttempts = 0;

                txtLogin.Focus();
            }
        }

        private void ResetInactivityTimer()
        {
            timerInactivity.Stop();
            timerInactivity.Start();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            ResetInactivityTimer();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            ResetInactivityTimer();
        }
        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            ResetInactivityTimer();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            ResetInactivityTimer();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {

            string login = txtLogin.Text;
            string password = txtPassword.Text;

            if (login == "inspector" && password == "inspector")
            {
                // Сброс попыток
                _failedAttempts = 0;
                LockoutManager.ClearLockout();

                try
                {
                    // 1. Создаем экземпляр формы
                    MainForm mainForm = new MainForm();

                    // 2. Показываем её модально (программа ждет, пока закроется MainForm)
                    mainForm.ShowDialog();

                    // 3. После закрытия MainForm возвращаем форму входа
                    this.Show();
                    txtPassword.Clear();
                    txtLogin.Focus();
                }
                catch (Exception ex)
                {
                    // ЭТОТ БЛОК ПОКАЖЕТ ОШИБКУ, ЕСЛИ ОНА ЕСТЬ ВНУТРИ MainForm
                    MessageBox.Show($"Ошибка при открытии главного окна:\n{ex.Message}\n\nДетали:\n{ex.InnerException?.Message}",
                        "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.Hide(); // Скрываем форму входа ТОЛЬКО если всё успешно
            }
            else
            {
                // Логика неверного пароля...
                // ...
            }
        }

        private void btnEnter_Click_1(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Text;

            if (login == "inspector" && password == "inspector")
            {
                // Сброс попыток
                _failedAttempts = 0;
                LockoutManager.ClearLockout();

                try
                {
                    // 1. Создаем экземпляр формы
                    MainForm mainForm = new MainForm();

                    // 2. Показываем её модально (программа ждет, пока закроется MainForm)
                    mainForm.ShowDialog();

                    // 3. После закрытия MainForm возвращаем форму входа
                    this.Show();
                    txtPassword.Clear();
                    txtLogin.Focus();
                }
                catch (Exception ex)
                {
                    // ЭТОТ БЛОК ПОКАЖЕТ ОШИБКУ, ЕСЛИ ОНА ЕСТЬ ВНУТРИ MainForm
                    MessageBox.Show($"Ошибка при открытии главного окна:\n{ex.Message}\n\nДетали:\n{ex.InnerException?.Message}",
                        "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.Hide(); // Скрываем форму входа ТОЛЬКО если всё успешно
            }
            // В методе btnEnter_Click, внутри блока else (неверный пароль):
            else
            {
                _failedAttempts++; // Увеличиваем счетчик (теперь переменная используется!)

                if (_failedAttempts >= 3)
                {
                    MessageBox.Show("Слишком много неудачных попыток! Форма заблокирована.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Тут код блокировки...
                }
                else
                {
                    lblStatus.Text = $"Неверный пароль. Осталось попыток: {3 - _failedAttempts}";
                }
            }
        }
        private void lblStatus_Click(object sender, EventArgs e)
        {
        }
    }
}