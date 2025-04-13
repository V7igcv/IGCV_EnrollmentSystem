namespace EDP_WinProject102
{
    partial class frmDashboard
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
            this.panel12 = new System.Windows.Forms.Panel();
            this.topBar1 = new EDP_WinProject102.TopBar();
            this.label5 = new System.Windows.Forms.Label();
            this.panel19 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label15 = new System.Windows.Forms.Label();
            this.panel17 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel18 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label14 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.sideBar1 = new EDP_WinProject102.SideBar();
            this.panel12.SuspendLayout();
            this.panel19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel17.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel14.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel12
            // 
            this.panel12.AutoScroll = true;
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel12.Controls.Add(this.topBar1);
            this.panel12.Controls.Add(this.label5);
            this.panel12.Controls.Add(this.panel19);
            this.panel12.Controls.Add(this.panel17);
            this.panel12.Controls.Add(this.panel16);
            this.panel12.Controls.Add(this.panel15);
            this.panel12.Controls.Add(this.panel18);
            this.panel12.Controls.Add(this.panel14);
            this.panel12.Location = new System.Drawing.Point(201, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(1100, 837);
            this.panel12.TabIndex = 1;
            this.panel12.Paint += new System.Windows.Forms.PaintEventHandler(this.panel12_Paint);
            // 
            // topBar1
            // 
            this.topBar1.Location = new System.Drawing.Point(0, 0);
            this.topBar1.Name = "topBar1";
            this.topBar1.Size = new System.Drawing.Size(1097, 84);
            this.topBar1.TabIndex = 8;
            this.topBar1.Load += new System.EventHandler(this.topBar1_Load);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(43, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 40);
            this.label5.TabIndex = 7;
            this.label5.Text = "DASHBOARD";
            // 
            // panel19
            // 
            this.panel19.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel19.Controls.Add(this.dataGridView2);
            this.panel19.Controls.Add(this.label15);
            this.panel19.Location = new System.Drawing.Point(50, 437);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(1012, 352);
            this.panel19.TabIndex = 6;
            // 
            // dataGridView2
            // 
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(15, 53);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(983, 283);
            this.dataGridView2.TabIndex = 14;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(11, 13);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(190, 24);
            this.label15.TabIndex = 13;
            this.label15.Text = "Instructors per Department";
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel17.Controls.Add(this.label13);
            this.panel17.Controls.Add(this.label9);
            this.panel17.Location = new System.Drawing.Point(302, 296);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(229, 120);
            this.panel17.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Bahnschrift Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(177, 63);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 40);
            this.label13.TabIndex = 12;
            this.label13.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 24);
            this.label9.TabIndex = 10;
            this.label9.Text = "Total Instructors";
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel16.Controls.Add(this.label12);
            this.panel16.Controls.Add(this.label7);
            this.panel16.Location = new System.Drawing.Point(302, 159);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(229, 120);
            this.panel16.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Bahnschrift Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(177, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 40);
            this.label12.TabIndex = 11;
            this.label12.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 24);
            this.label7.TabIndex = 9;
            this.label7.Text = "Total Courses";
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel15.Controls.Add(this.label11);
            this.panel15.Controls.Add(this.label8);
            this.panel15.Location = new System.Drawing.Point(50, 296);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(229, 120);
            this.panel15.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Bahnschrift Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(169, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 40);
            this.label11.TabIndex = 10;
            this.label11.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 24);
            this.label8.TabIndex = 9;
            this.label8.Text = "Total Students";
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel18.Controls.Add(this.dataGridView1);
            this.panel18.Controls.Add(this.label14);
            this.panel18.Location = new System.Drawing.Point(566, 159);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(496, 257);
            this.panel18.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 57);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(466, 184);
            this.dataGridView1.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(12, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(179, 24);
            this.label14.TabIndex = 12;
            this.label14.Text = "Total Students per Course";
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel14.Controls.Add(this.label10);
            this.panel14.Controls.Add(this.label6);
            this.panel14.Location = new System.Drawing.Point(50, 159);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(229, 120);
            this.panel14.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Bahnschrift Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(169, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 40);
            this.label10.TabIndex = 9;
            this.label10.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 24);
            this.label6.TabIndex = 8;
            this.label6.Text = "Total Enrollments";
            // 
            // sideBar1
            // 
            this.sideBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.sideBar1.Location = new System.Drawing.Point(0, 1);
            this.sideBar1.Name = "sideBar1";
            this.sideBar1.Size = new System.Drawing.Size(203, 831);
            this.sideBar1.TabIndex = 2;
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 831);
            this.Controls.Add(this.sideBar1);
            this.Controls.Add(this.panel12);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enrollment Dashbaord";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel19.ResumeLayout(false);
            this.panel19.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private SideBar sideBar1;
        private TopBar topBar1;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label15;
    }
}

