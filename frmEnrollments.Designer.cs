namespace EDP_WinProject102
{
    partial class frmEnrollments
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
            this.EnrollmentsTable = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnDeleteEnrollment = new System.Windows.Forms.Button();
            this.panel18 = new System.Windows.Forms.Panel();
            this.student_no = new System.Windows.Forms.TextBox();
            this.course = new System.Windows.Forms.ComboBox();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.SubmitEnrollment = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.sideBar1 = new EDP_WinProject102.SideBar();
            this.topBar1 = new EDP_WinProject102.TopBar();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.EnrollmentsTable)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel18.SuspendLayout();
            this.SuspendLayout();
            // 
            // EnrollmentsTable
            // 
            this.EnrollmentsTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EnrollmentsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EnrollmentsTable.Location = new System.Drawing.Point(44, 349);
            this.EnrollmentsTable.Name = "EnrollmentsTable";
            this.EnrollmentsTable.RowHeadersWidth = 51;
            this.EnrollmentsTable.RowTemplate.Height = 24;
            this.EnrollmentsTable.Size = new System.Drawing.Size(991, 405);
            this.EnrollmentsTable.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(37, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 40);
            this.label5.TabIndex = 8;
            this.label5.Text = "ENROLLMENTS";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.btnExportToExcel);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.btnDeleteEnrollment);
            this.panel1.Controls.Add(this.panel18);
            this.panel1.Controls.Add(this.EnrollmentsTable);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(202, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1096, 746);
            this.panel1.TabIndex = 10;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(44, 310);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(231, 28);
            this.txtSearch.TabIndex = 37;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnDeleteEnrollment
            // 
            this.btnDeleteEnrollment.BackColor = System.Drawing.SystemColors.Control;
            this.btnDeleteEnrollment.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteEnrollment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.btnDeleteEnrollment.Location = new System.Drawing.Point(856, 307);
            this.btnDeleteEnrollment.Name = "btnDeleteEnrollment";
            this.btnDeleteEnrollment.Size = new System.Drawing.Size(179, 36);
            this.btnDeleteEnrollment.TabIndex = 34;
            this.btnDeleteEnrollment.Text = "Delete Selected";
            this.btnDeleteEnrollment.UseVisualStyleBackColor = false;
            this.btnDeleteEnrollment.Click += new System.EventHandler(this.btnDeleteEnrollment_Click);
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel18.Controls.Add(this.student_no);
            this.panel18.Controls.Add(this.course);
            this.panel18.Controls.Add(this.date);
            this.panel18.Controls.Add(this.SubmitEnrollment);
            this.panel18.Controls.Add(this.label4);
            this.panel18.Controls.Add(this.label3);
            this.panel18.Controls.Add(this.label1);
            this.panel18.Controls.Add(this.label14);
            this.panel18.Location = new System.Drawing.Point(44, 72);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(991, 209);
            this.panel18.TabIndex = 11;
            // 
            // student_no
            // 
            this.student_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.student_no.Location = new System.Drawing.Point(50, 101);
            this.student_no.Name = "student_no";
            this.student_no.Size = new System.Drawing.Size(317, 28);
            this.student_no.TabIndex = 33;
            // 
            // course
            // 
            this.course.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.course.FormattingEnabled = true;
            this.course.Location = new System.Drawing.Point(392, 101);
            this.course.Name = "course";
            this.course.Size = new System.Drawing.Size(293, 30);
            this.course.TabIndex = 32;
            // 
            // date
            // 
            this.date.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date.Location = new System.Drawing.Point(715, 101);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(200, 28);
            this.date.TabIndex = 30;
            this.date.Value = new System.DateTime(2025, 4, 13, 23, 8, 29, 0);
            // 
            // SubmitEnrollment
            // 
            this.SubmitEnrollment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.SubmitEnrollment.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubmitEnrollment.ForeColor = System.Drawing.SystemColors.Control;
            this.SubmitEnrollment.Location = new System.Drawing.Point(715, 147);
            this.SubmitEnrollment.Name = "SubmitEnrollment";
            this.SubmitEnrollment.Size = new System.Drawing.Size(202, 34);
            this.SubmitEnrollment.TabIndex = 29;
            this.SubmitEnrollment.Text = "Submit";
            this.SubmitEnrollment.UseVisualStyleBackColor = false;
            this.SubmitEnrollment.Click += new System.EventHandler(this.SubmitEnrollment_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(714, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 22);
            this.label4.TabIndex = 18;
            this.label4.Text = "Enrollment Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(388, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 22);
            this.label3.TabIndex = 17;
            this.label3.Text = "Course";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 22);
            this.label1.TabIndex = 15;
            this.label1.Text = "Student Number";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Bahnschrift Condensed", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(45, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(145, 29);
            this.label14.TabIndex = 13;
            this.label14.Text = "ENROLL STUDENT";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // sideBar1
            // 
            this.sideBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.sideBar1.Location = new System.Drawing.Point(0, 0);
            this.sideBar1.Name = "sideBar1";
            this.sideBar1.Size = new System.Drawing.Size(203, 831);
            this.sideBar1.TabIndex = 0;
            // 
            // topBar1
            // 
            this.topBar1.Location = new System.Drawing.Point(202, 0);
            this.topBar1.Name = "topBar1";
            this.topBar1.Size = new System.Drawing.Size(1097, 84);
            this.topBar1.TabIndex = 1;
            this.topBar1.Load += new System.EventHandler(this.topBar1_Load);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.BackColor = System.Drawing.SystemColors.Control;
            this.btnExportToExcel.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportToExcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.btnExportToExcel.Location = new System.Drawing.Point(856, 18);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(179, 36);
            this.btnExportToExcel.TabIndex = 45;
            this.btnExportToExcel.Text = "Export To MS Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = false;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // frmEnrollments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 831);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sideBar1);
            this.Controls.Add(this.topBar1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEnrollments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enrollments";
            this.Load += new System.EventHandler(this.frmEnrollments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EnrollmentsTable)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SideBar sideBar1;
        private TopBar topBar1;
        private System.Windows.Forms.DataGridView EnrollmentsTable;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.Button SubmitEnrollment;
        private System.Windows.Forms.ComboBox course;
        private System.Windows.Forms.TextBox student_no;
        private System.Windows.Forms.Button btnDeleteEnrollment;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnExportToExcel;
    }
}