
namespace DemoPhanQuyen2
{
    partial class frmUserPermissions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lvwUser = new System.Windows.Forms.ListView();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.username = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Fullname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.detailMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwUser
            // 
            this.lvwUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwUser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.username,
            this.Fullname});
            this.lvwUser.ContextMenuStrip = this.contextMenuStrip1;
            this.lvwUser.FullRowSelect = true;
            this.lvwUser.HideSelection = false;
            this.lvwUser.Location = new System.Drawing.Point(13, 13);
            this.lvwUser.Name = "lvwUser";
            this.lvwUser.Size = new System.Drawing.Size(775, 425);
            this.lvwUser.TabIndex = 0;
            this.lvwUser.UseCompatibleStateImageBehavior = false;
            this.lvwUser.View = System.Windows.Forms.View.Details;
            this.lvwUser.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvwUser_MouseDown);
            // 
            // Id
            // 
            this.Id.Text = "Id";
            // 
            // username
            // 
            this.username.Text = "Username";
            this.username.Width = 300;
            // 
            // Fullname
            // 
            this.Fullname.Text = "Fullname";
            this.Fullname.Width = 300;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detailMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(168, 26);
            // 
            // detailMenuItem
            // 
            this.detailMenuItem.Name = "detailMenuItem";
            this.detailMenuItem.Size = new System.Drawing.Size(167, 22);
            this.detailMenuItem.Text = "Open Detail Form";
            this.detailMenuItem.Click += new System.EventHandler(this.detailMenuItem_Click);
            // 
            // frmUserPermissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lvwUser);
            this.Name = "frmUserPermissions";
            this.Text = "frmUserPermissions";
            this.Load += new System.EventHandler(this.frmUserPermissions_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwUser;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader username;
        private System.Windows.Forms.ColumnHeader Fullname;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem detailMenuItem;
    }
}