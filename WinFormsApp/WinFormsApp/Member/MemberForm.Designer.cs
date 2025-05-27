using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp
{
    partial class MemberForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvTasks;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.DataGridViewButtonColumn DetailButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvTasks = new System.Windows.Forms.DataGridView();
            this.DetailButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblWelcome = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            this.SuspendLayout();

            // 
            // dgvTasks
            // 
            this.dgvTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
        this.DetailButton});
            this.dgvTasks.Location = new System.Drawing.Point(25, 75);
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.RowHeadersWidth = 62;
            this.dgvTasks.RowTemplate.Height = 33;
            this.dgvTasks.Size = new System.Drawing.Size(938, 438);
            this.dgvTasks.TabIndex = 1;
            this.dgvTasks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTasks_CellContentClick);

            // 
            // DetailButton
            // 
            this.DetailButton.HeaderText = "Thao tác";
            this.DetailButton.MinimumWidth = 8;
            this.DetailButton.Name = "DetailButton";
            this.DetailButton.Text = "Chi tiết";
            this.DetailButton.UseColumnTextForButtonValue = true;
            this.DetailButton.Width = 150;

            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWelcome.Location = new System.Drawing.Point(25, 25);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(121, 32);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Xin chào!";
            this.lblWelcome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));

            // 
            // MemberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 562);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.dgvTasks);
            this.Name = "MemberForm";
            this.Text = "Công việc của bạn";
            this.Load += new System.EventHandler(this.MemberForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        #endregion
    }
}
