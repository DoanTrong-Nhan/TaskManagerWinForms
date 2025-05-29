using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using WinFormsApp.Models;
using WinFormsApp.Repositories;
using WinFormsApp.Services;
using WinFormsApp.Manager;

namespace WinFormsApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Tạo cấu hình từ appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Khởi tạo DI container
            var services = new ServiceCollection();

            // Đăng ký DbContext với chuỗi kết nối từ appsettings.json
            services.AddDbContext<TaskManagerDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Đăng ký Services
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ITaskService, TaskService>();

            services.AddTransient<TaskManagementForm>();
            services.AddTransient<TaskDetailForm>(); 


            // Tạo service provider
            var serviceProvider = services.BuildServiceProvider();

            // Lấy login form từ DI
            var loginForm = serviceProvider.GetRequiredService<TaskManagementForm>();

            // Chạy ứng dụng
            Application.Run(loginForm);
        }
    }
}
