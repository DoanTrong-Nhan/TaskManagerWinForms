using System;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp.Combobox;
using WinFormsApp.Dtos;
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
            _ = LoadFilterDataAsync();
        }

        private void LoadTasks()
        {
            var taskDtos = _taskService.GetAllDtos();

            dgvTasks.DataSource = taskDtos;

            SetTaskGridHeaders();
        }

        private async System.Threading.Tasks.Task LoadFilterDataAsync()
        {
            var statuses = await _taskService.GetAllStatusesAsync();
            var priorities = await _taskService.GetAllPrioritiesAsync();

            cmbStatus.Items.Clear();
          
            foreach (var status in statuses)
            {
                cmbStatus.Items.Add(new ComboBoxItem(status.StatusName, status.StatusId));
            }
          

            cmbPriority.Items.Clear();
           
            foreach (var priority in priorities)
            {
                cmbPriority.Items.Add(new ComboBoxItem(priority.PriorityName, priority.PriorityId));
            }
         
        }




        private void btnSearch_Click(object sender, EventArgs e)
        {
            string? title = string.IsNullOrWhiteSpace(txtSearchTitle.Text) ? null : txtSearchTitle.Text;

            int? statusId = GetSelectedComboBoxValue(cmbStatus);
            int? priorityId = GetSelectedComboBoxValue(cmbPriority);

            var filteredTasks = _taskService.GetFilteredTasks(title, statusId, priorityId);

            dgvTasks.DataSource = null;
            dgvTasks.DataSource = filteredTasks;

            SetTaskGridHeaders();
        }


        private int? GetSelectedTaskId()
        {
            if (dgvTasks.CurrentRow?.DataBoundItem is TaskDto task)
                return task.TaskId;
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
                $"{task.Title}\n" +
                $"{task.Description}\n" +
                $"{task.StartDate:dd/MM/yyyy}\n" +
                $"{task.DueDate:dd/MM/yyyy}\n" +
                $"{task.Status?.StatusName ?? ""}\n" +
                $"{task.Priority?.PriorityName ?? ""}\n" +
                $"{task.User?.FullName ?? ""}",
                "",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void SetTaskGridHeaders()
        {
            dgvTasks.AutoGenerateColumns = true;
            dgvTasks.DataSource = _taskService.GetAllDtos();


        }

        private int? GetSelectedComboBoxValue(ComboBox comboBox)
        {
            if (comboBox.SelectedItem is ComboBoxItem item && item.Value is int intValue)
            {
                return intValue;
            }

            return null;
        }


    }
}
