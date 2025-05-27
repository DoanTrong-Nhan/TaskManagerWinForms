using System;
using System.Windows.Forms;
using WinFormsApp.Services;

namespace WinFormsApp
{
    public partial class ManagerForm : Form
    {
       
    private readonly ITaskService _taskService;

    public ManagerForm(ITaskService taskService)
    {
        _taskService = taskService;
        InitializeComponent();
    }

        private void btnTasks_Click(object sender, EventArgs e)
        {
            var taskForm = new TaskManagementForm(_taskService);  // Là một Form
            taskForm.Show();  // hoặc ShowDialog() nếu muốn dạng popup modal
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            var empForm = new EmployeeManagementForm();  // Là một Form
            empForm.Show();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            var reportForm = new ReportForm();  // Là một Form
            reportForm.Show();
        }
    }
}
