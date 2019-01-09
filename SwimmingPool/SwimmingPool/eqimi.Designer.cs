namespace SwimmingPool
{
    partial class eqimi
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.eqimi_gvari = new System.Windows.Forms.TextBox();
            this.eqimi_saxeli = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.shenaxva = new System.Windows.Forms.Button();
            this.gamosvla = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.eqimi_gvari);
            this.groupBox1.Controls.Add(this.eqimi_saxeli);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Sylfaen", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 142);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ექიმი";
            // 
            // eqimi_gvari
            // 
            this.eqimi_gvari.Location = new System.Drawing.Point(105, 83);
            this.eqimi_gvari.Name = "eqimi_gvari";
            this.eqimi_gvari.Size = new System.Drawing.Size(100, 27);
            this.eqimi_gvari.TabIndex = 2;
            // 
            // eqimi_saxeli
            // 
            this.eqimi_saxeli.Location = new System.Drawing.Point(105, 27);
            this.eqimi_saxeli.Name = "eqimi_saxeli";
            this.eqimi_saxeli.Size = new System.Drawing.Size(100, 27);
            this.eqimi_saxeli.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(6, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "სახელი";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(6, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "გვარი";
            // 
            // shenaxva
            // 
            this.shenaxva.Font = new System.Drawing.Font("Sylfaen", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shenaxva.Location = new System.Drawing.Point(39, 192);
            this.shenaxva.Name = "shenaxva";
            this.shenaxva.Size = new System.Drawing.Size(102, 40);
            this.shenaxva.TabIndex = 1;
            this.shenaxva.Text = "შენახვა";
            this.shenaxva.UseVisualStyleBackColor = true;
            this.shenaxva.Click += new System.EventHandler(this.shenaxva_Click);
            // 
            // gamosvla
            // 
            this.gamosvla.Font = new System.Drawing.Font("Sylfaen", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gamosvla.Location = new System.Drawing.Point(185, 192);
            this.gamosvla.Name = "gamosvla";
            this.gamosvla.Size = new System.Drawing.Size(115, 40);
            this.gamosvla.TabIndex = 2;
            this.gamosvla.Text = "გამოსვლა";
            this.gamosvla.UseVisualStyleBackColor = true;
            this.gamosvla.Click += new System.EventHandler(this.gamosvla_Click);
            // 
            // eqimi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 259);
            this.Controls.Add(this.gamosvla);
            this.Controls.Add(this.shenaxva);
            this.Controls.Add(this.groupBox1);
            this.Name = "eqimi";
            this.Text = "ექიმი";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox eqimi_gvari;
        private System.Windows.Forms.TextBox eqimi_saxeli;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button shenaxva;
        private System.Windows.Forms.Button gamosvla;
    }
}