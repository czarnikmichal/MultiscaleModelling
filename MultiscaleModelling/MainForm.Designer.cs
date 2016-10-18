namespace MultiscaleModelling
{
    partial class MainForm
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
            this.start = new System.Windows.Forms.Button();
            this.pause = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.periodic = new System.Windows.Forms.CheckBox();
            this.generate = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.methods = new System.Windows.Forms.ComboBox();
            this.panel = new System.Windows.Forms.Panel();
            this.squareIncl = new System.Windows.Forms.CheckBox();
            this.circleIncl = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.panelX = new System.Windows.Forms.TextBox();
            this.panelY = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(420, 30);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(153, 23);
            this.start.TabIndex = 0;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // pause
            // 
            this.pause.Location = new System.Drawing.Point(420, 60);
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(153, 23);
            this.pause.TabIndex = 1;
            this.pause.Text = "Pause";
            this.pause.UseVisualStyleBackColor = true;
            this.pause.Click += new System.EventHandler(this.pause_Click);
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(419, 90);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(154, 23);
            this.stop.TabIndex = 2;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // periodic
            // 
            this.periodic.AutoSize = true;
            this.periodic.Location = new System.Drawing.Point(420, 120);
            this.periodic.Name = "periodic";
            this.periodic.Size = new System.Drawing.Size(164, 17);
            this.periodic.TabIndex = 3;
            this.periodic.Text = "Periodic Boundary Contidions";
            this.periodic.UseVisualStyleBackColor = true;
            this.periodic.UseWaitCursor = true;
            // 
            // generate
            // 
            this.generate.Location = new System.Drawing.Point(420, 170);
            this.generate.Name = "generate";
            this.generate.Size = new System.Drawing.Size(153, 23);
            this.generate.TabIndex = 4;
            this.generate.Text = "Generate";
            this.generate.UseVisualStyleBackColor = true;
            this.generate.Click += new System.EventHandler(this.generate_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(420, 140);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(153, 20);
            this.textBox1.TabIndex = 5;
            // 
            // methods
            // 
            this.methods.FormattingEnabled = true;
            this.methods.Location = new System.Drawing.Point(419, 200);
            this.methods.Name = "methods";
            this.methods.Size = new System.Drawing.Size(154, 21);
            this.methods.TabIndex = 6;
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.White;
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Location = new System.Drawing.Point(10, 30);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(400, 400);
            this.panel.TabIndex = 7;
            this.panel.Click += new System.EventHandler(this.panel_Click);
            // 
            // squareIncl
            // 
            this.squareIncl.AutoSize = true;
            this.squareIncl.Checked = true;
            this.squareIncl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.squareIncl.Location = new System.Drawing.Point(420, 230);
            this.squareIncl.Name = "squareIncl";
            this.squareIncl.Size = new System.Drawing.Size(105, 17);
            this.squareIncl.TabIndex = 8;
            this.squareIncl.Text = "Square Inclusion";
            this.squareIncl.UseVisualStyleBackColor = true;
            this.squareIncl.Click += new System.EventHandler(this.squareIncl_Click);
            // 
            // circleIncl
            // 
            this.circleIncl.AutoSize = true;
            this.circleIncl.Location = new System.Drawing.Point(420, 250);
            this.circleIncl.Name = "circleIncl";
            this.circleIncl.Size = new System.Drawing.Size(97, 17);
            this.circleIncl.TabIndex = 9;
            this.circleIncl.Text = "Circle Inclusion";
            this.circleIncl.UseVisualStyleBackColor = true;
            this.circleIncl.Click += new System.EventHandler(this.circleIncl_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(420, 270);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(153, 20);
            this.textBox2.TabIndex = 10;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(420, 300);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(153, 20);
            this.textBox3.TabIndex = 11;
            // 
            // panelX
            // 
            this.panelX.Location = new System.Drawing.Point(62, 4);
            this.panelX.Name = "panelX";
            this.panelX.Size = new System.Drawing.Size(100, 20);
            this.panelX.TabIndex = 12;
            this.panelX.TextChanged += new System.EventHandler(this.panelX_TextChanged);
            // 
            // panelY
            // 
            this.panelY.Location = new System.Drawing.Point(186, 4);
            this.panelY.Name = "panelY";
            this.panelY.Size = new System.Drawing.Size(100, 20);
            this.panelY.TabIndex = 13;
            this.panelY.TextChanged += new System.EventHandler(this.panelY_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 7);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "x";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(585, 444);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelY);
            this.Controls.Add(this.panelX);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.circleIncl);
            this.Controls.Add(this.squareIncl);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.methods);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.generate);
            this.Controls.Add(this.periodic);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.pause);
            this.Controls.Add(this.start);
            this.Name = "MainForm";
            this.Text = "CA";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button pause;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.CheckBox periodic;
        private System.Windows.Forms.Button generate;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox methods;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.CheckBox squareIncl;
        private System.Windows.Forms.CheckBox circleIncl;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox panelX;
        private System.Windows.Forms.TextBox panelY;
        private System.Windows.Forms.Label label1;
    }
}

