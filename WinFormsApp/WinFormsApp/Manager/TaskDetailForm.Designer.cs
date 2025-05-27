namespace WinFormsApp.Manager
{
    partial class TaskDetailForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;

        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;

        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpStart;

        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.DateTimePicker dtpDue;

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cboStatus;

        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.ComboBox cboPriority;

        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.ComboBox cboUser;

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            txtTitle = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            lblStartDate = new Label();
            dtpStart = new DateTimePicker();
            lblDueDate = new Label();
            dtpDue = new DateTimePicker();
            lblStatus = new Label();
            cboStatus = new ComboBox();
            lblPriority = new Label();
            cboPriority = new ComboBox();
            lblUser = new Label();
            cboUser = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(30, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(73, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Tiêu đề:";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(150, 20);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(300, 31);
            txtTitle.TabIndex = 1;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(30, 60);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(63, 25);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "Mô tả:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(150, 60);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(300, 60);
            txtDescription.TabIndex = 3;
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Location = new Point(30, 140);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(124, 25);
            lblStartDate.TabIndex = 4;
            lblStartDate.Text = "Ngày bắt đầu:";
            // 
            // dtpStart
            // 
            dtpStart.Location = new Point(150, 140);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(200, 31);
            dtpStart.TabIndex = 5;
            // 
            // lblDueDate
            // 
            lblDueDate.AutoSize = true;
            lblDueDate.Location = new Point(30, 180);
            lblDueDate.Name = "lblDueDate";
            lblDueDate.Size = new Size(88, 25);
            lblDueDate.TabIndex = 6;
            lblDueDate.Text = "Hạn chót:";
            // 
            // dtpDue
            // 
            dtpDue.Location = new Point(150, 180);
            dtpDue.Name = "dtpDue";
            dtpDue.Size = new Size(200, 31);
            dtpDue.TabIndex = 7;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(30, 220);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(93, 25);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "Trạng thái:";
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.Location = new Point(150, 220);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(200, 33);
            cboStatus.TabIndex = 9;
            // 
            // lblPriority
            // 
            lblPriority.AutoSize = true;
            lblPriority.Location = new Point(30, 260);
            lblPriority.Name = "lblPriority";
            lblPriority.Size = new Size(100, 25);
            lblPriority.TabIndex = 10;
            lblPriority.Text = "Độ ưu tiên:";
            // 
            // cboPriority
            // 
            cboPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPriority.Location = new Point(150, 260);
            cboPriority.Name = "cboPriority";
            cboPriority.Size = new Size(200, 33);
            cboPriority.TabIndex = 11;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(30, 300);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(144, 25);
            lblUser.TabIndex = 12;
            lblUser.Text = "Người thực hiện:";
            // 
            // cboUser
            // 
            cboUser.DropDownStyle = ComboBoxStyle.DropDownList;
            cboUser.Location = new Point(150, 300);
            cboUser.Name = "cboUser";
            cboUser.Size = new Size(200, 33);
            cboUser.TabIndex = 13;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(150, 350);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 14;
            btnSave.Text = "Lưu";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(260, 350);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Huỷ";
            // 
            // TaskDetailForm
            // 
            ClientSize = new Size(568, 420);
            Controls.Add(lblTitle);
            Controls.Add(txtTitle);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(lblStartDate);
            Controls.Add(dtpStart);
            Controls.Add(lblDueDate);
            Controls.Add(dtpDue);
            Controls.Add(lblStatus);
            Controls.Add(cboStatus);
            Controls.Add(lblPriority);
            Controls.Add(cboPriority);
            Controls.Add(lblUser);
            Controls.Add(cboUser);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TaskDetailForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thông tin công việc";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
