namespace WinFormsApp
{
    partial class ManagerForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelSidebar = new Panel();
            this.btnReport = new Button();
            this.btnEmployees = new Button();
            this.btnTasks = new Button();
            this.panelMain = new Panel();
            this.lblTitle = new Label();

            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = Color.LightSlateGray;
            this.panelSidebar.Dock = DockStyle.Left;
            this.panelSidebar.Width = 200;
            this.panelSidebar.Controls.Add(this.btnReport);
            this.panelSidebar.Controls.Add(this.btnEmployees);
            this.panelSidebar.Controls.Add(this.btnTasks);

            // 
            // btnTasks
            // 
            this.btnTasks.Text = "📋 Quản lý Task";
            this.btnTasks.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnTasks.ForeColor = Color.White;
            this.btnTasks.FlatStyle = FlatStyle.Flat;
            this.btnTasks.BackColor = Color.SteelBlue;
            this.btnTasks.Dock = DockStyle.Top;
            this.btnTasks.Height = 50;
            this.btnTasks.Click += new EventHandler(this.btnTasks_Click);

            // 
            // btnEmployees
            // 
            this.btnEmployees.Text = "👤 Quản lý Nhân viên";
            this.btnEmployees.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnEmployees.ForeColor = Color.White;
            this.btnEmployees.FlatStyle = FlatStyle.Flat;
            this.btnEmployees.BackColor = Color.Teal;
            this.btnEmployees.Dock = DockStyle.Top;
            this.btnEmployees.Height = 50;
            this.btnEmployees.Click += new EventHandler(this.btnEmployees_Click);

            // 
            // btnReport
            // 
            this.btnReport.Text = "📊 Thống kê & Báo cáo";
            this.btnReport.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnReport.ForeColor = Color.White;
            this.btnReport.FlatStyle = FlatStyle.Flat;
            this.btnReport.BackColor = Color.DarkCyan;
            this.btnReport.Dock = DockStyle.Top;
            this.btnReport.Height = 50;
            this.btnReport.Click += new EventHandler(this.btnReport_Click);

            // 
            // panelMain
            // 
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.BackColor = Color.WhiteSmoke;
            this.panelMain.Controls.Add(this.lblTitle);

            // 
            // lblTitle
            // 
            this.lblTitle.Text = "Chào mừng, Quản lý!";
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(220, 30);

            // 
            // ManagerForm
            // 
            this.ClientSize = new Size(1000, 600);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelSidebar);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "ManagerForm";
            this.Text = "Bảng điều khiển Quản lý";
        }

        #endregion

        private Panel panelSidebar;
        private Panel panelMain;
        private Button btnTasks;
        private Button btnEmployees;
        private Button btnReport;
        private Label lblTitle;
    }
}
