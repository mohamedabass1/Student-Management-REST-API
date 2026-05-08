using StudentDataAccessLayer;

namespace StudentAPIBusinessLayer
{
    public class clsStudent
    {
        public enum enMode { AddNew, Update }
        public enMode Mode = enMode.AddNew;

        public clsStudent(StudentDTO sDTO, enMode sMode = enMode.AddNew)
        {
            this.ID = sDTO.ID;
            this.Name = sDTO.Name;
            this.Age = sDTO.Age;
            this.Grade = sDTO.Grade;

            Mode = sMode;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }

        public StudentDTO ToDTO()
        {
            return new StudentDTO(this.ID, this.Name, this.Age, this.Grade);
        }


        private async Task<bool> _AddNewStudent()
        {
            this.ID = await clsStudentData.AddNewStudent(this.ToDTO());

            return (this.ID != -1);
        }
        private async Task<bool> _UpdateStudent()
        {
            return await clsStudentData.UpdateStudent(this.ToDTO());
        }

        public async Task<bool> Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (await _AddNewStudent())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    break;

                case enMode.Update:
                    {
                        return await _UpdateStudent();
                    }

            }

            return false;
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
                return new clsStudent(sDTO, enMode.Update);

            return null;
        }
    }
}
