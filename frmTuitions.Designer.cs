namespace EDP_WinProject102
{
    partial class frmTuitions
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
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDeleteTuition = new System.Windows.Forms.Button();
            this.TuitionsTable = new System.Windows.Forms.DataGridView();
            this.panel18 = new System.Windows.Forms.Panel();
            this.SubmitTuition = new System.Windows.Forms.Button();
            this.course = new System.Windows.Forms.ComboBox();
            this.year = new System.Windows.Forms.TextBox();
            this.amount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.topBar1 = new EDP_WinProject102.TopBar();
            this.sideBar1 = new EDP_WinProject102.SideBar();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TuitionsTable)).BeginInit();
            this.panel18.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnDeleteTuition);
            this.panel1.Controls.Add(this.TuitionsTable);
            this.panel1.Controls.Add(this.panel18);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(201, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1096, 746);
            this.panel1.TabIndex = 12;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.SystemColors.Control;
            this.btnEdit.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.btnEdit.Location = new System.Drawing.Point(671, 344);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(179, 36);
            this.btnEdit.TabIndex = 40;
            this.btnEdit.Text = "Edit Selected";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDeleteTuition
            // 
            this.btnDeleteTuition.BackColor = System.Drawing.SystemColors.Control;
            this.btnDeleteTuition.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteTuition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.btnDeleteTuition.Location = new System.Drawing.Point(856, 344);
            this.btnDeleteTuition.Name = "btnDeleteTuition";
            this.btnDeleteTuition.Size = new System.Drawing.Size(179, 36);
            this.btnDeleteTuition.TabIndex = 35;
            this.btnDeleteTuition.Text = "Delete Selected";
            this.btnDeleteTuition.UseVisualStyleBackColor = false;
            this.btnDeleteTuition.Click += new System.EventHandler(this.btnDeleteTuition_Click);
            // 
            // TuitionsTable
            // 
            this.TuitionsTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TuitionsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TuitionsTable.Location = new System.Drawing.Point(44, 386);
            this.TuitionsTable.Name = "TuitionsTable";
            this.TuitionsTable.RowHeadersWidth = 51;
            this.TuitionsTable.RowTemplate.Height = 24;
            this.TuitionsTable.Size = new System.Drawing.Size(991, 363);
            this.TuitionsTable.TabIndex = 13;
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel18.Controls.Add(this.SubmitTuition);
            this.panel18.Controls.Add(this.course);
            this.panel18.Controls.Add(this.year);
            this.panel18.Controls.Add(this.amount);
            this.panel18.Controls.Add(this.label6);
            this.panel18.Controls.Add(this.label2);
            this.panel18.Controls.Add(this.label1);
            this.panel18.Controls.Add(this.label14);
            this.panel18.Location = new System.Drawing.Point(44, 72);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(991, 251);
            this.panel18.TabIndex = 12;
            // 
            // SubmitTuition
            // 
            this.SubmitTuition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.SubmitTuition.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubmitTuition.ForeColor = System.Drawing.SystemColors.Control;
            this.SubmitTuition.Location = new System.Drawing.Point(723, 103);
            this.SubmitTuition.Name = "SubmitTuition";
            this.SubmitTuition.Size = new System.Drawing.Size(202, 34);
            this.SubmitTuition.TabIndex = 34;
            this.SubmitTuition.Text = "Submit";
            this.SubmitTuition.UseVisualStyleBackColor = false;
            this.SubmitTuition.Click += new System.EventHandler(this.SubmitTuition_Click);
            // 
            // course
            // 
            this.course.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.course.FormattingEnabled = true;
            this.course.Location = new System.Drawing.Point(51, 103);
            this.course.Name = "course";
            this.course.Size = new System.Drawing.Size(293, 30);
            this.course.TabIndex = 33;
            // 
            // year
            // 
            this.year.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.year.Location = new System.Drawing.Point(400, 105);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(267, 28);
            this.year.TabIndex = 24;
            // 
            // amount
            // 
            this.amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amount.Location = new System.Drawing.Point(51, 169);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(293, 28);
            this.amount.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(396, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 22);
            this.label6.TabIndex = 19;
            this.label6.Text = "Academic Year";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 22);
            this.label2.TabIndex = 16;
            this.label2.Text = "Amount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 22);
            this.label1.TabIndex = 15;
            this.label1.Text = "Course";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Bahnschrift Condensed", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(45, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(140, 29);
            this.label14.TabIndex = 13;
            this.label14.Text = "ADD TUITION FEE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(37, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 40);
            this.label5.TabIndex = 9;
            this.label5.Text = "TUITION FEES";
            // 
            // topBar1
            // 
            this.topBar1.Location = new System.Drawing.Point(201, 0);
            this.topBar1.Name = "topBar1";
            this.topBar1.Size = new System.Drawing.Size(1097, 84);
            this.topBar1.TabIndex = 13;
            // 
            // sideBar1
            // 
            this.sideBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.sideBar1.Location = new System.Drawing.Point(-1, 0);
            this.sideBar1.Name = "sideBar1";
            this.sideBar1.Size = new System.Drawing.Size(203, 831);
            this.sideBar1.TabIndex = 14;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(44, 347);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(231, 28);
            this.txtSearch.TabIndex = 41;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // frmTuitions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 831);
            this.Controls.Add(this.sideBar1);
            this.Controls.Add(this.topBar1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTuitions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tuition Fees";
            this.Load += new System.EventHandler(this.frmTuitions_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TuitionsTable)).EndInit();
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView TuitionsTable;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.TextBox year;
        private System.Windows.Forms.TextBox amount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label5;
        private TopBar topBar1;
        private SideBar sideBar1;
        private System.Windows.Forms.ComboBox course;
        private System.Windows.Forms.Button SubmitTuition;
        private System.Windows.Forms.Button btnDeleteTuition;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox txtSearch;
    }
}