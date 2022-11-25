namespace PathfindingVisualizer
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
        /// Removed unnecessary button functions
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Visualize_button = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.OcistiPut_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NoNode_label = new System.Windows.Forms.Label();
            this.NoVisited_label = new System.Windows.Forms.Label();
            this.PathLength_label = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.LavenderBlush;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "BFS"});
            this.comboBox1.Location = new System.Drawing.Point(8, 24);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(128, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 24;
            // 
            // Visualize_button
            // 
            this.Visualize_button.BackColor = System.Drawing.Color.AliceBlue;
            this.Visualize_button.FlatAppearance.BorderColor = System.Drawing.Color.Salmon;
            this.Visualize_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Salmon;
            this.Visualize_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Salmon;
            this.Visualize_button.Location = new System.Drawing.Point(142, 23);
            this.Visualize_button.Margin = new System.Windows.Forms.Padding(2);
            this.Visualize_button.Name = "Visualize_button";
            this.Visualize_button.Size = new System.Drawing.Size(85, 22);
            this.Visualize_button.TabIndex = 2;
            this.Visualize_button.Text = "Visualize";
            this.Visualize_button.UseVisualStyleBackColor = false;
            this.Visualize_button.Click += new System.EventHandler(this.Visualize_button_click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 23;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(8, 112);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 240);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // OcistiPut_button
            // 
            this.OcistiPut_button.Location = new System.Drawing.Point(0, 0);
            this.OcistiPut_button.Name = "OcistiPut_button";
            this.OcistiPut_button.Size = new System.Drawing.Size(75, 23);
            this.OcistiPut_button.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 20;
            // 
            // NoNode_label
            // 
            this.NoNode_label.Location = new System.Drawing.Point(0, 0);
            this.NoNode_label.Name = "NoNode_label";
            this.NoNode_label.Size = new System.Drawing.Size(100, 23);
            this.NoNode_label.TabIndex = 18;
            // 
            // NoVisited_label
            // 
            this.NoVisited_label.Location = new System.Drawing.Point(0, 0);
            this.NoVisited_label.Name = "NoVisited_label";
            this.NoVisited_label.Size = new System.Drawing.Size(100, 23);
            this.NoVisited_label.TabIndex = 16;
            // 
            // PathLength_label
            // 
            this.PathLength_label.Location = new System.Drawing.Point(0, 0);
            this.PathLength_label.Name = "PathLength_label";
            this.PathLength_label.Size = new System.Drawing.Size(100, 23);
            this.PathLength_label.TabIndex = 17;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(495, 482);
            this.Controls.Add(this.NoVisited_label);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Visualize_button);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.PathLength_label);
            this.Controls.Add(this.NoNode_label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OcistiPut_button);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "BFS Visualizer - Quijano";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Visualize_button;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button OcistiPut_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label NoNode_label;
        private System.Windows.Forms.Label NoVisited_label;
        private System.Windows.Forms.Label PathLength_label;
        private System.Windows.Forms.Timer timer1;
    }
}

