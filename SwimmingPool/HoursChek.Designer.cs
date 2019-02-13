namespace SwimmingPool
{
    partial class HoursChek
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.გაცდენაToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.დასწრებაToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.სხვაToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.დასვენებაToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(84, 59);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.ContextMenuStrip = this.contextMenuStrip1;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 59);
            this.button1.TabIndex = 0;
            this.button1.Text = "საათების\r\nნომერი\r\n";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.გაცდენაToolStripMenuItem,
            this.დასწრებაToolStripMenuItem,
            this.სხვაToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(135, 70);
            // 
            // გაცდენაToolStripMenuItem
            // 
            this.გაცდენაToolStripMenuItem.Name = "გაცდენაToolStripMenuItem";
            this.გაცდენაToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.გაცდენაToolStripMenuItem.Text = "გაცდენა";
            // 
            // დასწრებაToolStripMenuItem
            // 
            this.დასწრებაToolStripMenuItem.Name = "დასწრებაToolStripMenuItem";
            this.დასწრებაToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.დასწრებაToolStripMenuItem.Text = "დასწრება";
            // 
            // სხვაToolStripMenuItem
            // 
            this.სხვაToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.დასვენებაToolStripMenuItem});
            this.სხვაToolStripMenuItem.Name = "სხვაToolStripMenuItem";
            this.სხვაToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.სხვაToolStripMenuItem.Text = "სხვა";
            // 
            // დასვენებაToolStripMenuItem
            // 
            this.დასვენებაToolStripMenuItem.Name = "დასვენებაToolStripMenuItem";
            this.დასვენებაToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.დასვენებაToolStripMenuItem.Text = "დასვენება";
            // 
            // HoursChek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "HoursChek";
            this.Size = new System.Drawing.Size(90, 64);
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem გაცდენაToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem დასწრებაToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem სხვაToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem დასვენებაToolStripMenuItem;
    }
}
