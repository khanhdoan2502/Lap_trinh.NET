using System;
using System.Windows.Forms;

namespace bai_tap_4._1x
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Mặc định ẩn mật khẩu
            txtPassword.UseSystemPasswordChar = true;

            // Enter = Đăng nhập
            this.AcceptButton = btnLogin;

            // Esc = Thoát
            this.CancelButton = btnExit;
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Xóa thông báo lỗi cũ
            errorProvider1.Clear();

            bool isValid = true;

            // Kiểm tra tên đăng nhập
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvider1.SetError(txtUsername, "Vui lòng nhập tên đăng nhập");
                isValid = false;
            }

            // Kiểm tra mật khẩu
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Vui lòng nhập mật khẩu");
                isValid = false;
            }

            // Nếu dữ liệu không hợp lệ thì dừng
            if (!isValid)
                return;

            // Nếu hợp lệ
            MessageBox.Show(
                "Đăng nhập thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
        "Bạn có muốn thoát không?",
        "Xác nhận",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}