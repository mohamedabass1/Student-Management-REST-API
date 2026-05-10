using System.Net;
using System.Net.Http.Json;

namespace StudentDesktopClient1
{


    public partial class Form2 : Form
    {
        public class Student
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public int Grade { get; set; }
        }

        public static readonly HttpClient HttpClient = new HttpClient();

        public Form2()
        {
            InitializeComponent();
        }
        private async Task LoadStudentsList()
        {
            try
            {
                var students =
                    await HttpClient.GetFromJsonAsync<List<Student>>("All");

                if (students != null)
                {
                    dgvStudentsList.DataSource = students;
                    dgvStudentsList.Columns[1].Width = 200;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private async void Form2_Load(object sender, EventArgs e)
        {

            HttpClient.BaseAddress = new Uri("http://localhost:5254/api/Students/");
            await LoadStudentsList();

        }

        private async Task _AddNewStudent(Student student)
        {
            if (student == null || string.IsNullOrEmpty(student.Name) || student.Age < 12 || student.Grade < 0 || student.Grade > 100)
            {
                MessageBox.Show("Invalid Student Info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var response = await HttpClient.PostAsJsonAsync<Student>("", student);

                if (response.IsSuccessStatusCode)
                {
                    var StudentInfo = await response.Content.ReadFromJsonAsync<Student>();
                    if (StudentInfo != null)
                    {
                        lblStudentID.Text = StudentInfo.ID.ToString();
                        MessageBox.Show("Students Added Successfully with Student ID " + StudentInfo.ID);
                    }


                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    Console.WriteLine("Failed to Save Student Invalid Input");
                }
                else if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    MessageBox.Show("Internal Server Error Failed to Add Student");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        void _RestAddNewPage()
        {
            lblStudentID.Text = "[???]";
            txtName.Clear();
            txtAge.Clear();
            txtGrade.Clear();
        }
        private void tbAddNewStudent_Enter(object sender, EventArgs e)
        {
            _RestAddNewPage();
        }



        private async void btnAddNew_Click(object sender, EventArgs e)
        {
            Student student = new Student();

            student.Name = txtName.Text;
            student.Age = int.Parse(txtAge.Text);
            student.Grade = int.Parse(txtGrade.Text);

            await _AddNewStudent(student);

            await LoadStudentsList();

        }
        private async Task<Student?> FindStudent(int ID)
        {
            try
            {
                var response = await HttpClient.GetAsync($"{ID}");

                if (response.IsSuccessStatusCode)
                {
                    var studentInfo = await response.Content.ReadFromJsonAsync<Student>();

                    if (studentInfo != null)
                    {
                        return studentInfo;
                    }
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {

                    MessageBox.Show("\nStudent was not found -:(");
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    MessageBox.Show("Invalid ID");
                }
                else
                    MessageBox.Show("Unmown");


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return null;

        }

        private async void btnFind_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStudentID.Text))
                return;

            int studentID = int.Parse(txtStudentID.Text);

            if (studentID < 1)
            {
                MessageBox.Show("Invalid Student ID");
                return;
            }


            var studentInfo = await FindStudent(studentID);

            if (studentInfo != null)
            {
                lblName.Text = studentInfo.Name;
                lblAge.Text = studentInfo.Age.ToString();
                lblGrade.Text = studentInfo.Grade.ToString();
            }
        }

        private async void btnUpFind_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUpStudentID.Text))
                return;

            int studentID = int.Parse(txtUpStudentID.Text);

            if (studentID < 1)
            {
                MessageBox.Show("Invalid Student ID");
                return;
            }


            Student? studentInfo = await FindStudent(studentID);

            if (studentInfo != null)
            {
                txtUpName.Text = studentInfo.Name;
                txtUpAge.Text = studentInfo.Age.ToString();
                txtUpGrade.Text = studentInfo.Grade.ToString();
                btnSaveUpdate.Enabled = true;
            }
        }

        private async void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            Student UpdatedStudent = new Student();

            UpdatedStudent.ID = int.Parse(txtUpStudentID.Text);
            UpdatedStudent.Name = txtUpName.Text;
            UpdatedStudent.Age = int.Parse(txtUpAge.Text);
            UpdatedStudent.Grade = int.Parse(txtUpGrade.Text);

            try
            {
                var response = await HttpClient.PutAsJsonAsync($"{UpdatedStudent.ID}", UpdatedStudent);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Student Updated Successfully");
                    await LoadStudentsList();

                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    MessageBox.Show("Failed to update student: Invalid data.");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    MessageBox.Show($"Student with ID {UpdatedStudent.ID} not found.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private async void btnDeFind_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtDeStudentID.Text))
                return;

            int studentID = int.Parse(txtDeStudentID.Text);

            if (studentID < 1)
            {
                MessageBox.Show("Invalid Student ID");
                return;
            }


            Student? studentInfo = await FindStudent(studentID);

            if (studentInfo != null)
            {
                lblDeName.Text = studentInfo.Name;
                lblAge.Text = studentInfo.Age.ToString();
                lblDeGrade.Text = studentInfo.Grade.ToString();
            }


            if (MessageBox.Show("Are you suer want to delete this student ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                var response = await HttpClient.DeleteAsync($"{studentID}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Student Deleted Successfully");
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    MessageBox.Show("Student Not Found");
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    MessageBox.Show("Invalid Student ID");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }
    }
}
