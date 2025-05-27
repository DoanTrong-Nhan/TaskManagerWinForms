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

            LoadFormDataAsync(); // Lấy dữ liệu bất đồng bộ khi form khởi tạo
        }

        // Phương thức bất đồng bộ để load dữ liệu vào form
        private async void LoadFormDataAsync()
        {
           
            var statuses = await _taskService.GetAllStatuses();     
            var priorities = await _taskService.GetAllPriorities();  
            var users = await _taskService.GetUsersByRole(3);   

            // Bind dữ liệu vào ComboBox
            cboStatus.DataSource = statuses;
            cboStatus.DisplayMember = "StatusName";
            cboStatus.ValueMember = "StatusId";

            cboPriority.DataSource = priorities;
            cboPriority.DisplayMember = "PriorityName";
            cboPriority.ValueMember = "PriorityId";

            cboUser.DataSource = users;
            cboUser.DisplayMember = "FullName";
            cboUser.ValueMember = "UserId";

            // Nếu ở chế độ sửa, gán các giá trị cho các trường nhập liệu
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

        // Phương thức lưu khi nhấn nút Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Cập nhật thông tin task từ form
            _task.Title = txtTitle.Text;
            _task.Description = txtDescription.Text;
            _task.StartDate = dtpStart.Value;
            _task.DueDate = dtpDue.Value;
            _task.StatusId = (int?)cboStatus.SelectedValue;
            _task.PriorityId = (int?)cboPriority.SelectedValue;
            _task.UserId = (int?)cboUser.SelectedValue;

            // Kiểm tra nếu đang ở chế độ sửa thì update, ngược lại tạo mới
            if (_isEditMode)
                _taskService.UpdateTask(_task);  // Cập nhật task
            else
                _taskService.CreateTask(_task);  // Tạo mới task

            DialogResult = DialogResult.OK;
            Close();  // Đóng form sau khi lưu
        }
    }
}
