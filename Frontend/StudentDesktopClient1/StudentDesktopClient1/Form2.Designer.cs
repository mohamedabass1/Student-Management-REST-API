namespace StudentDesktopClient1
{
    partial class Form2
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
            Students = new TabControl();
            tpStudentList = new TabPage();
            label2 = new Label();
            dgvStudentsList = new DataGridView();
            tbAddNewStudent = new TabPage();
            groupBox1 = new GroupBox();
            btnAddNew = new Button();
            lblStudentID = new Label();
            label6 = new Label();
            txtGrade = new TextBox();
            label5 = new Label();
            txtAge = new TextBox();
            label4 = new Label();
            txtName = new TextBox();
            label3 = new Label();
            label1 = new Label();
            tpFindStudent = new TabPage();
            groupBox2 = new GroupBox();
            lblGrade = new Label();
            lblAge = new Label();
            lblName = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label8 = new Label();
            btnFind = new Button();
            txtStudentID = new TextBox();
            label7 = new Label();
            Students.SuspendLayout();
            tpStudentList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudentsList).BeginInit();
            tbAddNewStudent.SuspendLayout();
            groupBox1.SuspendLayout();
            tpFindStudent.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // Students
            // 
            Students.Controls.Add(tpStudentList);
            Students.Controls.Add(tbAddNewStudent);
            Students.Controls.Add(tpFindStudent);
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
            tbAddNewStudent.Enter += tbAddNewStudent_Enter;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAddNew);
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
            // btnAddNew
            // 
            btnAddNew.Location = new Point(626, 218);
            btnAddNew.Name = "btnAddNew";
            btnAddNew.Size = new Size(122, 40);
            btnAddNew.TabIndex = 8;
            btnAddNew.Text = "Save";
            btnAddNew.UseVisualStyleBackColor = true;
            btnAddNew.Click += btnAddNew_Click;
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
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(21, 52);
            label6.Name = "label6";
            label6.Size = new Size(108, 25);
            label6.TabIndex = 6;
            label6.Text = "StudentID:";
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
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 14F);
            txtName.Location = new Point(26, 133);
            txtName.Name = "txtName";
            txtName.Size = new Size(190, 32);
            txtName.TabIndex = 1;
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
            // tpFindStudent
            // 
            tpFindStudent.Controls.Add(groupBox2);
            tpFindStudent.Controls.Add(label8);
            tpFindStudent.Controls.Add(btnFind);
            tpFindStudent.Controls.Add(txtStudentID);
            tpFindStudent.Controls.Add(label7);
            tpFindStudent.Location = new Point(4, 34);
            tpFindStudent.Name = "tpFindStudent";
            tpFindStudent.Size = new Size(902, 424);
            tpFindStudent.TabIndex = 2;
            tpFindStudent.Text = "Find Student";
            tpFindStudent.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblGrade);
            groupBox2.Controls.Add(lblAge);
            groupBox2.Controls.Add(lblName);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(label13);
            groupBox2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            groupBox2.Location = new Point(35, 148);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(767, 162);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Student Information";
            // 
            // lblGrade
            // 
            lblGrade.AutoSize = true;
            lblGrade.Font = new Font("Segoe UI", 13F);
            lblGrade.Location = new Point(622, 84);
            lblGrade.Name = "lblGrade";
            lblGrade.Size = new Size(54, 25);
            lblGrade.TabIndex = 10;
            lblGrade.Text = "[????]";
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Font = new Font("Segoe UI", 13F);
            lblAge.Location = new Point(387, 84);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(54, 25);
            lblAge.TabIndex = 9;
            lblAge.Text = "[????]";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 13F);
            lblName.Location = new Point(102, 84);
            lblName.Name = "lblName";
            lblName.Size = new Size(54, 25);
            lblName.TabIndex = 7;
            lblName.Text = "[????]";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(550, 84);
            label11.Name = "label11";
            label11.Size = new Size(66, 25);
            label11.TabIndex = 4;
            label11.Text = "Grade";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(317, 84);
            label12.Name = "label12";
            label12.Size = new Size(47, 25);
            label12.TabIndex = 2;
            label12.Text = "Age";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(27, 82);
            label13.Name = "label13";
            label13.Size = new Size(69, 25);
            label13.TabIndex = 0;
            label13.Text = "Name:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label8.ForeColor = Color.Red;
            label8.Location = new Point(319, 12);
            label8.Name = "label8";
            label8.Size = new Size(179, 37);
            label8.TabIndex = 9;
            label8.Text = "Find Student";
            // 
            // btnFind
            // 
            btnFind.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnFind.Location = new Point(575, 86);
            btnFind.Name = "btnFind";
            btnFind.Size = new Size(122, 40);
            btnFind.TabIndex = 8;
            btnFind.Text = "Find";
            btnFind.UseVisualStyleBackColor = true;
            btnFind.Click += btnFind_Click;
            // 
            // txtStudentID
            // 
            txtStudentID.Font = new Font("Segoe UI", 14F);
            txtStudentID.Location = new Point(334, 91);
            txtStudentID.Name = "txtStudentID";
            txtStudentID.Size = new Size(190, 32);
            txtStudentID.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label7.Location = new Point(220, 98);
            label7.Name = "label7";
            label7.Size = new Size(108, 25);
            label7.TabIndex = 8;
            label7.Text = "StudentID:";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(910, 462);
            Controls.Add(Students);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "Form2";
            Text = "Form1";
            Load += Form2_Load;
            Students.ResumeLayout(false);
            tpStudentList.ResumeLayout(false);
            tpStudentList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudentsList).EndInit();
            tbAddNewStudent.ResumeLayout(false);
            tbAddNewStudent.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tpFindStudent.ResumeLayout(false);
            tpFindStudent.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
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
        private Button btnAddNew;
        private TabPage tpFindStudent;
        private Label label7;
        private TextBox txtStudentID;
        private Label label8;
        private GroupBox groupBox2;
        private Label lblGrade;
        private Label lblAge;
        private Button btnFind;
        private Label lblName;
        private Label label11;
        private Label label12;
        private Label label13;
    }
}