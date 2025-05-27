using System;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp.Models;
using BCrypt.Net; // Thêm dòng này

namespace WinFormsApp
{
    public partial class Register : Form
    {
        private readonly TaskManagerDbContext _context;

        public Register()
        {
            InitializeComponent();
            _context = new TaskManagerDbContext();
        }

        public static class PasswordHelper
        {
            public static string HashPassword(string password)
            {
                return BCrypt.Net.BCrypt.HashPassword(password);
            }

            public static bool VerifyPassword(string password, string hashedPassword)
            {
                return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu là bắt buộc.");
                return;
            }

            if (_context.Users.Any(u => u.Username == username))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại.");
                return;
            }

            string hashedPassword = PasswordHelper.HashPassword(password);

            var newUser = new User
            {
                Username = username,
                PasswordHash = hashedPassword,
                FullName = fullName,
                Email = email,
                RoleId = 2
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            MessageBox.Show("Đăng ký thành công!");
            this.Close(); // Đóng form sau khi đăng ký
        }
    }
}
