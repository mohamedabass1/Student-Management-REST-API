using Microsoft.Data.SqlClient;

namespace StudentDataAccessLayer
{
    public class StudentDTO
    {
        public StudentDTO(int id, string name, int age, int grade)
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
    }

    public class clsStudentData
    {
        private static string _ConnectionString = "Server=.;Database=StudentDB1;User Id=sa;Password=123456;Encrypt=False;TrustServerCertificate=True;Connection Timeout=30;";
        public static async Task<List<StudentDTO>> GetAllStudents()
        {
            var StudentsList = new List<StudentDTO>();

            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            using (SqlCommand command = new SqlCommand("SP_GetAllStudents", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;


                await connection.OpenAsync();

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        StudentsList.Add(new StudentDTO
                        (
                            reader.GetInt32(reader.GetOrdinal("ID")),
                            reader.GetString(reader.GetOrdinal("Name")),
                            reader.GetInt32(reader.GetOrdinal("Age")),
                            reader.GetInt32(reader.GetOrdinal("Grade"))
                        )
                        );
                    }
                }
            }
            return StudentsList;
        }

        public static async Task<List<StudentDTO>> GetPassedStudents()
        {
            var PassedStudentsList = new List<StudentDTO>();

            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            using (SqlCommand command = new SqlCommand("SP_GetPassedStudents", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;


                await connection.OpenAsync();

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        PassedStudentsList.Add(new StudentDTO
                        (
                            reader.GetInt32(reader.GetOrdinal("ID")),
                            reader.GetString(reader.GetOrdinal("Name")),
                            reader.GetInt32(reader.GetOrdinal("Age")),
                            reader.GetInt32(reader.GetOrdinal("Grade"))
                        )
                        );
                    }
                }
            }
            return PassedStudentsList;
        }

        public static async Task<float> GetAverageGrade()
        {
            float AverageGrade = 0;
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            using (SqlCommand command = new SqlCommand("SP_GetAverageGrade", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;


                await connection.OpenAsync();


                object result = await command.ExecuteScalarAsync();
                if (result != DBNull.Value)
                    AverageGrade = Convert.ToSingle(result);

            }
            return AverageGrade;
        }
    }
}
