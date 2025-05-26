using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp.Models;
using static WinFormsApp.Register;

namespace WinFormsApp
{
    public partial class Login : Form
    {
        private readonly TaskManagerDbContext _context;
        private readonly AdminForm _adminForm;
        private readonly ManagerForm _managerForm;
        private readonly MemberForm _memberForm;
        private readonly Register _registerForm;

        public Login(TaskManagerDbContext context, AdminForm adminForm, ManagerForm managerForm, MemberForm memberForm, Register registerForm)
        {
            InitializeComponent();
            _context = context;
            _adminForm = adminForm;
            _managerForm = managerForm;
            _memberForm = memberForm;
            _registerForm = registerForm;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            var user = _context.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Username == username);

            if (user != null && PasswordHelper.VerifyPassword(password, user.PasswordHash))
            {
                MessageBox.Show("Đăng nhập thành công!");
                this.Hide();

                switch (user.Role?.RoleName)
                {
                    case "Admin":
                        _adminForm.Show();
                        break;
                    case "Manager":
                        _managerForm.Show();
                        break;
                    case "Member":
                        _memberForm.Show();
                        break;
                    default:
                        MessageBox.Show("Vai trò không hợp lệ.");
                        this.Show();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            _registerForm.ShowDialog();
        }
    }
}
