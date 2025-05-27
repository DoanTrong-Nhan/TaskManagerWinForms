namespace WinFormsApp
{
    partial class TaskManagementForm
    {
        private System.ComponentModel.IContainer components = null;

        private DataGridView dgvTasks;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnView;

        private TextBox txtSearchTitle;
        private ComboBox cmbStatus;
        private ComboBox cmbPriority;
        private Button btnSearch;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dgvTasks = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnView = new Button();
            txtSearchTitle = new TextBox();
            cmbStatus = new ComboBox();
            cmbPriority = new ComboBox();
            btnSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTasks).BeginInit();
            SuspendLayout();
            // 
            // dgvTasks
            // 
            dgvTasks.AllowUserToAddRows = false;
            dgvTasks.AllowUserToDeleteRows = false;
            dgvTasks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTasks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTasks.Location = new Point(25, 25);
            dgvTasks.Margin = new Padding(4, 4, 4, 4);
            dgvTasks.MultiSelect = false;
            dgvTasks.Name = "dgvTasks";
            dgvTasks.ReadOnly = true;
            dgvTasks.RowHeadersWidth = 51;
            dgvTasks.RowTemplate.Height = 29;
            dgvTasks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTasks.Size = new Size(925, 393);
            dgvTasks.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(25, 470);
            btnAdd.Margin = new Padding(4, 4, 4, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(125, 50);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(175, 470);
            btnEdit.Margin = new Padding(4, 4, 4, 4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(125, 50);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Sửa";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(325, 470);
            btnDelete.Margin = new Padding(4, 4, 4, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(125, 50);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Xoá";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnView
            // 
            btnView.Location = new Point(475, 470);
            btnView.Margin = new Padding(4, 4, 4, 4);
            btnView.Name = "btnView";
            btnView.Size = new Size(150, 50);
            btnView.TabIndex = 4;
            btnView.Text = "Xem Chi Tiết";
            btnView.UseVisualStyleBackColor = true;
            btnView.Click += btnView_Click;
            // 
            // txtSearchTitle
            // 
            txtSearchTitle.Location = new Point(25, 430);
            txtSearchTitle.Margin = new Padding(4, 4, 4, 4);
            txtSearchTitle.Name = "txtSearchTitle";
            txtSearchTitle.PlaceholderText = "Tiêu đề...";
            txtSearchTitle.Size = new Size(186, 31);
            txtSearchTitle.TabIndex = 5;
            // 
            // cmbStatus
            // 
            cmbStatus.Location = new Point(238, 430);
            cmbStatus.Margin = new Padding(4, 4, 4, 4);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(149, 33);
            cmbStatus.TabIndex = 6;
            // 
            // cmbPriority
            // 
            cmbPriority.Location = new Point(412, 430);
            cmbPriority.Margin = new Padding(4, 4, 4, 4);
            cmbPriority.Name = "cmbPriority";
            cmbPriority.Size = new Size(149, 33);
            cmbPriority.TabIndex = 7;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(588, 430);
            btnSearch.Margin = new Padding(4, 4, 4, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(125, 34);
            btnSearch.TabIndex = 8;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.Click += btnSearch_Click;
            // 
            // TaskManagementForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 550); // tăng chiều cao để đủ chỗ

            Controls.Add(dgvTasks);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(btnView);
            Controls.Add(txtSearchTitle);
            Controls.Add(cmbStatus);
            Controls.Add(cmbPriority);
            Controls.Add(btnSearch);
            Margin = new Padding(4, 4, 4, 4);
            Name = "TaskManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Công việc";
            ((System.ComponentModel.ISupportInitialize)dgvTasks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
