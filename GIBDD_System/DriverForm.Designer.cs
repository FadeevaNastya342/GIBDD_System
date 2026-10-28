namespace GIBDD_System
{
    partial class DriverForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DriverForm));
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblPatronymic = new System.Windows.Forms.Label();
            this.txtPatronymic = new System.Windows.Forms.TextBox();
            this.lblPassport = new System.Windows.Forms.Label();
            this.txtPassport = new System.Windows.Forms.TextBox();
            this.lblRegCity = new System.Windows.Forms.Label();
            this.txtRegCity = new System.Windows.Forms.TextBox();
            this.lblRegAddress = new System.Windows.Forms.Label();
            this.txtRegAddress = new System.Windows.Forms.TextBox();
            this.lblLiveCity = new System.Windows.Forms.Label();
            this.txtLiveCity = new System.Windows.Forms.TextBox();
            this.lblLiveAddress = new System.Windows.Forms.Label();
            this.txtLiveAddress = new System.Windows.Forms.TextBox();
            this.lblWorkplace = new System.Windows.Forms.Label();
            this.txtWorkplace = new System.Windows.Forms.TextBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPhoto = new System.Windows.Forms.Label();
            this.pbPhoto = new System.Windows.Forms.PictureBox();
            this.btnSelectPhoto = new System.Windows.Forms.Button();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ofdPhoto = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(75, 50);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(66, 16);
            this.lblLastName.TabIndex = 0;
            this.lblLastName.Text = "Фамилия";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(147, 50);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(403, 22);
            this.txtLastName.TabIndex = 1;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(20, 86);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(33, 16);
            this.lblFirstName.TabIndex = 2;
            this.lblFirstName.Text = "Имя";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(67, 80);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(483, 22);
            this.txtFirstName.TabIndex = 4;
            // 
            // lblPatronymic
            // 
            this.lblPatronymic.AutoSize = true;
            this.lblPatronymic.Location = new System.Drawing.Point(20, 113);
            this.lblPatronymic.Name = "lblPatronymic";
            this.lblPatronymic.Size = new System.Drawing.Size(70, 16);
            this.lblPatronymic.TabIndex = 5;
            this.lblPatronymic.Text = "Отчество";
            // 
            // txtPatronymic
            // 
            this.txtPatronymic.Location = new System.Drawing.Point(96, 110);
            this.txtPatronymic.Name = "txtPatronymic";
            this.txtPatronymic.Size = new System.Drawing.Size(454, 22);
            this.txtPatronymic.TabIndex = 6;
            // 
            // lblPassport
            // 
            this.lblPassport.AutoSize = true;
            this.lblPassport.Location = new System.Drawing.Point(20, 148);
            this.lblPassport.Name = "lblPassport";
            this.lblPassport.Size = new System.Drawing.Size(167, 16);
            this.lblPassport.TabIndex = 7;
            this.lblPassport.Text = "Паспорт (серия и номер)";
            // 
            // txtPassport
            // 
            this.txtPassport.Location = new System.Drawing.Point(193, 142);
            this.txtPassport.Name = "txtPassport";
            this.txtPassport.Size = new System.Drawing.Size(357, 22);
            this.txtPassport.TabIndex = 8;
            // 
            // lblRegCity
            // 
            this.lblRegCity.AutoSize = true;
            this.lblRegCity.Location = new System.Drawing.Point(20, 185);
            this.lblRegCity.Name = "lblRegCity";
            this.lblRegCity.Size = new System.Drawing.Size(133, 16);
            this.lblRegCity.TabIndex = 9;
            this.lblRegCity.Text = "Город регистрации";
            // 
            // txtRegCity
            // 
            this.txtRegCity.Location = new System.Drawing.Point(159, 179);
            this.txtRegCity.Name = "txtRegCity";
            this.txtRegCity.Size = new System.Drawing.Size(391, 22);
            this.txtRegCity.TabIndex = 10;
            this.txtRegCity.TextChanged += new System.EventHandler(this.txtRegCity_TextChanged);
            // 
            // lblRegAddress
            // 
            this.lblRegAddress.AutoSize = true;
            this.lblRegAddress.Location = new System.Drawing.Point(20, 219);
            this.lblRegAddress.Name = "lblRegAddress";
            this.lblRegAddress.Size = new System.Drawing.Size(153, 16);
            this.lblRegAddress.TabIndex = 11;
            this.lblRegAddress.Text = "Адрес (улица, дом, кв.)";
            // 
            // txtRegAddress
            // 
            this.txtRegAddress.Location = new System.Drawing.Point(179, 216);
            this.txtRegAddress.Name = "txtRegAddress";
            this.txtRegAddress.Size = new System.Drawing.Size(371, 22);
            this.txtRegAddress.TabIndex = 12;
            // 
            // lblLiveCity
            // 
            this.lblLiveCity.AutoSize = true;
            this.lblLiveCity.Location = new System.Drawing.Point(20, 257);
            this.lblLiveCity.Name = "lblLiveCity";
            this.lblLiveCity.Size = new System.Drawing.Size(129, 16);
            this.lblLiveCity.TabIndex = 13;
            this.lblLiveCity.Text = "Город проживания";
            // 
            // txtLiveCity
            // 
            this.txtLiveCity.Location = new System.Drawing.Point(155, 254);
            this.txtLiveCity.Name = "txtLiveCity";
            this.txtLiveCity.Size = new System.Drawing.Size(395, 22);
            this.txtLiveCity.TabIndex = 14;
            // 
            // lblLiveAddress
            // 
            this.lblLiveAddress.AutoSize = true;
            this.lblLiveAddress.Location = new System.Drawing.Point(20, 292);
            this.lblLiveAddress.Name = "lblLiveAddress";
            this.lblLiveAddress.Size = new System.Drawing.Size(153, 16);
            this.lblLiveAddress.TabIndex = 15;
            this.lblLiveAddress.Text = "Адрес (улица, дом, кв.)";
            // 
            // txtLiveAddress
            // 
            this.txtLiveAddress.Location = new System.Drawing.Point(179, 292);
            this.txtLiveAddress.Name = "txtLiveAddress";
            this.txtLiveAddress.Size = new System.Drawing.Size(371, 22);
            this.txtLiveAddress.TabIndex = 16;
            // 
            // lblWorkplace
            // 
            this.lblWorkplace.AutoSize = true;
            this.lblWorkplace.Location = new System.Drawing.Point(20, 335);
            this.lblWorkplace.Name = "lblWorkplace";
            this.lblWorkplace.Size = new System.Drawing.Size(99, 16);
            this.lblWorkplace.TabIndex = 17;
            this.lblWorkplace.Text = "Место работы";
            // 
            // txtWorkplace
            // 
            this.txtWorkplace.Location = new System.Drawing.Point(125, 332);
            this.txtWorkplace.Name = "txtWorkplace";
            this.txtWorkplace.Size = new System.Drawing.Size(425, 22);
            this.txtWorkplace.TabIndex = 18;
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(20, 374);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(78, 16);
            this.lblPosition.TabIndex = 19;
            this.lblPosition.Text = "Должность";
            // 
            // txtPosition
            // 
            this.txtPosition.Location = new System.Drawing.Point(104, 371);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(446, 22);
            this.txtPosition.TabIndex = 20;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(20, 413);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(143, 16);
            this.lblPhone.TabIndex = 21;
            this.lblPhone.Text = "Мобильный телефон";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(169, 410);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(381, 22);
            this.txtPhone.TabIndex = 22;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(20, 451);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(41, 16);
            this.lblEmail.TabIndex = 23;
            this.lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(67, 448);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(483, 22);
            this.txtEmail.TabIndex = 24;
            // 
            // lblPhoto
            // 
            this.lblPhoto.AutoSize = true;
            this.lblPhoto.Location = new System.Drawing.Point(12, 496);
            this.lblPhoto.Name = "lblPhoto";
            this.lblPhoto.Size = new System.Drawing.Size(89, 16);
            this.lblPhoto.TabIndex = 25;
            this.lblPhoto.Text = "Фотография";
            // 
            // pbPhoto
            // 
            this.pbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPhoto.Location = new System.Drawing.Point(23, 524);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(200, 267);
            this.pbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPhoto.TabIndex = 26;
            this.pbPhoto.TabStop = false;
            // 
            // btnSelectPhoto
            // 
            this.btnSelectPhoto.Location = new System.Drawing.Point(229, 524);
            this.btnSelectPhoto.Name = "btnSelectPhoto";
            this.btnSelectPhoto.Size = new System.Drawing.Size(109, 27);
            this.btnSelectPhoto.TabIndex = 27;
            this.btnSelectPhoto.Text = "Выбрать фото";
            this.btnSelectPhoto.UseVisualStyleBackColor = true;
            this.btnSelectPhoto.Click += new System.EventHandler(this.btnSelectPhoto_Click);
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(255, 699);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(80, 16);
            this.lblNotes.TabIndex = 28;
            this.lblNotes.Text = "Замечания";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(345, 699);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(225, 22);
            this.txtNotes.TabIndex = 29;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(298, 768);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 23);
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(455, 768);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 23);
            this.btnCancel.TabIndex = 31;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ofdPhoto
            // 
            this.ofdPhoto.FileName = "openFileDialog1";
            this.ofdPhoto.Filter = "Image Files|*.jpg;*.jpeg;*.png|All Files|*.*";
            this.ofdPhoto.RestoreDirectory = true;
            this.ofdPhoto.Title = "Выберите фотографию водителя";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbLogo.InitialImage")));
            this.pbLogo.Location = new System.Drawing.Point(9, 12);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(60, 60);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 32;
            this.pbLogo.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(188, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(288, 35);
            this.lblTitle.TabIndex = 33;
            this.lblTitle.Text = "Карточка водителя";
            // 
            // DriverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 803);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.btnSelectPhoto);
            this.Controls.Add(this.pbPhoto);
            this.Controls.Add(this.lblPhoto);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPosition);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.txtWorkplace);
            this.Controls.Add(this.lblWorkplace);
            this.Controls.Add(this.txtLiveAddress);
            this.Controls.Add(this.lblLiveAddress);
            this.Controls.Add(this.txtLiveCity);
            this.Controls.Add(this.lblLiveCity);
            this.Controls.Add(this.txtRegAddress);
            this.Controls.Add(this.lblRegAddress);
            this.Controls.Add(this.txtRegCity);
            this.Controls.Add(this.lblRegCity);
            this.Controls.Add(this.txtPassport);
            this.Controls.Add(this.lblPassport);
            this.Controls.Add(this.txtPatronymic);
            this.Controls.Add(this.lblPatronymic);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblLastName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "DriverForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Карточка водителя";
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblPatronymic;
        private System.Windows.Forms.TextBox txtPatronymic;
        private System.Windows.Forms.Label lblPassport;
        private System.Windows.Forms.TextBox txtPassport;
        private System.Windows.Forms.Label lblRegCity;
        private System.Windows.Forms.TextBox txtRegCity;
        private System.Windows.Forms.Label lblRegAddress;
        private System.Windows.Forms.TextBox txtRegAddress;
        private System.Windows.Forms.Label lblLiveCity;
        private System.Windows.Forms.TextBox txtLiveCity;
        private System.Windows.Forms.Label lblLiveAddress;
        private System.Windows.Forms.TextBox txtLiveAddress;
        private System.Windows.Forms.Label lblWorkplace;
        private System.Windows.Forms.TextBox txtWorkplace;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPhoto;
        private System.Windows.Forms.Button btnSelectPhoto;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.OpenFileDialog ofdPhoto;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox pbPhoto;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbLogo;
    }
}