namespace perpus
{
    partial class chart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button1 = new System.Windows.Forms.Button();
            this.chartUser = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartBuku = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBuku)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(40, 326);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chartUser
            // 
            chartArea1.Name = "ChartArea1";
            this.chartUser.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartUser.Legends.Add(legend1);
            this.chartUser.Location = new System.Drawing.Point(12, 12);
            this.chartUser.Name = "chartUser";
            series1.ChartArea = "ChartArea1";
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "Petugas";
            series2.ChartArea = "ChartArea1";
            series2.IsXValueIndexed = true;
            series2.Legend = "Legend1";
            series2.Name = "Anggota";
            series3.ChartArea = "ChartArea1";
            series3.IsXValueIndexed = true;
            series3.Legend = "Legend1";
            series3.Name = "Buku";
            series4.ChartArea = "ChartArea1";
            series4.IsXValueIndexed = true;
            series4.Legend = "Legend1";
            series4.Name = "Peminjaman";
            this.chartUser.Series.Add(series1);
            this.chartUser.Series.Add(series2);
            this.chartUser.Series.Add(series3);
            this.chartUser.Series.Add(series4);
            this.chartUser.Size = new System.Drawing.Size(22, 263);
            this.chartUser.TabIndex = 1;
            this.chartUser.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "Perpus Chart";
            this.chartUser.Titles.Add(title1);
            // 
            // chartBuku
            // 
            chartArea2.Name = "ChartArea1";
            this.chartBuku.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartBuku.Legends.Add(legend2);
            this.chartBuku.Location = new System.Drawing.Point(40, 12);
            this.chartBuku.Name = "chartBuku";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Tanggal";
            series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            this.chartBuku.Series.Add(series5);
            this.chartBuku.Size = new System.Drawing.Size(600, 300);
            this.chartBuku.TabIndex = 2;
            this.chartBuku.Text = "chart1";
            // 
            // dateStart
            // 
            this.dateStart.Location = new System.Drawing.Point(646, 25);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(190, 20);
            this.dateStart.TabIndex = 3;
            this.dateStart.ValueChanged += new System.EventHandler(this.dateStart_ValueChanged);
            // 
            // dateEnd
            // 
            this.dateEnd.Location = new System.Drawing.Point(646, 74);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(190, 20);
            this.dateEnd.TabIndex = 4;
            this.dateEnd.ValueChanged += new System.EventHandler(this.dateEnd_ValueChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(667, 124);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(141, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Filter";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 361);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dateEnd);
            this.Controls.Add(this.dateStart);
            this.Controls.Add(this.chartBuku);
            this.Controls.Add(this.chartUser);
            this.Controls.Add(this.button1);
            this.Name = "chart";
            this.Text = "chart";
            this.Load += new System.EventHandler(this.chart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBuku)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartUser;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBuku;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.Button button2;
    }
}