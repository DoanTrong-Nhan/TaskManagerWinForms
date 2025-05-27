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

            LoadFormDataAsync(); // Asynchronously load data when form initializes
        }

        // Asynchronous method to load data into the form
        private async void LoadFormDataAsync()
        {
            try
            {
                var statuses = await _taskService.GetAllStatusesAsync();
                var priorities = await _taskService.GetAllPrioritiesAsync();
                var users = await _taskService.GetUsersByRoleAsync(3); // Assuming '3' is the correct RoleId for users

                // Bind data to ComboBox controls
                cboStatus.DataSource = statuses;
                cboStatus.DisplayMember = "StatusName";
                cboStatus.ValueMember = "StatusId";

                cboPriority.DataSource = priorities;
                cboPriority.DisplayMember = "PriorityName";
                cboPriority.ValueMember = "PriorityId";

                cboUser.DataSource = users;
                cboUser.DisplayMember = "FullName";
                cboUser.ValueMember = "UserId";

                // If in edit mode, set values to the form controls
                if (_isEditMode)
                {
                    txtTitle.Text = _task.Title;
                    txtDescription.Text = _task.Description;
                    dtpStart.Value = _task.StartDate ?? DateTime.Now;
                    dtpDue.Value = _task.DueDate ?? DateTime.Now;
                    cboStatus.SelectedValue = _task.StatusId ?? 0;
                    cboPriority.SelectedValue = _task.PriorityId ?? 0;
                    cboUser.SelectedValue = _task.UserId ?? 0;
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
            // Update task data from form controls
            _task.Title = txtTitle.Text;
            _task.Description = txtDescription.Text;
            _task.StartDate = dtpStart.Value;
            _task.DueDate = dtpDue.Value;
            _task.StatusId = (int?)cboStatus.SelectedValue;
            _task.PriorityId = (int?)cboPriority.SelectedValue;
            _task.UserId = (int?)cboUser.SelectedValue;

            try
            {
                // Check if it's edit mode or new task and call the appropriate service method
                if (_isEditMode)
                    _taskService.Update(_task);  // Update existing task
                else
                    _taskService.Create(_task);  // Create new task

                DialogResult = DialogResult.OK;  // Indicate success
                Close();  // Close the form
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving task: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
