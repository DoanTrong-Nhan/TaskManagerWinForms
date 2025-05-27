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
            LoadFilterDataAsync();
            LoadTasks();
        }

        private void LoadTasks()
        {
            var taskDtos = _taskService.GetAllDtos();

            dgvTasks.DataSource = null;
            dgvTasks.DataSource = taskDtos;

            dgvTasks.Columns["TaskId"].HeaderText = "Mã";
            dgvTasks.Columns["Title"].HeaderText = "Tiêu đề";
            dgvTasks.Columns["StartDateStr"].HeaderText = "Bắt đầu";
            dgvTasks.Columns["DueDateStr"].HeaderText = "Hạn chót";
            dgvTasks.Columns["StatusName"].HeaderText = "Trạng thái";
            dgvTasks.Columns["PriorityName"].HeaderText = "Độ ưu tiên";
            dgvTasks.Columns["UserFullName"].HeaderText = "Người thực hiện";
        }

        private async System.Threading.Tasks.Task LoadFilterDataAsync()
        {
            var statuses = await _taskService.GetAllStatusesAsync();
            var priorities = await _taskService.GetAllPrioritiesAsync();

            cmbStatus.DisplayMember = "StatusName";
            cmbStatus.ValueMember = "StatusId";
            cmbStatus.DataSource = statuses;
            cmbStatus.SelectedIndex = -1;

            cmbPriority.DisplayMember = "PriorityName";
            cmbPriority.ValueMember = "PriorityId";
            cmbPriority.DataSource = priorities;
            cmbPriority.SelectedIndex = -1;
        }




        private void btnSearch_Click(object sender, EventArgs e)
        {
            string? title = string.IsNullOrWhiteSpace(txtSearchTitle.Text) ? null : txtSearchTitle.Text;
            int? statusId = cmbStatus.SelectedItem != null ? (int?)cmbStatus.SelectedValue : null;
            int? priorityId = cmbPriority.SelectedItem != null ? (int?)cmbPriority.SelectedValue : null;

            var filteredTasks = _taskService.GetFilteredTasks(title, statusId, priorityId);

            dgvTasks.DataSource = null;
            dgvTasks.DataSource = filteredTasks;

            dgvTasks.Columns["TaskId"].HeaderText = "Mã";
            dgvTasks.Columns["Title"].HeaderText = "Tiêu đề";
            dgvTasks.Columns["StartDateStr"].HeaderText = "Bắt đầu";
            dgvTasks.Columns["DueDateStr"].HeaderText = "Hạn chót";
            dgvTasks.Columns["StatusName"].HeaderText = "Trạng thái";
            dgvTasks.Columns["PriorityName"].HeaderText = "Độ ưu tiên";
            dgvTasks.Columns["UserFullName"].HeaderText = "Người thực hiện";
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

            var task = _taskService.GetById(id.Value);
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
                _taskService.Delete(id.Value);
                LoadTasks();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            var id = GetSelectedTaskId();
            if (!id.HasValue) return;

            var task = _taskService.GetById(id.Value);
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
