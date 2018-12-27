namespace SampleApp
{
    partial class SampleApp
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonStartServer = new System.Windows.Forms.Button();
            this.numericUpDownLat = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownLon = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownPort = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownRate = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownHeading = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownSpeed = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownTWS = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownTWA = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTWS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTWA)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStartServer
            // 
            this.buttonStartServer.Location = new System.Drawing.Point(370, 184);
            this.buttonStartServer.Name = "buttonStartServer";
            this.buttonStartServer.Size = new System.Drawing.Size(75, 23);
            this.buttonStartServer.TabIndex = 0;
            this.buttonStartServer.Text = "Start server";
            this.buttonStartServer.UseVisualStyleBackColor = true;
            this.buttonStartServer.Click += new System.EventHandler(this.buttonStartServer_Click);
            // 
            // numericUpDownLat
            // 
            this.numericUpDownLat.DecimalPlaces = 6;
            this.numericUpDownLat.Location = new System.Drawing.Point(44, 105);
            this.numericUpDownLat.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.numericUpDownLat.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            this.numericUpDownLat.Name = "numericUpDownLat";
            this.numericUpDownLat.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownLat.TabIndex = 1;
            this.numericUpDownLat.ValueChanged += new System.EventHandler(this.numericUpDownLat_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lat";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Lon";
            // 
            // numericUpDownLon
            // 
            this.numericUpDownLon.DecimalPlaces = 6;
            this.numericUpDownLon.Location = new System.Drawing.Point(44, 131);
            this.numericUpDownLon.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericUpDownLon.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.numericUpDownLon.Name = "numericUpDownLon";
            this.numericUpDownLon.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownLon.TabIndex = 3;
            this.numericUpDownLon.ValueChanged += new System.EventHandler(this.numericUpDownLon_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tcp Port";
            // 
            // numericUpDownPort
            // 
            this.numericUpDownPort.Location = new System.Drawing.Point(70, 24);
            this.numericUpDownPort.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownPort.Name = "numericUpDownPort";
            this.numericUpDownPort.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownPort.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(212, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "NMEA send rate (ms)";
            // 
            // numericUpDownRate
            // 
            this.numericUpDownRate.Location = new System.Drawing.Point(352, 24);
            this.numericUpDownRate.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRate.Name = "numericUpDownRate";
            this.numericUpDownRate.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownRate.TabIndex = 7;
            this.numericUpDownRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(203, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Heading";
            // 
            // numericUpDownHeading
            // 
            this.numericUpDownHeading.DecimalPlaces = 1;
            this.numericUpDownHeading.Location = new System.Drawing.Point(256, 103);
            this.numericUpDownHeading.Maximum = new decimal(new int[] {
            359,
            0,
            0,
            0});
            this.numericUpDownHeading.Name = "numericUpDownHeading";
            this.numericUpDownHeading.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownHeading.TabIndex = 9;
            this.numericUpDownHeading.ValueChanged += new System.EventHandler(this.numericUpDownHeading_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(177, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Speed (knots)";
            // 
            // numericUpDownSpeed
            // 
            this.numericUpDownSpeed.DecimalPlaces = 1;
            this.numericUpDownSpeed.Location = new System.Drawing.Point(256, 131);
            this.numericUpDownSpeed.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownSpeed.Name = "numericUpDownSpeed";
            this.numericUpDownSpeed.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownSpeed.TabIndex = 11;
            this.numericUpDownSpeed.ValueChanged += new System.EventHandler(this.numericUpDownSpeed_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(382, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "True Wind speed (knots)";
            // 
            // numericUpDownTWS
            // 
            this.numericUpDownTWS.DecimalPlaces = 1;
            this.numericUpDownTWS.Location = new System.Drawing.Point(512, 129);
            this.numericUpDownTWS.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownTWS.Name = "numericUpDownTWS";
            this.numericUpDownTWS.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownTWS.TabIndex = 13;
            this.numericUpDownTWS.ValueChanged += new System.EventHandler(this.numericUpDownTWS_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(389, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "True Wind angle (360º)";
            // 
            // numericUpDownTWA
            // 
            this.numericUpDownTWA.DecimalPlaces = 1;
            this.numericUpDownTWA.Location = new System.Drawing.Point(512, 103);
            this.numericUpDownTWA.Maximum = new decimal(new int[] {
            359,
            0,
            0,
            0});
            this.numericUpDownTWA.Name = "numericUpDownTWA";
            this.numericUpDownTWA.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownTWA.TabIndex = 15;
            this.numericUpDownTWA.ValueChanged += new System.EventHandler(this.numericUpDownTWA_ValueChanged);
            // 
            // SampleApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numericUpDownTWA);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericUpDownTWS);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericUpDownSpeed);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDownHeading);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDownRate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDownPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownLon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownLat);
            this.Controls.Add(this.buttonStartServer);
            this.Name = "SampleApp";
            this.Text = "Sample App";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SampleApp_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTWS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTWA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStartServer;
        private System.Windows.Forms.NumericUpDown numericUpDownLat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownLon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownHeading;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownSpeed;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownTWS;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDownTWA;
    }
}

