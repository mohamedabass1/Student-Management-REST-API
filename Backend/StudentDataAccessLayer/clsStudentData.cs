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
                    while (await reader.ReadAsync())
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
                    while (await reader.ReadAsync())
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


                object? result = await command.ExecuteScalarAsync();
                if (result != DBNull.Value)
                    AverageGrade = Convert.ToSingle(result);

            }
            return AverageGrade;
        }

        public static async Task<StudentDTO> GetStudentByID(int ID)
        {

            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            using (SqlCommand command = new SqlCommand("SP_GetStudentByID", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ID", ID);

                await connection.OpenAsync();

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new StudentDTO
                                            (

                                             reader.GetInt32(reader.GetOrdinal("ID")),
                                             reader.GetString(reader.GetOrdinal("Name")),
                                             reader.GetInt32(reader.GetOrdinal("Age")),
                                             reader.GetInt32(reader.GetOrdinal("Grade"))

                                            );
                    }
                }
            }
            return null;
        }


        public static async Task<int> AddNewStudent(StudentDTO sDTO)
        {
            int NewID = -1;

            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            using (SqlCommand command = new SqlCommand("SP_AddNewStudent", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Name", sDTO.Name);
                command.Parameters.AddWithValue("@Age", sDTO.Age);
                command.Parameters.AddWithValue("@Grade", sDTO.Grade);

                SqlParameter InsertedStudentIDParam = new SqlParameter("@NewID", System.Data.SqlDbType.Int)
                {
                    Direction = System.Data.ParameterDirection.Output
                }
                ;

                command.Parameters.Add(InsertedStudentIDParam);

                await connection.OpenAsync();

                await command.ExecuteNonQueryAsync();

                NewID = (int)InsertedStudentIDParam.Value;


                return NewID;
            }
        }

        public static async Task<bool> UpdateStudent(StudentDTO sDTO)
        {
            int AffectedRows = 0;

            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            using (SqlCommand command = new SqlCommand("SP_UpdateStudent", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ID", sDTO.ID);
                command.Parameters.AddWithValue("@Name", sDTO.Name);
                command.Parameters.AddWithValue("@Age", sDTO.Age);
                command.Parameters.AddWithValue("@Grade", sDTO.Grade);


                await connection.OpenAsync();

                AffectedRows = await command.ExecuteNonQueryAsync();

            }
            return AffectedRows != 0;
        }

    }
}
