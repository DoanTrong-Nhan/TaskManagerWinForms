using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinFormsApp.Services; // Ensure this is the correct namespace
using WinFormsApp.Member; 

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

            // Register event handler for DataGridView cell click
            dgvTasks.CellContentClick += dgvTasks_CellContentClick;
        }

        private void MemberForm_Load(object sender, EventArgs e)
        {
            AddDetailButtonColumn(); // Add 'Detail' button column
            LoadUserTasks(); // Load tasks assigned to the logged-in user
        }

        private void AddDetailButtonColumn()
        {
            // Avoid adding the column multiple times
            if (dgvTasks.Columns["DetailButton"] == null)
            {
                var detailButton = new DataGridViewButtonColumn
                {
                    Name = "DetailButton",
                    HeaderText = "Chi tiết",
                    Text = "Xem",
                    UseColumnTextForButtonValue = true
                };
                dgvTasks.Columns.Add(detailButton);
            }
        }

        private void LoadUserTasks()
        {
            // Retrieve tasks for the logged-in user
            var tasks = _taskService.GetTasksByUserId(_loggedInUserId);
            dgvTasks.DataSource = tasks;

            // Ensure 'Detail' button is always at the end
            if (dgvTasks.Columns["DetailButton"] != null)
                dgvTasks.Columns["DetailButton"].DisplayIndex = dgvTasks.Columns.Count - 1;
        }

        private void dgvTasks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Ensure the click is within valid data area
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                // Check if the clicked column is 'DetailButton'
                if (dgvTasks.Columns[e.ColumnIndex].Name != "DetailButton")
                    return;

                // Ensure "TaskId" column exists
                if (!dgvTasks.Columns.Contains("TaskId"))
                {
                    MessageBox.Show("Không tìm thấy cột TaskId trong lưới dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Retrieve TaskId from the clicked row
                var cellValue = dgvTasks.Rows[e.RowIndex].Cells["TaskId"]?.Value?.ToString();
                if (!int.TryParse(cellValue, out int taskId))
                {
                    MessageBox.Show("ID công việc không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Retrieve the task details using the service
                var task = _taskService.GetDtoById(taskId);
                if (task == null)
                {
                    MessageBox.Show("Không tìm thấy công việc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create the TaskDetailForm through DI
                var form = new TaskDetailForm(task, _taskService);  // Ensure task is passed correctly
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadUserTasks(); // Refresh the task list after closing detail form
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi hiển thị chi tiết công việc:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
