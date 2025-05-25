using System;
using System.Windows.Forms;
using WinFormsApp.Models;

namespace WinFormsApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var dbContext = new TaskManagerDbContext();

            var adminForm = new AdminForm();
            var managerForm = new ManagerForm();
            var memberForm = new MemberForm();
            var registerForm = new Register();

            var loginForm = new Login(dbContext, adminForm, managerForm, memberForm, registerForm);

            Application.Run(loginForm);
        }
    }
}
