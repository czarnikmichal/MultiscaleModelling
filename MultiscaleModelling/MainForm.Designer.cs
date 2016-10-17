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
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(420, 10);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(153, 23);
            this.start.TabIndex = 0;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // pause
            // 
            this.pause.Location = new System.Drawing.Point(420, 40);
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(153, 23);
            this.pause.TabIndex = 1;
            this.pause.Text = "Pause";
            this.pause.UseVisualStyleBackColor = true;
            this.pause.Click += new System.EventHandler(this.pause_Click);
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(419, 69);
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
            this.periodic.Location = new System.Drawing.Point(420, 99);
            this.periodic.Name = "periodic";
            this.periodic.Size = new System.Drawing.Size(164, 17);
            this.periodic.TabIndex = 3;
            this.periodic.Text = "Periodic Boundary Contidions";
            this.periodic.UseVisualStyleBackColor = true;
            this.periodic.UseWaitCursor = true;
            // 
            // generate
            // 
            this.generate.Location = new System.Drawing.Point(420, 148);
            this.generate.Name = "generate";
            this.generate.Size = new System.Drawing.Size(153, 23);
            this.generate.TabIndex = 4;
            this.generate.Text = "Generate";
            this.generate.UseVisualStyleBackColor = true;
            this.generate.Click += new System.EventHandler(this.generate_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(420, 122);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(153, 20);
            this.textBox1.TabIndex = 5;
            // 
            // methods
            // 
            this.methods.FormattingEnabled = true;
            this.methods.Location = new System.Drawing.Point(419, 178);
            this.methods.Name = "methods";
            this.methods.Size = new System.Drawing.Size(154, 21);
            this.methods.TabIndex = 6;
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.White;
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Location = new System.Drawing.Point(10, 10);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(400, 400);
            this.panel.TabIndex = 7;
            this.panel.Click += new System.EventHandler(this.panel_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(585, 444);
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
    }
}

