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

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvTasks = new DataGridView();
            this.btnAdd = new Button();
            this.btnEdit = new Button();
            this.btnDelete = new Button();
            this.btnView = new Button();

            this.SuspendLayout();

            // 
            // dgvTasks
            // 
            this.dgvTasks.AllowUserToAddRows = false;
            this.dgvTasks.AllowUserToDeleteRows = false;
            this.dgvTasks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dgvTasks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTasks.Location = new Point(20, 20);
            this.dgvTasks.MultiSelect = false;
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.ReadOnly = true;
            this.dgvTasks.RowHeadersWidth = 51;
            this.dgvTasks.RowTemplate.Height = 29;
            this.dgvTasks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvTasks.Size = new Size(740, 320);
            this.dgvTasks.TabIndex = 0;

            // 
            // btnAdd
            // 
            this.btnAdd.Location = new Point(20, 360);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new Size(100, 40);
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);

            // 
            // btnEdit
            // 
            this.btnEdit.Location = new Point(140, 360);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new Size(100, 40);
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new EventHandler(this.btnEdit_Click);

            // 
            // btnDelete
            // 
            this.btnDelete.Location = new Point(260, 360);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new Size(100, 40);
            this.btnDelete.Text = "Xoá";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);

            // 
            // btnView
            // 
            this.btnView.Location = new Point(380, 360);
            this.btnView.Name = "btnView";
            this.btnView.Size = new Size(120, 40);
            this.btnView.Text = "Xem Chi Tiết";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new EventHandler(this.btnView_Click);

            // 
            // TaskManagementForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 420);
            this.Controls.Add(this.dgvTasks);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnView);
            this.Name = "TaskManagementForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Quản lý Công việc";
            this.ResumeLayout(false);
        }

        #endregion
    }
}
