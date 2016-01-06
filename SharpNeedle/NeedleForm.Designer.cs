namespace SharpNeedle
{
    partial class NeedleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NeedleForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLoadProcesses = new System.Windows.Forms.Button();
            this.btnInjectPayload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblThreads = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblModuleBase = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listProcesses = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textboxDomain = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textboxPayload = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.textboxArgs = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(76)))), ((int)(((byte)(99)))));
            this.panel1.Controls.Add(this.btnLoadProcesses);
            this.panel1.Controls.Add(this.btnInjectPayload);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(190, 383);
            this.panel1.TabIndex = 0;
            // 
            // btnLoadProcesses
            // 
            this.btnLoadProcesses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadProcesses.ForeColor = System.Drawing.Color.White;
            this.btnLoadProcesses.Location = new System.Drawing.Point(5, 191);
            this.btnLoadProcesses.Name = "btnLoadProcesses";
            this.btnLoadProcesses.Size = new System.Drawing.Size(180, 37);
            this.btnLoadProcesses.TabIndex = 2;
            this.btnLoadProcesses.Text = "Reload Processes";
            this.btnLoadProcesses.UseVisualStyleBackColor = true;
            this.btnLoadProcesses.Click += new System.EventHandler(this.btnLoadProcesses_Click);
            // 
            // btnInjectPayload
            // 
            this.btnInjectPayload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInjectPayload.ForeColor = System.Drawing.Color.White;
            this.btnInjectPayload.Location = new System.Drawing.Point(5, 305);
            this.btnInjectPayload.Name = "btnInjectPayload";
            this.btnInjectPayload.Size = new System.Drawing.Size(180, 37);
            this.btnInjectPayload.TabIndex = 1;
            this.btnInjectPayload.Text = "Inject Payload";
            this.btnInjectPayload.UseVisualStyleBackColor = true;
            this.btnInjectPayload.Click += new System.EventHandler(this.btnInjectPayload_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(41, 361);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "SharpNeedle © 2016";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(62)))), ((int)(((byte)(83)))));
            this.panel2.Location = new System.Drawing.Point(5, 350);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(180, 5);
            this.panel2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SharpNeedle.Properties.Resources.SharpNeedleLogo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(190, 190);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.Controls.Add(this.lblThreads);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.lblModuleBase);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.listProcesses);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(190, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(520, 136);
            this.panel3.TabIndex = 1;
            // 
            // lblThreads
            // 
            this.lblThreads.AutoSize = true;
            this.lblThreads.Location = new System.Drawing.Point(312, 32);
            this.lblThreads.Name = "lblThreads";
            this.lblThreads.Size = new System.Drawing.Size(35, 20);
            this.lblThreads.TabIndex = 7;
            this.lblThreads.Text = "N/A";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(200, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "# of Threads:";
            // 
            // lblModuleBase
            // 
            this.lblModuleBase.AutoSize = true;
            this.lblModuleBase.Location = new System.Drawing.Point(312, 9);
            this.lblModuleBase.Name = "lblModuleBase";
            this.lblModuleBase.Size = new System.Drawing.Size(35, 20);
            this.lblModuleBase.TabIndex = 5;
            this.lblModuleBase.Text = "N/A";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(200, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Module Base:";
            // 
            // listProcesses
            // 
            this.listProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listProcesses.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listProcesses.Location = new System.Drawing.Point(10, 32);
            this.listProcesses.MultiSelect = false;
            this.listProcesses.Name = "listProcesses";
            this.listProcesses.Size = new System.Drawing.Size(174, 95);
            this.listProcesses.TabIndex = 3;
            this.listProcesses.UseCompatibleStateImageBehavior = false;
            this.listProcesses.View = System.Windows.Forms.View.Details;
            this.listProcesses.SelectedIndexChanged += new System.EventHandler(this.listProcesses_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 140;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Target Process";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SharpNeedle.Properties.Resources.SharpNeedleLogo;
            this.pictureBox2.Location = new System.Drawing.Point(616, 298);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(82, 76);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "SharpDomain File Path";
            // 
            // textboxDomain
            // 
            this.textboxDomain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxDomain.Location = new System.Drawing.Point(189, 9);
            this.textboxDomain.Name = "textboxDomain";
            this.textboxDomain.Size = new System.Drawing.Size(319, 26);
            this.textboxDomain.TabIndex = 4;
            this.textboxDomain.Text = "SharpDomain.dll";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Silver;
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.textboxDomain);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(190, 136);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(520, 45);
            this.panel4.TabIndex = 5;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel5.Controls.Add(this.textboxPayload);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(190, 181);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(520, 45);
            this.panel5.TabIndex = 6;
            // 
            // textboxPayload
            // 
            this.textboxPayload.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxPayload.Location = new System.Drawing.Point(189, 9);
            this.textboxPayload.Name = "textboxPayload";
            this.textboxPayload.Size = new System.Drawing.Size(319, 26);
            this.textboxPayload.TabIndex = 5;
            this.textboxPayload.Text = "SharpPayload.dll";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Payload File Path";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Silver;
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.textboxArgs);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(190, 226);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(520, 45);
            this.panel6.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Payload Arguments";
            // 
            // textboxArgs
            // 
            this.textboxArgs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxArgs.Location = new System.Drawing.Point(189, 9);
            this.textboxArgs.Name = "textboxArgs";
            this.textboxArgs.Size = new System.Drawing.Size(319, 26);
            this.textboxArgs.TabIndex = 4;
            this.textboxArgs.Text = "-SharpArgument -ArgumentTwo";
            // 
            // NeedleForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(710, 383);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NeedleForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SharpNeedle - C#/.Net Injection Proof of Concept";
            this.Load += new System.EventHandler(this.NeedleForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnInjectPayload;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnLoadProcesses;
        private System.Windows.Forms.ListView listProcesses;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textboxDomain;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox textboxPayload;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textboxArgs;
        private System.Windows.Forms.Label lblModuleBase;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblThreads;
        private System.Windows.Forms.Label label7;
    }
}