namespace SwimmingPool
{
    partial class mwvrtneli
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
            this.shenaxva = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mwvrtneli_gvari = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mwvrtneli_saxeli = new System.Windows.Forms.TextBox();
            this.gamosvla = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // shenaxva
            // 
            this.shenaxva.BackColor = System.Drawing.Color.SlateGray;
            this.shenaxva.Font = new System.Drawing.Font("Sylfaen", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shenaxva.ForeColor = System.Drawing.Color.Snow;
            this.shenaxva.Location = new System.Drawing.Point(12, 189);
            this.shenaxva.Name = "shenaxva";
            this.shenaxva.Size = new System.Drawing.Size(112, 46);
            this.shenaxva.TabIndex = 0;
            this.shenaxva.Text = "შენახვა";
            this.shenaxva.UseVisualStyleBackColor = false;
            this.shenaxva.Click += new System.EventHandler(this.shenaxva_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mwvrtneli_gvari);
            this.groupBox1.Controls.Add(this.mwvrtneli_saxeli);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Sylfaen", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 161);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "მწვრთნელი";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(16, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "გვარი";
            // 
            // mwvrtneli_gvari
            // 
            this.mwvrtneli_gvari.Location = new System.Drawing.Point(107, 91);
            this.mwvrtneli_gvari.Name = "mwvrtneli_gvari";
            this.mwvrtneli_gvari.Size = new System.Drawing.Size(100, 27);
            this.mwvrtneli_gvari.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(16, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "სახელი";
            // 
            // mwvrtneli_saxeli
            // 
            this.mwvrtneli_saxeli.Location = new System.Drawing.Point(107, 37);
            this.mwvrtneli_saxeli.Name = "mwvrtneli_saxeli";
            this.mwvrtneli_saxeli.Size = new System.Drawing.Size(100, 27);
            this.mwvrtneli_saxeli.TabIndex = 3;
            // 
            // gamosvla
            // 
            this.gamosvla.BackColor = System.Drawing.Color.SlateGray;
            this.gamosvla.Font = new System.Drawing.Font("Sylfaen", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gamosvla.ForeColor = System.Drawing.Color.Snow;
            this.gamosvla.Location = new System.Drawing.Point(130, 189);
            this.gamosvla.Name = "gamosvla";
            this.gamosvla.Size = new System.Drawing.Size(112, 46);
            this.gamosvla.TabIndex = 0;
            this.gamosvla.Text = "გამოსვლა";
            this.gamosvla.UseVisualStyleBackColor = false;
            this.gamosvla.Click += new System.EventHandler(this.gamosvla_Click);
            // 
            // mwvrtneli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 287);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gamosvla);
            this.Controls.Add(this.shenaxva);
            this.Name = "mwvrtneli";
            this.Text = "მწვრთნელი";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button shenaxva;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox mwvrtneli_gvari;
        private System.Windows.Forms.TextBox mwvrtneli_saxeli;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button gamosvla;
    }
}