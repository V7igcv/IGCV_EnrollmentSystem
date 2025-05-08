namespace EDP_WinProject102
{
    partial class frmStudents
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
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel18 = new System.Windows.Forms.Panel();
            this.age = new System.Windows.Forms.NumericUpDown();
            this.SubmitStudent = new System.Windows.Forms.Button();
            this.student_no = new System.Windows.Forms.TextBox();
            this.address = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.lname = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fname = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.StudentsTable = new System.Windows.Forms.DataGridView();
            this.sideBar1 = new EDP_WinProject102.SideBar();
            this.topBar1 = new EDP_WinProject102.TopBar();
            this.phone = new System.Windows.Forms.TextBox();
            this.btnDeleteStudent = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.age)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(37, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 40);
            this.label5.TabIndex = 8;
            this.label5.Text = "STUDENTS";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnDeleteStudent);
            this.panel1.Controls.Add(this.panel18);
            this.panel1.Controls.Add(this.StudentsTable);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(201, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1096, 746);
            this.panel1.TabIndex = 9;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel18.Controls.Add(this.phone);
            this.panel18.Controls.Add(this.age);
            this.panel18.Controls.Add(this.SubmitStudent);
            this.panel18.Controls.Add(this.student_no);
            this.panel18.Controls.Add(this.address);
            this.panel18.Controls.Add(this.email);
            this.panel18.Controls.Add(this.lname);
            this.panel18.Controls.Add(this.label8);
            this.panel18.Controls.Add(this.label7);
            this.panel18.Controls.Add(this.label6);
            this.panel18.Controls.Add(this.label4);
            this.panel18.Controls.Add(this.label3);
            this.panel18.Controls.Add(this.label2);
            this.panel18.Controls.Add(this.label1);
            this.panel18.Controls.Add(this.fname);
            this.panel18.Controls.Add(this.label14);
            this.panel18.Location = new System.Drawing.Point(44, 67);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(991, 270);
            this.panel18.TabIndex = 10;
            // 
            // age
            // 
            this.age.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.age.Location = new System.Drawing.Point(325, 101);
            this.age.Name = "age";
            this.age.Size = new System.Drawing.Size(57, 28);
            this.age.TabIndex = 29;
            // 
            // SubmitStudent
            // 
            this.SubmitStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.SubmitStudent.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubmitStudent.ForeColor = System.Drawing.SystemColors.Control;
            this.SubmitStudent.Location = new System.Drawing.Point(725, 215);
            this.SubmitStudent.Name = "SubmitStudent";
            this.SubmitStudent.Size = new System.Drawing.Size(202, 34);
            this.SubmitStudent.TabIndex = 28;
            this.SubmitStudent.Text = "Submit";
            this.SubmitStudent.UseVisualStyleBackColor = false;
            this.SubmitStudent.Click += new System.EventHandler(this.button1_Click);
            // 
            // student_no
            // 
            this.student_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.student_no.Location = new System.Drawing.Point(629, 169);
            this.student_no.Name = "student_no";
            this.student_no.Size = new System.Drawing.Size(298, 28);
            this.student_no.TabIndex = 27;
            // 
            // address
            // 
            this.address.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address.Location = new System.Drawing.Point(629, 101);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(298, 28);
            this.address.TabIndex = 26;
            // 
            // email
            // 
            this.email.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email.Location = new System.Drawing.Point(325, 169);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(267, 28);
            this.email.TabIndex = 24;
            // 
            // lname
            // 
            this.lname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lname.Location = new System.Drawing.Point(51, 169);
            this.lname.Name = "lname";
            this.lname.Size = new System.Drawing.Size(231, 28);
            this.lname.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(625, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 22);
            this.label8.TabIndex = 21;
            this.label8.Text = "Student Number";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(625, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 22);
            this.label7.TabIndex = 20;
            this.label7.Text = "Address";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(321, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 22);
            this.label6.TabIndex = 19;
            this.label6.Text = "Email Address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(397, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 22);
            this.label4.TabIndex = 18;
            this.label4.Text = "Phone Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(321, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 22);
            this.label3.TabIndex = 17;
            this.label3.Text = "Age";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 22);
            this.label2.TabIndex = 16;
            this.label2.Text = "Last Name";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 22);
            this.label1.TabIndex = 15;
            this.label1.Text = "First Name";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // fname
            // 
            this.fname.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fname.Location = new System.Drawing.Point(51, 101);
            this.fname.Name = "fname";
            this.fname.Size = new System.Drawing.Size(231, 28);
            this.fname.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Bahnschrift Condensed", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(46, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(116, 29);
            this.label14.TabIndex = 13;
            this.label14.Text = "ADD STUDENT";
            // 
            // StudentsTable
            // 
            this.StudentsTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StudentsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentsTable.Location = new System.Drawing.Point(44, 402);
            this.StudentsTable.Name = "StudentsTable";
            this.StudentsTable.RowHeadersWidth = 51;
            this.StudentsTable.RowTemplate.Height = 24;
            this.StudentsTable.Size = new System.Drawing.Size(991, 348);
            this.StudentsTable.TabIndex = 9;
            this.StudentsTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // sideBar1
            // 
            this.sideBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.sideBar1.Location = new System.Drawing.Point(0, -1);
            this.sideBar1.Name = "sideBar1";
            this.sideBar1.Size = new System.Drawing.Size(203, 831);
            this.sideBar1.TabIndex = 0;
            // 
            // topBar1
            // 
            this.topBar1.Location = new System.Drawing.Point(201, 0);
            this.topBar1.Name = "topBar1";
            this.topBar1.Size = new System.Drawing.Size(1097, 84);
            this.topBar1.TabIndex = 1;
            // 
            // phone
            // 
            this.phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phone.Location = new System.Drawing.Point(401, 101);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(191, 28);
            this.phone.TabIndex = 30;
            // 
            // btnDeleteStudent
            // 
            this.btnDeleteStudent.BackColor = System.Drawing.SystemColors.Control;
            this.btnDeleteStudent.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteStudent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.btnDeleteStudent.Location = new System.Drawing.Point(856, 359);
            this.btnDeleteStudent.Name = "btnDeleteStudent";
            this.btnDeleteStudent.Size = new System.Drawing.Size(179, 36);
            this.btnDeleteStudent.TabIndex = 32;
            this.btnDeleteStudent.Text = "Delete Selected";
            this.btnDeleteStudent.UseVisualStyleBackColor = false;
            this.btnDeleteStudent.Click += new System.EventHandler(this.btnDeleteStudent_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.SystemColors.Control;
            this.btnEdit.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.btnEdit.Location = new System.Drawing.Point(671, 360);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(179, 36);
            this.btnEdit.TabIndex = 33;
            this.btnEdit.Text = "Edit Selected";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // frmStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1298, 831);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sideBar1);
            this.Controls.Add(this.topBar1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStudents";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Students";
            this.Load += new System.EventHandler(this.frmStudents_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.age)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentsTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SideBar sideBar1;
        private TopBar topBar1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView StudentsTable;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox fname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox student_no;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.TextBox lname;
        private System.Windows.Forms.Button SubmitStudent;
        private System.Windows.Forms.NumericUpDown age;
        private System.Windows.Forms.TextBox phone;
        private System.Windows.Forms.Button btnDeleteStudent;
        private System.Windows.Forms.Button btnEdit;
    }
}