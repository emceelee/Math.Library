namespace Emceelee.Math.WinForms.Chart
{
    partial class frmChart
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
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnDifferentiate = new System.Windows.Forms.Button();
            this.btnIntegrate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(32, 34);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(926, 497);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // btnDifferentiate
            // 
            this.btnDifferentiate.Location = new System.Drawing.Point(981, 250);
            this.btnDifferentiate.Name = "btnDifferentiate";
            this.btnDifferentiate.Size = new System.Drawing.Size(75, 23);
            this.btnDifferentiate.TabIndex = 1;
            this.btnDifferentiate.Text = "Differentiate";
            this.btnDifferentiate.UseVisualStyleBackColor = true;
            this.btnDifferentiate.Click += new System.EventHandler(this.btnDifferentiate_Click);
            // 
            // btnIntegrate
            // 
            this.btnIntegrate.Location = new System.Drawing.Point(981, 279);
            this.btnIntegrate.Name = "btnIntegrate";
            this.btnIntegrate.Size = new System.Drawing.Size(75, 23);
            this.btnIntegrate.TabIndex = 2;
            this.btnIntegrate.Text = "Integrate";
            this.btnIntegrate.UseVisualStyleBackColor = true;
            this.btnIntegrate.Click += new System.EventHandler(this.btnIntegrate_Click);
            // 
            // frmChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 567);
            this.Controls.Add(this.btnIntegrate);
            this.Controls.Add(this.btnDifferentiate);
            this.Controls.Add(this.chart1);
            this.Name = "frmChart";
            this.Text = "Chart";
            this.Load += new System.EventHandler(this.frmChart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnDifferentiate;
        private System.Windows.Forms.Button btnIntegrate;
    }
}

