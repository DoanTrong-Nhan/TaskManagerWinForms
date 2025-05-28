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
            this.Hide();

            var taskForm = new TaskManagementForm(_taskService);

            taskForm.FormClosed += (s, args) => this.Show();
            taskForm.Show();  
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            var empForm = new EmployeeManagementForm(); 
            empForm.Show();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            var reportForm = new ReportForm(); 
            reportForm.Show();
        }
    }
}
