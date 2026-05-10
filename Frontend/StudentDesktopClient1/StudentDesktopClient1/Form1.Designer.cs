using System.Threading.Tasks;

namespace StudentDesktopClient1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Students = new TabControl();
            tpStudentList = new TabPage();
            dgvStudentsList = new DataGridView();
            tbAddNewStudent = new TabPage();
            label1 = new Label();
            label2 = new Label();
            groupBox1 = new GroupBox();
            label3 = new Label();
            txtName = new TextBox();
            txtAge = new TextBox();
            label4 = new Label();
            txtGrade = new TextBox();
            label5 = new Label();
            label6 = new Label();
            lblStudentID = new Label();
            btnSave = new Button();
            Students.SuspendLayout();
            tpStudentList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudentsList).BeginInit();
            tbAddNewStudent.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // Students
            // 
            Students.Controls.Add(tpStudentList);
            Students.Controls.Add(tbAddNewStudent);
            Students.Dock = DockStyle.Fill;
            Students.Font = new Font("Segoe UI", 14F);
            Students.Location = new Point(0, 0);
            Students.Name = "Students";
            Students.SelectedIndex = 0;
            Students.Size = new Size(910, 462);
            Students.TabIndex = 0;
            // 
            // tpStudentList
            // 
            tpStudentList.Controls.Add(label2);
            tpStudentList.Controls.Add(dgvStudentsList);
            tpStudentList.Location = new Point(4, 34);
            tpStudentList.Name = "tpStudentList";
            tpStudentList.Padding = new Padding(3);
            tpStudentList.Size = new Size(902, 424);
            tpStudentList.TabIndex = 0;
            tpStudentList.Text = "Students List";
            tpStudentList.UseVisualStyleBackColor = true;
            tpStudentList.Enter += tpStudentList_Enter;
            // 
            // dgvStudentsList
            // 
            dgvStudentsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudentsList.Location = new Point(33, 82);
            dgvStudentsList.Name = "dgvStudentsList";
            dgvStudentsList.Size = new Size(806, 273);
            dgvStudentsList.TabIndex = 0;
            // 
            // tbAddNewStudent
            // 
            tbAddNewStudent.Controls.Add(groupBox1);
            tbAddNewStudent.Controls.Add(label1);
            tbAddNewStudent.Location = new Point(4, 34);
            tbAddNewStudent.Name = "tbAddNewStudent";
            tbAddNewStudent.Padding = new Padding(3);
            tbAddNewStudent.Size = new Size(902, 424);
            tbAddNewStudent.TabIndex = 1;
            tbAddNewStudent.Text = "Add Student";
            tbAddNewStudent.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(302, 27);
            label1.Name = "label1";
            label1.Size = new Size(242, 37);
            label1.TabIndex = 0;
            label1.Text = "Add New Student";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(312, 12);
            label2.Name = "label2";
            label2.Size = new Size(188, 37);
            label2.TabIndex = 1;
            label2.Text = " Students List";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(lblStudentID);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtGrade);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtAge);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(label3);
            groupBox1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            groupBox1.Location = new Point(31, 92);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(767, 275);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Student Information";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(83, 105);
            label3.Name = "label3";
            label3.Size = new Size(64, 25);
            label3.TabIndex = 0;
            label3.Text = "Name";
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 14F);
            txtName.Location = new Point(26, 133);
            txtName.Name = "txtName";
            txtName.Size = new Size(190, 32);
            txtName.TabIndex = 1;
            // 
            // txtAge
            // 
            txtAge.Font = new Font("Segoe UI", 14F);
            txtAge.Location = new Point(260, 133);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(190, 32);
            txtAge.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(323, 105);
            label4.Name = "label4";
            label4.Size = new Size(47, 25);
            label4.TabIndex = 2;
            label4.Text = "Age";
            // 
            // txtGrade
            // 
            txtGrade.Font = new Font("Segoe UI", 14F);
            txtGrade.Location = new Point(498, 133);
            txtGrade.Name = "txtGrade";
            txtGrade.Size = new Size(190, 32);
            txtGrade.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(556, 105);
            label5.Name = "label5";
            label5.Size = new Size(66, 25);
            label5.TabIndex = 4;
            label5.Text = "Grade";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(21, 52);
            label6.Name = "label6";
            label6.Size = new Size(108, 25);
            label6.TabIndex = 6;
            label6.Text = "StudentID:";
            // 
            // lblStudentID
            // 
            lblStudentID.AutoSize = true;
            lblStudentID.Font = new Font("Segoe UI", 13F);
            lblStudentID.Location = new Point(149, 52);
            lblStudentID.Name = "lblStudentID";
            lblStudentID.Size = new Size(54, 25);
            lblStudentID.TabIndex = 7;
            lblStudentID.Text = "[????]";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(626, 218);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(122, 40);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(910, 462);
            Controls.Add(Students);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            Students.ResumeLayout(false);
            tpStudentList.ResumeLayout(false);
            tpStudentList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudentsList).EndInit();
            tbAddNewStudent.ResumeLayout(false);
            tbAddNewStudent.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl Students;
        private TabPage tpStudentList;
        private TabPage tbAddNewStudent;
        private DataGridView dgvStudentsList;
        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private TextBox txtGrade;
        private Label label5;
        private TextBox txtAge;
        private Label label4;
        private TextBox txtName;
        private Label label3;
        private Label label6;
        private Label lblStudentID;
        private Button btnSave;
    }
}
