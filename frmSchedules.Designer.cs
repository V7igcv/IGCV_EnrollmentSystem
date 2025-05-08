namespace EDP_WinProject102
{
    partial class frmSchedules
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.SchedulesTable = new System.Windows.Forms.DataGridView();
            this.panel18 = new System.Windows.Forms.Panel();
            this.dayofweek = new System.Windows.Forms.ComboBox();
            this.endtime = new System.Windows.Forms.DateTimePicker();
            this.starttime = new System.Windows.Forms.DateTimePicker();
            this.course = new System.Windows.Forms.ComboBox();
            this.instructor = new System.Windows.Forms.ComboBox();
            this.SubmitSchedule = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.sideBar1 = new EDP_WinProject102.SideBar();
            this.topBar1 = new EDP_WinProject102.TopBar();
            this.btnDeleteSchedule = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SchedulesTable)).BeginInit();
            this.panel18.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnDeleteSchedule);
            this.panel1.Controls.Add(this.SchedulesTable);
            this.panel1.Controls.Add(this.panel18);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(201, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1096, 746);
            this.panel1.TabIndex = 17;
            // 
            // SchedulesTable
            // 
            this.SchedulesTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SchedulesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SchedulesTable.Location = new System.Drawing.Point(44, 404);
            this.SchedulesTable.Name = "SchedulesTable";
            this.SchedulesTable.RowHeadersWidth = 51;
            this.SchedulesTable.RowTemplate.Height = 24;
            this.SchedulesTable.Size = new System.Drawing.Size(991, 351);
            this.SchedulesTable.TabIndex = 13;
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel18.Controls.Add(this.dayofweek);
            this.panel18.Controls.Add(this.endtime);
            this.panel18.Controls.Add(this.starttime);
            this.panel18.Controls.Add(this.course);
            this.panel18.Controls.Add(this.instructor);
            this.panel18.Controls.Add(this.SubmitSchedule);
            this.panel18.Controls.Add(this.label8);
            this.panel18.Controls.Add(this.label7);
            this.panel18.Controls.Add(this.label3);
            this.panel18.Controls.Add(this.label2);
            this.panel18.Controls.Add(this.label1);
            this.panel18.Controls.Add(this.label14);
            this.panel18.Location = new System.Drawing.Point(44, 72);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(991, 270);
            this.panel18.TabIndex = 12;
            // 
            // dayofweek
            // 
            this.dayofweek.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dayofweek.FormattingEnabled = true;
            this.dayofweek.Location = new System.Drawing.Point(680, 101);
            this.dayofweek.Name = "dayofweek";
            this.dayofweek.Size = new System.Drawing.Size(227, 30);
            this.dayofweek.TabIndex = 35;
            // 
            // endtime
            // 
            this.endtime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endtime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.endtime.Location = new System.Drawing.Point(411, 169);
            this.endtime.Name = "endtime";
            this.endtime.ShowUpDown = true;
            this.endtime.Size = new System.Drawing.Size(200, 28);
            this.endtime.TabIndex = 34;
            this.endtime.Value = new System.DateTime(2025, 4, 13, 23, 8, 29, 0);
            // 
            // starttime
            // 
            this.starttime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.starttime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.starttime.Location = new System.Drawing.Point(411, 101);
            this.starttime.Name = "starttime";
            this.starttime.ShowUpDown = true;
            this.starttime.Size = new System.Drawing.Size(200, 28);
            this.starttime.TabIndex = 33;
            this.starttime.Value = new System.DateTime(2025, 4, 13, 23, 8, 29, 0);
            // 
            // course
            // 
            this.course.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.course.FormattingEnabled = true;
            this.course.Location = new System.Drawing.Point(51, 169);
            this.course.Name = "course";
            this.course.Size = new System.Drawing.Size(290, 30);
            this.course.TabIndex = 32;
            // 
            // instructor
            // 
            this.instructor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructor.FormattingEnabled = true;
            this.instructor.Location = new System.Drawing.Point(51, 101);
            this.instructor.Name = "instructor";
            this.instructor.Size = new System.Drawing.Size(290, 30);
            this.instructor.TabIndex = 31;
            // 
            // SubmitSchedule
            // 
            this.SubmitSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.SubmitSchedule.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubmitSchedule.ForeColor = System.Drawing.SystemColors.Control;
            this.SubmitSchedule.Location = new System.Drawing.Point(695, 169);
            this.SubmitSchedule.Name = "SubmitSchedule";
            this.SubmitSchedule.Size = new System.Drawing.Size(202, 34);
            this.SubmitSchedule.TabIndex = 30;
            this.SubmitSchedule.Text = "Submit";
            this.SubmitSchedule.UseVisualStyleBackColor = false;
            this.SubmitSchedule.Click += new System.EventHandler(this.SubmitSchedule_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(407, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 22);
            this.label8.TabIndex = 21;
            this.label8.Text = "End Time";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(407, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 22);
            this.label7.TabIndex = 20;
            this.label7.Text = "Start Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(676, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 22);
            this.label3.TabIndex = 17;
            this.label3.Text = "Day of Week";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 22);
            this.label2.TabIndex = 16;
            this.label2.Text = "Course";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 22);
            this.label1.TabIndex = 15;
            this.label1.Text = "Instructor";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Bahnschrift Condensed", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(42, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(126, 29);
            this.label14.TabIndex = 13;
            this.label14.Text = "ADD SCHEDULE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(37, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 40);
            this.label5.TabIndex = 9;
            this.label5.Text = "SCHEDULES";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // sideBar1
            // 
            this.sideBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.sideBar1.Location = new System.Drawing.Point(0, 0);
            this.sideBar1.Name = "sideBar1";
            this.sideBar1.Size = new System.Drawing.Size(203, 831);
            this.sideBar1.TabIndex = 19;
            // 
            // topBar1
            // 
            this.topBar1.Location = new System.Drawing.Point(201, 0);
            this.topBar1.Name = "topBar1";
            this.topBar1.Size = new System.Drawing.Size(1097, 84);
            this.topBar1.TabIndex = 18;
            // 
            // btnDeleteSchedule
            // 
            this.btnDeleteSchedule.BackColor = System.Drawing.SystemColors.Control;
            this.btnDeleteSchedule.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteSchedule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.btnDeleteSchedule.Location = new System.Drawing.Point(856, 362);
            this.btnDeleteSchedule.Name = "btnDeleteSchedule";
            this.btnDeleteSchedule.Size = new System.Drawing.Size(179, 36);
            this.btnDeleteSchedule.TabIndex = 38;
            this.btnDeleteSchedule.Text = "Delete Selected";
            this.btnDeleteSchedule.UseVisualStyleBackColor = false;
            this.btnDeleteSchedule.Click += new System.EventHandler(this.btnDeleteSchedule_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.SystemColors.Control;
            this.btnEdit.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.btnEdit.Location = new System.Drawing.Point(671, 362);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(179, 36);
            this.btnEdit.TabIndex = 41;
            this.btnEdit.Text = "Edit Selected";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // frmSchedules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 831);
            this.Controls.Add(this.sideBar1);
            this.Controls.Add(this.topBar1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSchedules";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schedules";
            this.Load += new System.EventHandler(this.frmSchedules_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SchedulesTable)).EndInit();
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView SchedulesTable;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label5;
        private TopBar topBar1;
        private SideBar sideBar1;
        private System.Windows.Forms.Button SubmitSchedule;
        private System.Windows.Forms.ComboBox course;
        private System.Windows.Forms.ComboBox instructor;
        private System.Windows.Forms.ComboBox dayofweek;
        private System.Windows.Forms.DateTimePicker endtime;
        private System.Windows.Forms.DateTimePicker starttime;
        private System.Windows.Forms.Button btnDeleteSchedule;
        private System.Windows.Forms.Button btnEdit;
    }
}