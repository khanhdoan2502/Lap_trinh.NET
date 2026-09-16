namespace bai_tap_4._2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblName = new Label();
            txtFullName = new TextBox();
            lblPhone = new Label();
            mtxtPhone = new MaskedTextBox();
            lblBirthDate = new Label();
            dtpBirthDate = new DateTimePicker();
            lblCourse = new Label();
            cboCourse = new ComboBox();
            grpGender = new GroupBox();
            rdoFemale = new RadioButton();
            rdoMale = new RadioButton();
            grpOptions = new GroupBox();
            chkOffline = new CheckBox();
            chkOnline = new CheckBox();
            btnRegister = new Button();
            grpGender.SuspendLayout();
            grpOptions.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(345, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(152, 20);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ĐĂNG KÝ KHÓA HỌC";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(92, 71);
            lblName.Name = "lblName";
            lblName.Size = new Size(73, 20);
            lblName.TabIndex = 1;
            lblName.Text = "Họ và tên";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(348, 68);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(125, 27);
            txtFullName.TabIndex = 2;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(92, 126);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(97, 20);
            lblPhone.TabIndex = 3;
            lblPhone.Text = "Số điện thoại";
            lblPhone.Click += lblPhone_Click;
            // 
            // mtxtPhone
            // 
            mtxtPhone.Location = new Point(348, 126);
            mtxtPhone.Mask = "(000) 000-0000";
            mtxtPhone.Name = "mtxtPhone";
            mtxtPhone.Size = new Size(125, 27);
            mtxtPhone.TabIndex = 4;
            // 
            // lblBirthDate
            // 
            lblBirthDate.AutoSize = true;
            lblBirthDate.Location = new Point(92, 180);
            lblBirthDate.Name = "lblBirthDate";
            lblBirthDate.Size = new Size(74, 20);
            lblBirthDate.TabIndex = 5;
            lblBirthDate.Text = "Ngày sinh";
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Format = DateTimePickerFormat.Short;
            dtpBirthDate.Location = new Point(345, 180);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(250, 27);
            dtpBirthDate.TabIndex = 6;
            // 
            // lblCourse
            // 
            lblCourse.AutoSize = true;
            lblCourse.Location = new Point(92, 230);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new Size(71, 20);
            lblCourse.TabIndex = 7;
            lblCourse.Text = "Khóa học";
            // 
            // cboCourse
            // 
            cboCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCourse.FormattingEnabled = true;
            cboCourse.Location = new Point(345, 230);
            cboCourse.Name = "cboCourse";
            cboCourse.Size = new Size(151, 28);
            cboCourse.TabIndex = 8;
            // 
            // grpGender
            // 
            grpGender.Controls.Add(rdoFemale);
            grpGender.Controls.Add(rdoMale);
            grpGender.Location = new Point(100, 286);
            grpGender.Name = "grpGender";
            grpGender.Size = new Size(397, 41);
            grpGender.TabIndex = 9;
            grpGender.TabStop = false;
            grpGender.Text = "Giới tính";
            // 
            // rdoFemale
            // 
            rdoFemale.AutoSize = true;
            rdoFemale.Location = new Point(274, 13);
            rdoFemale.Name = "rdoFemale";
            rdoFemale.Size = new Size(50, 24);
            rdoFemale.TabIndex = 1;
            rdoFemale.TabStop = true;
            rdoFemale.Text = "Nữ";
            rdoFemale.UseVisualStyleBackColor = true;
            // 
            // rdoMale
            // 
            rdoMale.AutoSize = true;
            rdoMale.Checked = true;
            rdoMale.Location = new Point(169, 13);
            rdoMale.Name = "rdoMale";
            rdoMale.Size = new Size(62, 24);
            rdoMale.TabIndex = 0;
            rdoMale.TabStop = true;
            rdoMale.Text = "Nam";
            rdoMale.UseVisualStyleBackColor = true;
            rdoMale.CheckedChanged += rdoMale_CheckedChanged;
            // 
            // grpOptions
            // 
            grpOptions.Controls.Add(chkOffline);
            grpOptions.Controls.Add(chkOnline);
            grpOptions.Location = new Point(102, 346);
            grpOptions.Name = "grpOptions";
            grpOptions.Size = new Size(394, 69);
            grpOptions.TabIndex = 10;
            grpOptions.TabStop = false;
            grpOptions.Text = "Hình thức học";
            // 
            // chkOffline
            // 
            chkOffline.AutoSize = true;
            chkOffline.Location = new Point(294, 16);
            chkOffline.Name = "chkOffline";
            chkOffline.Size = new Size(76, 24);
            chkOffline.TabIndex = 1;
            chkOffline.Text = "Offline";
            chkOffline.UseVisualStyleBackColor = true;
            // 
            // chkOnline
            // 
            chkOnline.AutoSize = true;
            chkOnline.Location = new Point(162, 14);
            chkOnline.Name = "chkOnline";
            chkOnline.Size = new Size(74, 24);
            chkOnline.TabIndex = 0;
            chkOnline.Text = "Online";
            chkOnline.UseVisualStyleBackColor = true;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(550, 376);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(94, 29);
            btnRegister.TabIndex = 11;
            btnRegister.Text = "Đăng ký";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRegister);
            Controls.Add(grpOptions);
            Controls.Add(grpGender);
            Controls.Add(cboCourse);
            Controls.Add(lblCourse);
            Controls.Add(dtpBirthDate);
            Controls.Add(lblBirthDate);
            Controls.Add(mtxtPhone);
            Controls.Add(lblPhone);
            Controls.Add(txtFullName);
            Controls.Add(lblName);
            Controls.Add(lblTitle);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            grpGender.ResumeLayout(false);
            grpGender.PerformLayout();
            grpOptions.ResumeLayout(false);
            grpOptions.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblName;
        private TextBox txtFullName;
        private Label lblPhone;
        private MaskedTextBox mtxtPhone;
        private Label lblBirthDate;
        private DateTimePicker dtpBirthDate;
        private Label lblCourse;
        private ComboBox cboCourse;
        private GroupBox grpGender;
        private RadioButton rdoFemale;
        private RadioButton rdoMale;
        private GroupBox grpOptions;
        private CheckBox chkOffline;
        private CheckBox chkOnline;
        private Button btnRegister;
    }
}
