namespace perpus
{
    partial class form_pengembalian
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
            this.tblPengembalian = new System.Windows.Forms.DataGridView();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtJudul = new System.Windows.Forms.TextBox();
            this.txtDenda = new System.Windows.Forms.TextBox();
            this.tgl_balik = new System.Windows.Forms.DateTimePicker();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tblPengembalian)).BeginInit();
            this.SuspendLayout();
            // 
            // tblPengembalian
            // 
            this.tblPengembalian.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblPengembalian.Location = new System.Drawing.Point(12, 36);
            this.tblPengembalian.Name = "tblPengembalian";
            this.tblPengembalian.Size = new System.Drawing.Size(379, 363);
            this.tblPengembalian.TabIndex = 0;
            this.tblPengembalian.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.tblPengembalian_RowHeaderMouseClick);
            // 
            // txtCari
            // 
            this.txtCari.Location = new System.Drawing.Point(12, 10);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(291, 20);
            this.txtCari.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(309, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "CARI";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(413, 294);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "KEMBALIKAN";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(410, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "ID Buku";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(410, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Judul";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(410, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tanggal Kembali";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(410, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Denda";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(413, 52);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(109, 20);
            this.txtID.TabIndex = 9;
            // 
            // txtJudul
            // 
            this.txtJudul.Location = new System.Drawing.Point(413, 116);
            this.txtJudul.Name = "txtJudul";
            this.txtJudul.Size = new System.Drawing.Size(109, 20);
            this.txtJudul.TabIndex = 10;
            // 
            // txtDenda
            // 
            this.txtDenda.Location = new System.Drawing.Point(413, 252);
            this.txtDenda.Name = "txtDenda";
            this.txtDenda.Size = new System.Drawing.Size(109, 20);
            this.txtDenda.TabIndex = 11;
            // 
            // tgl_balik
            // 
            this.tgl_balik.Location = new System.Drawing.Point(413, 194);
            this.tgl_balik.Name = "tgl_balik";
            this.tgl_balik.Size = new System.Drawing.Size(109, 20);
            this.tgl_balik.TabIndex = 12;
            this.tgl_balik.ValueChanged += new System.EventHandler(this.tgl_balik_ValueChanged);
            this.tgl_balik.RegionChanged += new System.EventHandler(this.tgl_balik_RegionChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(413, 323);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(109, 23);
            this.button4.TabIndex = 13;
            this.button4.Text = "CLEAR";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(413, 381);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(109, 23);
            this.button5.TabIndex = 14;
            this.button5.Text = "BACK";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // form_pengembalian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 411);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.tgl_balik);
            this.Controls.Add(this.txtDenda);
            this.Controls.Add(this.txtJudul);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtCari);
            this.Controls.Add(this.tblPengembalian);
            this.Name = "form_pengembalian";
            this.Text = "form_pengembalian";
            this.Load += new System.EventHandler(this.form_pengembalian_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblPengembalian)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tblPengembalian;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtJudul;
        private System.Windows.Forms.TextBox txtDenda;
        private System.Windows.Forms.DateTimePicker tgl_balik;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}