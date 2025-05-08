namespace EDP_WinProject102
{
    partial class frmCourses
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
            this.CoursesTable = new System.Windows.Forms.DataGridView();
            this.panel18 = new System.Windows.Forms.Panel();
            this.department = new System.Windows.Forms.ComboBox();
            this.SubmitCourse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.course = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.topBar1 = new EDP_WinProject102.TopBar();
            this.sideBar1 = new EDP_WinProject102.SideBar();
            this.btnDeleteCourse = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CoursesTable)).BeginInit();
            this.panel18.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.btnDeleteCourse);
            this.panel1.Controls.Add(this.CoursesTable);
            this.panel1.Controls.Add(this.panel18);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(201, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1096, 746);
            this.panel1.TabIndex = 14;
            // 
            // CoursesTable
            // 
            this.CoursesTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CoursesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CoursesTable.Location = new System.Drawing.Point(44, 296);
            this.CoursesTable.Name = "CoursesTable";
            this.CoursesTable.RowHeadersWidth = 51;
            this.CoursesTable.RowTemplate.Height = 24;
            this.CoursesTable.Size = new System.Drawing.Size(991, 450);
            this.CoursesTable.TabIndex = 13;
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel18.Controls.Add(this.department);
            this.panel18.Controls.Add(this.SubmitCourse);
            this.panel18.Controls.Add(this.label3);
            this.panel18.Controls.Add(this.label1);
            this.panel18.Controls.Add(this.course);
            this.panel18.Controls.Add(this.label14);
            this.panel18.Location = new System.Drawing.Point(44, 72);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(991, 165);
            this.panel18.TabIndex = 12;
            // 
            // department
            // 
            this.department.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.department.FormattingEnabled = true;
            this.department.Location = new System.Drawing.Point(373, 101);
            this.department.Name = "department";
            this.department.Size = new System.Drawing.Size(317, 30);
            this.department.TabIndex = 29;
            // 
            // SubmitCourse
            // 
            this.SubmitCourse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.SubmitCourse.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubmitCourse.ForeColor = System.Drawing.SystemColors.Control;
            this.SubmitCourse.Location = new System.Drawing.Point(744, 99);
            this.SubmitCourse.Name = "SubmitCourse";
            this.SubmitCourse.Size = new System.Drawing.Size(202, 34);
            this.SubmitCourse.TabIndex = 28;
            this.SubmitCourse.Text = "Submit";
            this.SubmitCourse.UseVisualStyleBackColor = false;
            this.SubmitCourse.Click += new System.EventHandler(this.SubmitCourse_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(369, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 22);
            this.label3.TabIndex = 17;
            this.label3.Text = "Department";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 22);
            this.label1.TabIndex = 15;
            this.label1.Text = "Course Name";
            // 
            // course
            // 
            this.course.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.course.Location = new System.Drawing.Point(51, 101);
            this.course.Name = "course";
            this.course.Size = new System.Drawing.Size(281, 28);
            this.course.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Bahnschrift Condensed", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(47, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(110, 29);
            this.label14.TabIndex = 13;
            this.label14.Text = "ADD COURSE";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(37, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 40);
            this.label5.TabIndex = 9;
            this.label5.Text = "COURSES";
            // 
            // topBar1
            // 
            this.topBar1.Location = new System.Drawing.Point(201, 0);
            this.topBar1.Name = "topBar1";
            this.topBar1.Size = new System.Drawing.Size(1097, 84);
            this.topBar1.TabIndex = 15;
            // 
            // sideBar1
            // 
            this.sideBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.sideBar1.Location = new System.Drawing.Point(-2, 0);
            this.sideBar1.Name = "sideBar1";
            this.sideBar1.Size = new System.Drawing.Size(203, 831);
            this.sideBar1.TabIndex = 16;
            // 
            // btnDeleteCourse
            // 
            this.btnDeleteCourse.BackColor = System.Drawing.SystemColors.Control;
            this.btnDeleteCourse.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCourse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.btnDeleteCourse.Location = new System.Drawing.Point(856, 254);
            this.btnDeleteCourse.Name = "btnDeleteCourse";
            this.btnDeleteCourse.Size = new System.Drawing.Size(179, 36);
            this.btnDeleteCourse.TabIndex = 33;
            this.btnDeleteCourse.Text = "Delete Selected";
            this.btnDeleteCourse.UseVisualStyleBackColor = false;
            this.btnDeleteCourse.Click += new System.EventHandler(this.btnDeleteCourse_Click);
            // 
            // frmCourses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 831);
            this.Controls.Add(this.sideBar1);
            this.Controls.Add(this.topBar1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCourses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Courses";
            this.Load += new System.EventHandler(this.frmCourses_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CoursesTable)).EndInit();
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView CoursesTable;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Button SubmitCourse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox course;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label5;
        private TopBar topBar1;
        private SideBar sideBar1;
        private System.Windows.Forms.ComboBox department;
        private System.Windows.Forms.Button btnDeleteCourse;
    }
}