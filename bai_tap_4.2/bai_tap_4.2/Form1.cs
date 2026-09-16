using System;
using System.Windows.Forms;

namespace bai_tap_4._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void lblPhone_Click(object sender, EventArgs e)
        {

        }

        private void rdoMale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var courses = new[]
   {
        new { Id = 1, Name = "Lập trình C#" },
        new { Id = 2, Name = "Lập trình Java" },
        new { Id = 3, Name = "Lập trình Python" },
        new { Id = 4, Name = "Phát triển Web" }
    };

            cboCourse.DataSource = courses;
            cboCourse.DisplayMember = "Name";
            cboCourse.ValueMember = "Id";
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text;
            string phone = mtxtPhone.Text;
            string birthDate = dtpBirthDate.Value.ToString("dd/MM/yyyy");

            string courseName = cboCourse.Text;
            string courseId = cboCourse.SelectedValue.ToString();

            string gender = rdoMale.Checked ? "Nam" : "Nữ";

            string studyType = "";

            if (chkOnline.Checked)
                studyType += "Online ";

            if (chkOffline.Checked)
                studyType += "Offline";

            if (string.IsNullOrWhiteSpace(fullName))
            {
                MessageBox.Show("Vui lòng nhập họ tên!");
                txtFullName.Focus();
                return;
            }

            MessageBox.Show(
                "THÔNG TIN ĐĂNG KÝ\n\n" +
                "Họ và tên: " + fullName + "\n" +
                "Số điện thoại: " + phone + "\n" +
                "Ngày sinh: " + birthDate + "\n" +
                "Khóa học: " + courseName + "\n" +
                "Mã khóa học: " + courseId + "\n" +
                "Giới tính: " + gender + "\n" +
                "Hình thức học: " + studyType,
                "Kết quả đăng ký",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
