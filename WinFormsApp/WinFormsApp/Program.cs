using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using WinFormsApp.Models;
using WinFormsApp.Repositories;
using WinFormsApp.Services;

namespace WinFormsApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Khởi tạo DI container
            var services = new ServiceCollection();

            // Đăng ký DbContext
            services.AddSingleton<TaskManagerDbContext>();

            // Đăng ký Services
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<ManagerForm>();
            services.AddScoped<TaskManagementForm>();


            // Đăng ký Forms
            services.AddTransient<Login>();
            services.AddTransient<AdminForm>();
            services.AddTransient<ManagerForm>();
            services.AddTransient<MemberForm>();
            services.AddTransient<Register>();
            services.AddTransient<TaskManagementForm>();

            // Tạo service provider
            var serviceProvider = services.BuildServiceProvider();

            // Lấy login form từ DI
            var loginForm = serviceProvider.GetRequiredService<Login>();

            Application.Run(loginForm);
        }
    }
}
