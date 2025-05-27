using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinFormsApp.Services;

namespace WinFormsApp
{
    public partial class MemberForm : Form
    {
        private readonly ITaskService _taskService;
        private readonly int _loggedInUserId;

        public MemberForm(ITaskService taskService, int loggedInUserId)
        {
            InitializeComponent();
            _taskService = taskService;
            _loggedInUserId = loggedInUserId;
        }

        private void MemberForm_Load(object sender, EventArgs e)
        {
            LoadUserTasks();
        }

        private void LoadUserTasks()
        {
            var tasks = _taskService.GetTasksByUserId(_loggedInUserId);
            dgvTasks.DataSource = tasks;
        }
    }
}
