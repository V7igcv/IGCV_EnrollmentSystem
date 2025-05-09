namespace EDP_WinProject102
{
    partial class frmDepartments
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
            this.btnDeleteDept = new System.Windows.Forms.Button();
            this.DepartmentsTable = new System.Windows.Forms.DataGridView();
            this.panel18 = new System.Windows.Forms.Panel();
            this.SubmitDept = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.department = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.sideBar1 = new EDP_WinProject102.SideBar();
            this.topBar1 = new EDP_WinProject102.TopBar();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentsTable)).BeginInit();
            this.panel18.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.btnDeleteDept);
            this.panel1.Controls.Add(this.DepartmentsTable);
            this.panel1.Controls.Add(this.panel18);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(202, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1096, 746);
            this.panel1.TabIndex = 15;
            // 
            // btnDeleteDept
            // 
            this.btnDeleteDept.BackColor = System.Drawing.SystemColors.Control;
            this.btnDeleteDept.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteDept.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.btnDeleteDept.Location = new System.Drawing.Point(856, 239);
            this.btnDeleteDept.Name = "btnDeleteDept";
            this.btnDeleteDept.Size = new System.Drawing.Size(179, 36);
            this.btnDeleteDept.TabIndex = 33;
            this.btnDeleteDept.Text = "Delete Selected";
            this.btnDeleteDept.UseVisualStyleBackColor = false;
            this.btnDeleteDept.Click += new System.EventHandler(this.btnDeleteDept_Click);
            // 
            // DepartmentsTable
            // 
            this.DepartmentsTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DepartmentsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DepartmentsTable.Location = new System.Drawing.Point(44, 281);
            this.DepartmentsTable.Name = "DepartmentsTable";
            this.DepartmentsTable.RowHeadersWidth = 51;
            this.DepartmentsTable.RowTemplate.Height = 24;
            this.DepartmentsTable.Size = new System.Drawing.Size(991, 473);
            this.DepartmentsTable.TabIndex = 13;
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel18.Controls.Add(this.SubmitDept);
            this.panel18.Controls.Add(this.label1);
            this.panel18.Controls.Add(this.department);
            this.panel18.Controls.Add(this.label14);
            this.panel18.Location = new System.Drawing.Point(44, 72);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(991, 148);
            this.panel18.TabIndex = 12;
            // 
            // SubmitDept
            // 
            this.SubmitDept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.SubmitDept.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubmitDept.ForeColor = System.Drawing.SystemColors.Control;
            this.SubmitDept.Location = new System.Drawing.Point(747, 80);
            this.SubmitDept.Name = "SubmitDept";
            this.SubmitDept.Size = new System.Drawing.Size(202, 34);
            this.SubmitDept.TabIndex = 28;
            this.SubmitDept.Text = "Submit";
            this.SubmitDept.UseVisualStyleBackColor = false;
            this.SubmitDept.Click += new System.EventHandler(this.SubmitDept_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 22);
            this.label1.TabIndex = 15;
            this.label1.Text = "Department Name";
            // 
            // department
            // 
            this.department.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.department.Location = new System.Drawing.Point(197, 85);
            this.department.Name = "department";
            this.department.Size = new System.Drawing.Size(287, 28);
            this.department.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Bahnschrift Condensed", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(46, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(149, 29);
            this.label14.TabIndex = 13;
            this.label14.Text = "ADD DEPARTMENT";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(37, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 40);
            this.label5.TabIndex = 9;
            this.label5.Text = "DEPARTMENTS";
            // 
            // sideBar1
            // 
            this.sideBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.sideBar1.Location = new System.Drawing.Point(0, 0);
            this.sideBar1.Name = "sideBar1";
            this.sideBar1.Size = new System.Drawing.Size(203, 831);
            this.sideBar1.TabIndex = 17;
            // 
            // topBar1
            // 
            this.topBar1.Location = new System.Drawing.Point(201, 0);
            this.topBar1.Name = "topBar1";
            this.topBar1.Size = new System.Drawing.Size(1097, 84);
            this.topBar1.TabIndex = 16;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(44, 242);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(231, 28);
            this.txtSearch.TabIndex = 36;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // frmDepartments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 831);
            this.Controls.Add(this.sideBar1);
            this.Controls.Add(this.topBar1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDepartments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Departments";
            this.Load += new System.EventHandler(this.frmDepartments_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentsTable)).EndInit();
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DepartmentsTable;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Button SubmitDept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox department;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label5;
        private TopBar topBar1;
        private SideBar sideBar1;
        private System.Windows.Forms.Button btnDeleteDept;
        private System.Windows.Forms.TextBox txtSearch;
    }
}