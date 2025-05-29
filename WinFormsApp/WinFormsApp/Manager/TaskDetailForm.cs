using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp.Combobox;
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

               
                cboStatus.Items.Clear();
                foreach (var status in statuses)
                {
                    cboStatus.Items.Add(new ComboBoxItem(status.StatusName, status.StatusId));
                }

               
                cboPriority.Items.Clear();
                foreach (var priority in priorities)
                {
                    cboPriority.Items.Add(new ComboBoxItem(priority.PriorityName, priority.PriorityId));
                }

                
                cboUser.Items.Clear();
                foreach (var user in users)
                {
                    cboUser.Items.Add(new ComboBoxItem(user.FullName, user.UserId));
                }

                if (_isEditMode)
                {
                    LoadFormFromTask();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

           
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


        private void LoadFormFromTask()
        {
            txtTitle.Text = _task.Title;
            txtDescription.Text = _task.Description;
            dtpStart.Value = _task.StartDate ?? DateTime.Now;
            dtpDue.Value = _task.DueDate ?? DateTime.Now;

            SelectComboBoxItemByValue(cboStatus, _task.StatusId);
            SelectComboBoxItemByValue(cboPriority, _task.PriorityId);
            SelectComboBoxItemByValue(cboUser, _task.UserId);
        }

        private void SelectComboBoxItemByValue(ComboBox comboBox, object? value)
        {
            if (value == null) return;

            foreach (ComboBoxItem item in comboBox.Items)
            {
                if (item.Value != null && item.Value.Equals(value))
                {
                    comboBox.SelectedItem = item;
                    break;
                }
            }
        }

        private void UpdateTaskFromForm()
        {
            _task.Title = txtTitle.Text;
            _task.Description = txtDescription.Text;
            _task.StartDate = dtpStart.Value;
            _task.DueDate = dtpDue.Value;

            _task.StatusId = GetSelectedComboBoxValue(cboStatus);
            _task.PriorityId = GetSelectedComboBoxValue(cboPriority);
            _task.UserId = GetSelectedComboBoxValue(cboUser);
        }

        private int? GetSelectedComboBoxValue(ComboBox comboBox)
        {
            if (comboBox.SelectedItem is ComboBoxItem item && item.Value is int intValue)
            {
                return intValue;
            }

            return null;
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

          

            return true;
        }

    }
}
