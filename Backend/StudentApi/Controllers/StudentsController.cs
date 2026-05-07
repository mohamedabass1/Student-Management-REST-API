using Microsoft.AspNetCore.Mvc;
using StudentAPIBusinessLayer;
using StudentDataAccessLayer;


namespace StudentApi.Controllers
{
    [Route("api/Students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        [HttpGet("All", Name = "GetAllStudents")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetAllStudents()
        {
            List<StudentDTO> StudentsList = await clsStudent.GetAllStudents();

            if (StudentsList.Count == 0)
            {
                return NotFound("No Students Found!");
            }

            return Ok(StudentsList);
        }


        [HttpGet("Passed", Name = "GetPassedStudents")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetPassedStudents()
        {
            List<StudentDTO> PassedStudentsList = await clsStudent.GetPassedStudents();

            if (PassedStudentsList.Count == 0)
            {
                return NotFound("No Students Found!");
            }

            return Ok(PassedStudentsList);
        }

        [HttpGet("AverageGrade", Name = "AverageGrade")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<float>> GetAverageGrade()
        {
            float averageGrade = await clsStudent.GetAverageGrade();

            return Ok(averageGrade);
        }
    }
}
