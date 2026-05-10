using System.Net;
using System.Net.Http.Json;

namespace StudentDesktopClient1
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
    }

    public partial class Form1 : Form
    {
        public static readonly HttpClient HttpClient = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            HttpClient.BaseAddress = new Uri("http://localhost:5254/api/Students/");
            await LoadStudentsList();
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

        private async Task _AddNewStudent(Student student)
        {
            if (student == null || string.IsNullOrEmpty(student.Name) || student.Age < 12 || student.Grade < 0 || student.Grade > 100)
            {
                MessageBox.Show("Invalid Student Info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var response = await HttpClient.PostAsJsonAsync<Student>("", student);

            if (response.IsSuccessStatusCode)
            {
                var StudentInfo = await response.Content.ReadFromJsonAsync<Student>();
                if (StudentInfo != null)
                    MessageBox.Show("Students Added Successfully with Student ID " + StudentInfo.ID);

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


        private async void tpStudentList_Enter(object sender, EventArgs e)
        {
            await LoadStudentsList();
        }
    }
}
