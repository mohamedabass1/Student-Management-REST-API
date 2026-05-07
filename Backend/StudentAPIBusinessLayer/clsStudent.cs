using StudentDataAccessLayer;

namespace StudentAPIBusinessLayer
{
    public class clsStudent
    {
        public clsStudent(int id, string name, int age, int grade)
        {
            ID = id;
            Name = name;
            Age = age;
            Grade = grade;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }


        public static async Task<List<StudentDTO>> GetAllStudents()
        {
            return await clsStudentData.GetAllStudents();
        }


    }
}
