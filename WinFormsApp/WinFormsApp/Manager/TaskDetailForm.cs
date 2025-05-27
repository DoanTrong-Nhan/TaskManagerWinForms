using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp.Models;
using WinFormsApp.Services;

namespace WinFormsApp.Manager
{
    public partial class TaskDetailForm : Form
    {
        private readonly ITaskService _taskService;
        private readonly TaskManagerDbContext _context;
        private Models.Task _task;
        private bool _isEditMode;

        public TaskDetailForm(ITaskService taskService, TaskManagerDbContext context, Models.Task? task = null)
        {
            InitializeComponent();
            _taskService = taskService;
            _context = context;
            _task = task ?? new Models.Task();
            _isEditMode = task != null;

            LoadFormData();
        }

        private void LoadFormData()
        {
            // Load combo box cho trạng thái, ưu tiên, user
            cboStatus.DataSource = _context.TaskStatuses.ToList();
            cboStatus.DisplayMember = "StatusName";
            cboStatus.ValueMember = "StatusId";

            cboPriority.DataSource = _context.TaskPriorities.ToList();
            cboPriority.DisplayMember = "PriorityName";
            cboPriority.ValueMember = "PriorityId";

            cboUser.DataSource = _context.Users.Where(u => u.RoleId == 3).ToList();
            cboUser.DisplayMember = "FullName";
            cboUser.ValueMember = "UserId";

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            _task.Title = txtTitle.Text;
            _task.Description = txtDescription.Text;
            _task.StartDate = dtpStart.Value;
            _task.DueDate = dtpDue.Value;
            _task.StatusId = (int?)cboStatus.SelectedValue;
            _task.PriorityId = (int?)cboPriority.SelectedValue;
            _task.UserId = (int?)cboUser.SelectedValue;

            if (_isEditMode)
                _taskService.UpdateTask(_task);
            else
                _taskService.CreateTask(_task);

            DialogResult = DialogResult.OK;
            Close();
        }
    }

}
