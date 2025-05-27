using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp.Models;
using WinFormsApp.Services;

namespace WinFormsApp.Manager
{
    public partial class TaskDetailForm : Form
    {
        private readonly ITaskService _taskService;
        private Models.Task _task;
        private bool _isEditMode;

        public TaskDetailForm(ITaskService taskService, Models.Task? task = null)
        {
            InitializeComponent();
            _taskService = taskService;
            _task = task ?? new Models.Task();
            _isEditMode = task != null;

            LoadFormDataAsync(); 
        }

     
        private async void LoadFormDataAsync()
        {
            try
            {
                var statuses = await _taskService.GetAllStatusesAsync();
                var priorities = await _taskService.GetAllPrioritiesAsync();
                var users = await _taskService.GetUsersByRoleAsync(3); 

              
                cboStatus.DataSource = statuses;
                cboStatus.DisplayMember = "StatusName";
                cboStatus.ValueMember = "StatusId";

                cboPriority.DataSource = priorities;
                cboPriority.DisplayMember = "PriorityName";
                cboPriority.ValueMember = "PriorityId";

                cboUser.DataSource = users;
                cboUser.DisplayMember = "FullName";
                cboUser.ValueMember = "UserId";

 
                if (_isEditMode)
                {
                    PopulateFormFromTask();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Save button click handler
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            // Thực hiện update task từ form rồi lưu như trước
            UpdateTaskFromForm();

            try
            {
                if (_isEditMode)
                    _taskService.Update(_task);
                else
                    _taskService.Create(_task);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving task: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void PopulateFormFromTask()
        {
            txtTitle.Text = _task.Title;
            txtDescription.Text = _task.Description;
            dtpStart.Value = _task.StartDate ?? DateTime.Now;
            dtpDue.Value = _task.DueDate ?? DateTime.Now;
            cboStatus.SelectedValue = _task.StatusId ?? -1;
            cboPriority.SelectedValue = _task.PriorityId ?? -1;
            cboUser.SelectedValue = _task.UserId ?? -1;
        }

        private void UpdateTaskFromForm()
        {
            _task.Title = txtTitle.Text;
            _task.Description = txtDescription.Text;
            _task.StartDate = dtpStart.Value;
            _task.DueDate = dtpDue.Value;
            _task.StatusId = (int?)cboStatus.SelectedValue;
            _task.PriorityId = (int?)cboPriority.SelectedValue;
            _task.UserId = (int?)cboUser.SelectedValue;
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Tiêu đề không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return false;
            }

            if (dtpDue.Value < dtpStart.Value)
            {
                MessageBox.Show("Hạn chót phải lớn hơn hoặc bằng ngày bắt đầu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDue.Focus();
                return false;
            }

            if (cboStatus.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn trạng thái!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboStatus.Focus();
                return false;
            }

            // Tương tự với các trường khác nếu cần

            return true;
        }

    }
}
