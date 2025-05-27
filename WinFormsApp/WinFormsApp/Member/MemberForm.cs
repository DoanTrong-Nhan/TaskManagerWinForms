using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinFormsApp.Services;
using WinFormsApp.Member;
using WinFormsApp.Dtos; // Đảm bảo DTO được dùng đúng

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

            dgvTasks.CellContentClick += dgvTasks_CellContentClick;
        }

        private void MemberForm_Load(object sender, EventArgs e)
        {
            ThemCotNutChiTiet();
            TaiDanhSachCongViecNguoiDung();
        }

        private void ThemCotNutChiTiet()
        {
            if (dgvTasks.Columns["CotChiTiet"] == null)
            {
                var cotChiTiet = new DataGridViewButtonColumn
                {
                    Name = "CotChiTiet",
                    HeaderText = "Chi tiết",
                    Text = "Xem",
                    UseColumnTextForButtonValue = true
                };
                dgvTasks.Columns.Add(cotChiTiet);
            }
        }

        private void TaiDanhSachCongViecNguoiDung()
        {
            var danhSachCongViec = _taskService.GetTasksByUserId(_loggedInUserId);
            dgvTasks.DataSource = danhSachCongViec;

            if (dgvTasks.Columns["CotChiTiet"] != null)
                dgvTasks.Columns["CotChiTiet"].DisplayIndex = dgvTasks.Columns.Count - 1;
        }

        private void dgvTasks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                if (dgvTasks.Columns[e.ColumnIndex].Name != "CotChiTiet")
                    return;

                // Lấy TaskId thông qua binding object (an toàn hơn)
                if (dgvTasks.Rows[e.RowIndex].DataBoundItem is not TaskDto congViec)
                {
                    MessageBox.Show("Không thể xác định công việc từ dòng được chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var congViecChiTiet = _taskService.GetDtoById(congViec.TaskId);
                if (congViecChiTiet == null)
                {
                    MessageBox.Show("Không tìm thấy công việc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var formChiTiet = new TaskDetailForm(congViecChiTiet, _taskService);
                if (formChiTiet.ShowDialog() == DialogResult.OK)
                {
                    TaiDanhSachCongViecNguoiDung();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi hiển thị chi tiết công việc:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
