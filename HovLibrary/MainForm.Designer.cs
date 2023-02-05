namespace HovLibrary
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.masterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrowingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.memberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newBorrowingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allBorrowingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masterToolStripMenuItem,
            this.borrowingToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // masterToolStripMenuItem
            // 
            this.masterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.memberToolStripMenuItem,
            this.bookToolStripMenuItem});
            this.masterToolStripMenuItem.Name = "masterToolStripMenuItem";
            this.masterToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.masterToolStripMenuItem.Text = "Master";
            // 
            // borrowingToolStripMenuItem
            // 
            this.borrowingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newBorrowingToolStripMenuItem,
            this.allBorrowingToolStripMenuItem});
            this.borrowingToolStripMenuItem.Name = "borrowingToolStripMenuItem";
            this.borrowingToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.borrowingToolStripMenuItem.Text = "Borrowing";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // memberToolStripMenuItem
            // 
            this.memberToolStripMenuItem.Name = "memberToolStripMenuItem";
            this.memberToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.memberToolStripMenuItem.Text = "Member";
            this.memberToolStripMenuItem.Click += new System.EventHandler(this.memberToolStripMenuItem_Click);
            // 
            // bookToolStripMenuItem
            // 
            this.bookToolStripMenuItem.Name = "bookToolStripMenuItem";
            this.bookToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bookToolStripMenuItem.Text = "Book";
            this.bookToolStripMenuItem.Click += new System.EventHandler(this.bookToolStripMenuItem_Click);
            // 
            // newBorrowingToolStripMenuItem
            // 
            this.newBorrowingToolStripMenuItem.Name = "newBorrowingToolStripMenuItem";
            this.newBorrowingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newBorrowingToolStripMenuItem.Text = "New Borrowing";
            this.newBorrowingToolStripMenuItem.Click += new System.EventHandler(this.newBorrowingToolStripMenuItem_Click);
            // 
            // allBorrowingToolStripMenuItem
            // 
            this.allBorrowingToolStripMenuItem.Name = "allBorrowingToolStripMenuItem";
            this.allBorrowingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.allBorrowingToolStripMenuItem.Text = "All Borrowing";
            this.allBorrowingToolStripMenuItem.Click += new System.EventHandler(this.allBorrowingToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem masterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrowingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem memberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newBorrowingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allBorrowingToolStripMenuItem;
    }
}