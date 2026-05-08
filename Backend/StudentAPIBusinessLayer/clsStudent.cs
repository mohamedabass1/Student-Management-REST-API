using StudentDataAccessLayer;

namespace StudentAPIBusinessLayer
{
    public class clsStudent
    {
        enum enMode { AddNew, Update }
        enMode Mode = enMode.AddNew;
        public clsStudent(int id, string name, int age, int grade)
        {
            ID = id;
            Name = name;
            Age = age;
            Grade = grade;

            Mode = enMode.AddNew;
        }

        private clsStudent(StudentDTO sDTO)
        {
            this.ID = sDTO.ID;
            this.Name = sDTO.Name;
            this.Age = sDTO.Age;
            this.Grade = sDTO.Grade;

            Mode = enMode.Update;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }

        public StudentDTO ToDTO()
        {
            return new StudentDTO(this.ID, this.Name, this.Age, this.Grade);
        }

        public static async Task<List<StudentDTO>> GetAllStudents()
        {
            return await clsStudentData.GetAllStudents();
        }

        public static async Task<List<StudentDTO>> GetPassedStudents()
        {
            return await clsStudentData.GetPassedStudents();
        }

        public static async Task<float> GetAverageGrade()
        {
            return await clsStudentData.GetAverageGrade();
        }

        public static async Task<clsStudent> Find(int ID)
        {
            var sDTO = await clsStudentData.GetStudentByID(ID);

            if (sDTO != null)
                return new clsStudent(sDTO);

            return null;

        }


    }
}
