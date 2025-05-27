namespace WinFormsApp.Manager
{
    partial class TaskDetailForm
    {
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel tableLayoutPanel;
        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblStartDate;
        private DateTimePicker dtpStart;
        private Label lblDueDate;
        private DateTimePicker dtpDue;
        private Label lblStatus;
        private ComboBox cboStatus;
        private Label lblPriority;
        private ComboBox cboPriority;
        private Label lblUser;
        private ComboBox cboUser;
        private Button btnSave;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            tableLayoutPanel = new TableLayoutPanel();
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
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel.Controls.Add(lblTitle, 0, 0);
            tableLayoutPanel.Controls.Add(txtTitle, 1, 0);
            tableLayoutPanel.Controls.Add(lblDescription, 0, 1);
            tableLayoutPanel.Controls.Add(txtDescription, 1, 1);
            tableLayoutPanel.Controls.Add(lblStartDate, 0, 2);
            tableLayoutPanel.Controls.Add(dtpStart, 1, 2);
            tableLayoutPanel.Controls.Add(lblDueDate, 0, 3);
            tableLayoutPanel.Controls.Add(dtpDue, 1, 3);
            tableLayoutPanel.Controls.Add(lblStatus, 0, 4);
            tableLayoutPanel.Controls.Add(cboStatus, 1, 4);
            tableLayoutPanel.Controls.Add(lblPriority, 0, 5);
            tableLayoutPanel.Controls.Add(cboPriority, 1, 5);
            tableLayoutPanel.Controls.Add(lblUser, 0, 6);
            tableLayoutPanel.Controls.Add(cboUser, 1, 6);
            tableLayoutPanel.Controls.Add(btnSave, 0, 7);
            tableLayoutPanel.Controls.Add(btnCancel, 1, 7);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 8;
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.Size = new Size(828, 431);
            tableLayoutPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Location = new Point(3, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(242, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Tiêu đề:";
            // 
            // txtTitle
            // 
            txtTitle.Dock = DockStyle.Fill;
            txtTitle.Location = new Point(251, 3);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(574, 31);
            txtTitle.TabIndex = 1;
            // 
            // lblDescription
            // 
            lblDescription.Dock = DockStyle.Fill;
            lblDescription.Location = new Point(3, 37);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(242, 37);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "Mô tả:";
            // 
            // txtDescription
            // 
            txtDescription.Dock = DockStyle.Fill;
            txtDescription.Location = new Point(251, 40);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(574, 31);
            txtDescription.TabIndex = 3;
            // 
            // lblStartDate
            // 
            lblStartDate.Dock = DockStyle.Fill;
            lblStartDate.Location = new Point(3, 74);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(242, 37);
            lblStartDate.TabIndex = 4;
            lblStartDate.Text = "Ngày bắt đầu:";
            // 
            // dtpStart
            // 
            dtpStart.Dock = DockStyle.Fill;
            dtpStart.Location = new Point(251, 77);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(574, 31);
            dtpStart.TabIndex = 5;
            // 
            // lblDueDate
            // 
            lblDueDate.Dock = DockStyle.Fill;
            lblDueDate.Location = new Point(3, 111);
            lblDueDate.Name = "lblDueDate";
            lblDueDate.Size = new Size(242, 37);
            lblDueDate.TabIndex = 6;
            lblDueDate.Text = "Hạn chót:";
            // 
            // dtpDue
            // 
            dtpDue.Dock = DockStyle.Fill;
            dtpDue.Location = new Point(251, 114);
            dtpDue.Name = "dtpDue";
            dtpDue.Size = new Size(574, 31);
            dtpDue.TabIndex = 7;
            // 
            // lblStatus
            // 
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.Location = new Point(3, 148);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(242, 39);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "Trạng thái:";
            // 
            // cboStatus
            // 
            cboStatus.Dock = DockStyle.Fill;
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.Location = new Point(251, 151);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(574, 33);
            cboStatus.TabIndex = 9;
            // 
            // lblPriority
            // 
            lblPriority.Dock = DockStyle.Fill;
            lblPriority.Location = new Point(3, 187);
            lblPriority.Name = "lblPriority";
            lblPriority.Size = new Size(242, 39);
            lblPriority.TabIndex = 10;
            lblPriority.Text = "Độ ưu tiên:";
            // 
            // cboPriority
            // 
            cboPriority.Dock = DockStyle.Fill;
            cboPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPriority.Location = new Point(251, 190);
            cboPriority.Name = "cboPriority";
            cboPriority.Size = new Size(574, 33);
            cboPriority.TabIndex = 11;
            // 
            // lblUser
            // 
            lblUser.Dock = DockStyle.Fill;
            lblUser.Location = new Point(3, 226);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(242, 176);
            lblUser.TabIndex = 12;
            lblUser.Text = "Người thực hiện:";
            // 
            // cboUser
            // 
            cboUser.Dock = DockStyle.Fill;
            cboUser.DropDownStyle = ComboBoxStyle.DropDownList;
            cboUser.Location = new Point(251, 229);
            cboUser.Name = "cboUser";
            cboUser.Size = new Size(574, 33);
            cboUser.TabIndex = 13;
            // 
            // btnSave
            // 
            btnSave.Dock = DockStyle.Fill;
            btnSave.Location = new Point(3, 405);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(242, 23);
            btnSave.TabIndex = 14;
            btnSave.Text = "Lưu";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Dock = DockStyle.Fill;
            btnCancel.Location = new Point(251, 405);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(574, 23);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Huỷ";
            // 
            // TaskDetailForm
            // 
            ClientSize = new Size(828, 431);
            Controls.Add(tableLayoutPanel);
            Name = "TaskDetailForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thông tin công việc";
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}
