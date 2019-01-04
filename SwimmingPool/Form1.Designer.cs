namespace SwimmingPool
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.mwvrtnelis_nomeri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mwvrtnelis_saxeli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mwvrtnelis_gvari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abonentis_nomeri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abonentis_saxeli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abonentis_gvari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abonentis_dabtarigi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abonentis_telefoni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abonentis_misamarti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.eqimis_nomeri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eqimis_saxeli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eqimis_gvari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.cnobis_nomeri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnoba_cnoba = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.gadasaxadis_saati = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gadasaxadis_fasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("Sylfaen", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(650, 223);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "აბონემენტი";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Sylfaen", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.abonentis_nomeri,
            this.abonentis_saxeli,
            this.abonentis_gvari,
            this.abonentis_dabtarigi,
            this.abonentis_telefoni,
            this.abonentis_misamarti});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(644, 197);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Font = new System.Drawing.Font("Sylfaen", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Red;
            this.groupBox2.Location = new System.Drawing.Point(12, 442);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(352, 166);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "მწვრთნელი";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mwvrtnelis_nomeri,
            this.mwvrtnelis_saxeli,
            this.mwvrtnelis_gvari});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 23);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(346, 140);
            this.dataGridView2.TabIndex = 0;
            // 
            // mwvrtnelis_nomeri
            // 
            this.mwvrtnelis_nomeri.HeaderText = "ნომერი";
            this.mwvrtnelis_nomeri.Name = "mwvrtnelis_nomeri";
            // 
            // mwvrtnelis_saxeli
            // 
            this.mwvrtnelis_saxeli.HeaderText = "სახელი";
            this.mwvrtnelis_saxeli.Name = "mwvrtnelis_saxeli";
            // 
            // mwvrtnelis_gvari
            // 
            this.mwvrtnelis_gvari.HeaderText = "გვარი";
            this.mwvrtnelis_gvari.Name = "mwvrtnelis_gvari";
            // 
            // abonentis_nomeri
            // 
            this.abonentis_nomeri.HeaderText = "აბონემენტის ნომერი";
            this.abonentis_nomeri.Name = "abonentis_nomeri";
            // 
            // abonentis_saxeli
            // 
            this.abonentis_saxeli.HeaderText = "სახელი";
            this.abonentis_saxeli.Name = "abonentis_saxeli";
            // 
            // abonentis_gvari
            // 
            this.abonentis_gvari.HeaderText = "გვარი";
            this.abonentis_gvari.Name = "abonentis_gvari";
            // 
            // abonentis_dabtarigi
            // 
            this.abonentis_dabtarigi.HeaderText = "დაბადების თარიღი";
            this.abonentis_dabtarigi.Name = "abonentis_dabtarigi";
            // 
            // abonentis_telefoni
            // 
            this.abonentis_telefoni.HeaderText = "ტელეფონის ნომერი";
            this.abonentis_telefoni.Name = "abonentis_telefoni";
            // 
            // abonentis_misamarti
            // 
            this.abonentis_misamarti.HeaderText = "მისამართი";
            this.abonentis_misamarti.Name = "abonentis_misamarti";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dataGridView3);
            this.groupBox3.Font = new System.Drawing.Font("Sylfaen", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Red;
            this.groupBox3.Location = new System.Drawing.Point(367, 442);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(351, 166);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ექიმი";
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.eqimis_nomeri,
            this.eqimis_saxeli,
            this.eqimis_gvari});
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView3.Location = new System.Drawing.Point(3, 23);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(345, 140);
            this.dataGridView3.TabIndex = 0;
            // 
            // eqimis_nomeri
            // 
            this.eqimis_nomeri.HeaderText = "ნომერი";
            this.eqimis_nomeri.Name = "eqimis_nomeri";
            // 
            // eqimis_saxeli
            // 
            this.eqimis_saxeli.HeaderText = "სახელი";
            this.eqimis_saxeli.Name = "eqimis_saxeli";
            // 
            // eqimis_gvari
            // 
            this.eqimis_gvari.HeaderText = "გვარი";
            this.eqimis_gvari.Name = "eqimis_gvari";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.dataGridView4);
            this.groupBox4.Font = new System.Drawing.Font("Sylfaen", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.Red;
            this.groupBox4.Location = new System.Drawing.Point(724, 442);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(250, 166);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ცნობა";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.dataGridView5);
            this.groupBox5.Font = new System.Drawing.Font("Sylfaen", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.Red;
            this.groupBox5.Location = new System.Drawing.Point(980, 442);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(255, 163);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "გადასახადი";
            // 
            // dataGridView4
            // 
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnobis_nomeri,
            this.cnoba_cnoba});
            this.dataGridView4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView4.Location = new System.Drawing.Point(3, 23);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(244, 140);
            this.dataGridView4.TabIndex = 0;
            // 
            // cnobis_nomeri
            // 
            this.cnobis_nomeri.HeaderText = "ნომერი";
            this.cnobis_nomeri.Name = "cnobis_nomeri";
            // 
            // cnoba_cnoba
            // 
            this.cnoba_cnoba.HeaderText = "ცნობა";
            this.cnoba_cnoba.Name = "cnoba_cnoba";
            // 
            // dataGridView5
            // 
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gadasaxadis_saati,
            this.gadasaxadis_fasi});
            this.dataGridView5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView5.Location = new System.Drawing.Point(3, 23);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.Size = new System.Drawing.Size(249, 137);
            this.dataGridView5.TabIndex = 0;
            // 
            // gadasaxadis_saati
            // 
            this.gadasaxadis_saati.HeaderText = "საათი";
            this.gadasaxadis_saati.Name = "gadasaxadis_saati";
            // 
            // gadasaxadis_fasi
            // 
            this.gadasaxadis_fasi.HeaderText = "ფასი";
            this.gadasaxadis_fasi.Name = "gadasaxadis_fasi";
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.textBox1);
            this.groupBox6.Font = new System.Drawing.Font("Sylfaen", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.ForeColor = System.Drawing.Color.Red;
            this.groupBox6.Location = new System.Drawing.Point(668, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(249, 100);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "აბონენტის ძებნა";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(45, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 27);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Navy;
            this.button1.Font = new System.Drawing.Font("Sylfaen", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Snow;
            this.button1.Location = new System.Drawing.Point(923, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 100);
            this.button1.TabIndex = 6;
            this.button1.Text = "gfd";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 620);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.HelpButton = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn abonentis_nomeri;
        private System.Windows.Forms.DataGridViewTextBoxColumn abonentis_saxeli;
        private System.Windows.Forms.DataGridViewTextBoxColumn abonentis_gvari;
        private System.Windows.Forms.DataGridViewTextBoxColumn abonentis_dabtarigi;
        private System.Windows.Forms.DataGridViewTextBoxColumn abonentis_telefoni;
        private System.Windows.Forms.DataGridViewTextBoxColumn abonentis_misamarti;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn mwvrtnelis_nomeri;
        private System.Windows.Forms.DataGridViewTextBoxColumn mwvrtnelis_saxeli;
        private System.Windows.Forms.DataGridViewTextBoxColumn mwvrtnelis_gvari;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn eqimis_nomeri;
        private System.Windows.Forms.DataGridViewTextBoxColumn eqimis_saxeli;
        private System.Windows.Forms.DataGridViewTextBoxColumn eqimis_gvari;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnobis_nomeri;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnoba_cnoba;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dataGridView5;
        private System.Windows.Forms.DataGridViewTextBoxColumn gadasaxadis_saati;
        private System.Windows.Forms.DataGridViewTextBoxColumn gadasaxadis_fasi;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}

