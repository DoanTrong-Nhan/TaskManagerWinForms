using System;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp.Manager;
using WinFormsApp.Models;
using WinFormsApp.Services;

namespace WinFormsApp
{
    public partial class TaskManagementForm : Form
    {
        private readonly ITaskService _taskService;

        public TaskManagementForm(ITaskService taskService)
        {
            _taskService = taskService;
            InitializeComponent();
            LoadTasks();
        }

        private void LoadTasks()
        {
            var tasks = _taskService.GetAllTasks()
                .Select(t => new
                {
                    t.TaskId,
                    t.Title,
                    StartDate = t.StartDate?.ToString("dd/MM/yyyy"),
                    DueDate = t.DueDate?.ToString("dd/MM/yyyy"),
                    Status = t.Status?.StatusName ?? "Không rõ",
                    Priority = t.Priority?.PriorityName ?? "Không rõ",
                    AssignedTo = t.User?.FullName ?? "Không có"
                })
                .ToList();

            dgvTasks.DataSource = null;
            dgvTasks.DataSource = tasks;

            dgvTasks.Columns["TaskId"].HeaderText = "Mã";
            dgvTasks.Columns["Title"].HeaderText = "Tiêu đề";
            dgvTasks.Columns["StartDate"].HeaderText = "Bắt đầu";
            dgvTasks.Columns["DueDate"].HeaderText = "Hạn chót";
            dgvTasks.Columns["Status"].HeaderText = "Trạng thái";
            dgvTasks.Columns["Priority"].HeaderText = "Độ ưu tiên";
            dgvTasks.Columns["AssignedTo"].HeaderText = "Người thực hiện";
        }

        private int? GetSelectedTaskId()
        {
            if (dgvTasks.CurrentRow?.Cells["TaskId"].Value is int id)
                return id;
            return null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var detailForm = new TaskDetailForm(_taskService);
            if (detailForm.ShowDialog() == DialogResult.OK)
                LoadTasks();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var id = GetSelectedTaskId();
            if (!id.HasValue) return;

            var task = _taskService.GetTaskById(id.Value);
            if (task == null) return;

            var detailForm = new TaskDetailForm(_taskService, task);
            if (detailForm.ShowDialog() == DialogResult.OK)
                LoadTasks();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = GetSelectedTaskId();
            if (!id.HasValue) return;

            var confirm = MessageBox.Show("Bạn có chắc chắn muốn xoá?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                _taskService.DeleteTask(id.Value);
                LoadTasks();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            var id = GetSelectedTaskId();
            if (!id.HasValue) return;

            var task = _taskService.GetTaskById(id.Value);
            if (task == null) return;

            MessageBox.Show(
                $"Tiêu đề: {task.Title}\n" +
                $"Bắt đầu: {task.StartDate:dd/MM/yyyy}\n" +
                $"Hạn chót: {task.DueDate:dd/MM/yyyy}\n" +
                $"Trạng thái: {task.Status?.StatusName ?? "Không rõ"}\n" +
                $"Ưu tiên: {task.Priority?.PriorityName ?? "Không rõ"}\n" +
                $"Người thực hiện: {task.User?.FullName ?? "Không có"}",
                "Chi tiết công việc",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
