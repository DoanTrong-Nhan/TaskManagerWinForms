using System;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp.Dtos;  // Ensure this is the correct namespace
using WinFormsApp.Services;

namespace WinFormsApp.Member
{
    public partial class TaskDetailForm : Form
    {
        private readonly TaskDto _taskDto;
        private readonly ITaskService _taskService;

        public TaskDetailForm(TaskDto taskDto, ITaskService taskService)
        {
            InitializeComponent();
            _taskDto = taskDto ?? throw new ArgumentNullException(nameof(taskDto)); // Thêm kiểm tra null
            _taskService = taskService;
        }

        private async void TaskDetailForm_Load(object sender, EventArgs e)
        {
            // Kiểm tra nếu _taskDto có giá trị hợp lệ
            if (_taskDto == null)
            {
                MessageBox.Show("Dữ liệu công việc không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Bind the task data to the form fields
            txtTitle.Text = _taskDto.Title;
            txtDescription.Text = _taskDto.Description;
            lblStartDate.Text = _taskDto.StartDate.Value.ToString("dd/MM/yyyy");
            lblDueDate.Text = _taskDto.DueDate.Value.ToString("dd/MM/yyyy");

            var statuses = await _taskService.GetAllStatusesAsync();
            cboStatus.DataSource = statuses;
            cboStatus.DisplayMember = "StatusName";
            cboStatus.ValueMember = "StatusId";

            // Set the current status
            var selected = statuses.FirstOrDefault(s => s.StatusName == _taskDto.StatusName);
            if (selected != null)
            {
                cboStatus.SelectedItem = selected;
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedStatus = cboStatus.SelectedItem;
                if (selectedStatus == null)
                {
                    MessageBox.Show("Vui lòng chọn trạng thái hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var statusId = (int)cboStatus.SelectedValue;

                // Call the service to update the task status
                _taskService.UpdateStatus(_taskDto.TaskId, statusId);

                MessageBox.Show("Cập nhật trạng thái thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
