namespace EDP_WinProject102
{
    partial class frmEvaluations
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
            this.topBar1 = new EDP_WinProject102.TopBar();
            this.sideBar1 = new EDP_WinProject102.SideBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.EvaluationsTable = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EvaluationsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // topBar1
            // 
            this.topBar1.Location = new System.Drawing.Point(201, 0);
            this.topBar1.Name = "topBar1";
            this.topBar1.Size = new System.Drawing.Size(1097, 84);
            this.topBar1.TabIndex = 19;
            // 
            // sideBar1
            // 
            this.sideBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.sideBar1.Location = new System.Drawing.Point(0, 0);
            this.sideBar1.Name = "sideBar1";
            this.sideBar1.Size = new System.Drawing.Size(203, 831);
            this.sideBar1.TabIndex = 20;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.EvaluationsTable);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(203, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1096, 746);
            this.panel1.TabIndex = 21;
            // 
            // EvaluationsTable
            // 
            this.EvaluationsTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EvaluationsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EvaluationsTable.Location = new System.Drawing.Point(44, 73);
            this.EvaluationsTable.Name = "EvaluationsTable";
            this.EvaluationsTable.RowHeadersWidth = 51;
            this.EvaluationsTable.RowTemplate.Height = 24;
            this.EvaluationsTable.Size = new System.Drawing.Size(991, 648);
            this.EvaluationsTable.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(37, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 40);
            this.label5.TabIndex = 9;
            this.label5.Text = "EVALUATIONS";
            // 
            // frmEvaluations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 831);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sideBar1);
            this.Controls.Add(this.topBar1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEvaluations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Evaluations";
            this.Load += new System.EventHandler(this.frmEvaluations_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EvaluationsTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private TopBar topBar1;
        private SideBar sideBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView EvaluationsTable;
        private System.Windows.Forms.Label label5;
    }
}