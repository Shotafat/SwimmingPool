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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.გაცდენაToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.დასწრებაToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.სხვაToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.დასვენებაToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AttendLabel = new System.Windows.Forms.Label();
            this.HoursLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.გაცდენაToolStripMenuItem,
            this.დასწრებაToolStripMenuItem,
            this.სხვაToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 92);
            // 
            // გაცდენაToolStripMenuItem
            // 
            this.გაცდენაToolStripMenuItem.Name = "გაცდენაToolStripMenuItem";
            this.გაცდენაToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.გაცდენაToolStripMenuItem.Text = "გაცდენა";
            this.გაცდენაToolStripMenuItem.Click += new System.EventHandler(this.გაცდენაToolStripMenuItem_Click);
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
            this.სხვაToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.სხვაToolStripMenuItem.Text = "სხვა";
            // 
            // დასვენებაToolStripMenuItem
            // 
            this.დასვენებაToolStripMenuItem.Name = "დასვენებაToolStripMenuItem";
            this.დასვენებაToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.დასვენებაToolStripMenuItem.Text = "დასვენება";
            this.დასვენებაToolStripMenuItem.Click += new System.EventHandler(this.დასვენებაToolStripMenuItem_Click);
            // 
            // AttendLabel
            // 
            this.AttendLabel.AutoSize = true;
            this.AttendLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AttendLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AttendLabel.Location = new System.Drawing.Point(3, 9);
            this.AttendLabel.Name = "AttendLabel";
            this.AttendLabel.Size = new System.Drawing.Size(45, 16);
            this.AttendLabel.TabIndex = 4;
            this.AttendLabel.Text = "label1";
            this.AttendLabel.Click += new System.EventHandler(this.AttendLabel_Click);
            // 
            // HoursLabel
            // 
            this.HoursLabel.AutoSize = true;
            this.HoursLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HoursLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.HoursLabel.Location = new System.Drawing.Point(3, 25);
            this.HoursLabel.Name = "HoursLabel";
            this.HoursLabel.Size = new System.Drawing.Size(45, 16);
            this.HoursLabel.TabIndex = 3;
            this.HoursLabel.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(3, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "asdd";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // HoursChek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AttendLabel);
            this.Controls.Add(this.HoursLabel);
            this.Name = "HoursChek";
            this.Size = new System.Drawing.Size(132, 66);
            this.DoubleClick += new System.EventHandler(this.HoursChek_DoubleClick);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem გაცდენაToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem დასწრებაToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem სხვაToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem დასვენებაToolStripMenuItem;
        private System.Windows.Forms.Label AttendLabel;
        private System.Windows.Forms.Label HoursLabel;
        private System.Windows.Forms.Label label1;
    }
}
