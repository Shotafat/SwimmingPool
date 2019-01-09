namespace SwimmingPool
{
    partial class gadasaxadi
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
            this.Senaxva = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gadaxda_fasi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gadaxda_saati = new System.Windows.Forms.TextBox();
            this.gamosvla = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Senaxva
            // 
            this.Senaxva.BackColor = System.Drawing.Color.SlateGray;
            this.Senaxva.Font = new System.Drawing.Font("Sylfaen", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Senaxva.ForeColor = System.Drawing.Color.Snow;
            this.Senaxva.Location = new System.Drawing.Point(12, 214);
            this.Senaxva.Name = "Senaxva";
            this.Senaxva.Size = new System.Drawing.Size(112, 41);
            this.Senaxva.TabIndex = 0;
            this.Senaxva.Text = "შენახვა";
            this.Senaxva.UseVisualStyleBackColor = false;
            this.Senaxva.Click += new System.EventHandler(this.Senaxva_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.gadaxda_fasi);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.gadaxda_saati);
            this.groupBox1.Font = new System.Drawing.Font("Sylfaen", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 182);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "გადასახადი";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(30, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "ფასი";
            // 
            // gadaxda_fasi
            // 
            this.gadaxda_fasi.Location = new System.Drawing.Point(125, 119);
            this.gadaxda_fasi.Name = "gadaxda_fasi";
            this.gadaxda_fasi.Size = new System.Drawing.Size(100, 27);
            this.gadaxda_fasi.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(30, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "საათები";
            // 
            // gadaxda_saati
            // 
            this.gadaxda_saati.Location = new System.Drawing.Point(125, 56);
            this.gadaxda_saati.Name = "gadaxda_saati";
            this.gadaxda_saati.Size = new System.Drawing.Size(100, 27);
            this.gadaxda_saati.TabIndex = 3;
            // 
            // gamosvla
            // 
            this.gamosvla.BackColor = System.Drawing.Color.SlateGray;
            this.gamosvla.Font = new System.Drawing.Font("Sylfaen", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gamosvla.ForeColor = System.Drawing.Color.Snow;
            this.gamosvla.Location = new System.Drawing.Point(143, 214);
            this.gamosvla.Name = "gamosvla";
            this.gamosvla.Size = new System.Drawing.Size(112, 41);
            this.gamosvla.TabIndex = 0;
            this.gamosvla.Text = "გამოსვლა";
            this.gamosvla.UseVisualStyleBackColor = false;
            this.gamosvla.Click += new System.EventHandler(this.gamosvla_Click);
            // 
            // gadasaxadi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gamosvla);
            this.Controls.Add(this.Senaxva);
            this.Name = "gadasaxadi";
            this.Text = "gadasaxadi";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Senaxva;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox gadaxda_fasi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox gadaxda_saati;
        private System.Windows.Forms.Button gamosvla;
    }
}