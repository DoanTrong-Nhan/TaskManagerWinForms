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
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.dtpDue = new System.Windows.Forms.DateTimePicker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.lblPriority = new System.Windows.Forms.Label();
            this.cboPriority = new System.Windows.Forms.ComboBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.cboUser = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Text = "Tiêu đề:";
            this.lblTitle.AutoSize = true;

            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(150, 20);
            this.txtTitle.Size = new System.Drawing.Size(300, 23);

            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(30, 60);
            this.lblDescription.Text = "Mô tả:";
            this.lblDescription.AutoSize = true;

            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(150, 60);
            this.txtDescription.Size = new System.Drawing.Size(300, 60);
            this.txtDescription.Multiline = true;

            // 
            // lblStartDate
            // 
            this.lblStartDate.Location = new System.Drawing.Point(30, 140);
            this.lblStartDate.Text = "Ngày bắt đầu:";
            this.lblStartDate.AutoSize = true;

            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(150, 140);
            this.dtpStart.Size = new System.Drawing.Size(200, 23);

            // 
            // lblDueDate
            // 
            this.lblDueDate.Location = new System.Drawing.Point(30, 180);
            this.lblDueDate.Text = "Hạn chót:";
            this.lblDueDate.AutoSize = true;

            // 
            // dtpDue
            // 
            this.dtpDue.Location = new System.Drawing.Point(150, 180);
            this.dtpDue.Size = new System.Drawing.Size(200, 23);

            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(30, 220);
            this.lblStatus.Text = "Trạng thái:";
            this.lblStatus.AutoSize = true;

            // 
            // cboStatus
            // 
            this.cboStatus.Location = new System.Drawing.Point(150, 220);
            this.cboStatus.Size = new System.Drawing.Size(200, 23);
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // 
            // lblPriority
            // 
            this.lblPriority.Location = new System.Drawing.Point(30, 260);
            this.lblPriority.Text = "Độ ưu tiên:";
            this.lblPriority.AutoSize = true;

            // 
            // cboPriority
            // 
            this.cboPriority.Location = new System.Drawing.Point(150, 260);
            this.cboPriority.Size = new System.Drawing.Size(200, 23);
            this.cboPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // 
            // lblUser
            // 
            this.lblUser.Location = new System.Drawing.Point(30, 300);
            this.lblUser.Text = "Người thực hiện:";
            this.lblUser.AutoSize = true;

            // 
            // cboUser
            // 
            this.cboUser.Location = new System.Drawing.Point(150, 300);
            this.cboUser.Size = new System.Drawing.Size(200, 23);
            this.cboUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // 
            // btnSave
            // 
            this.btnSave.Text = "Lưu";
            this.btnSave.Location = new System.Drawing.Point(150, 350);
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // 
            // btnCancel
            // 
            this.btnCancel.Text = "Huỷ";
            this.btnCancel.Location = new System.Drawing.Point(260, 350);
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            // 
            // TaskDetailForm
            // 
            this.ClientSize = new System.Drawing.Size(500, 420);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.lblDueDate);
            this.Controls.Add(this.dtpDue);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.lblPriority);
            this.Controls.Add(this.cboPriority);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.cboUser);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Text = "Thông tin công việc";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
