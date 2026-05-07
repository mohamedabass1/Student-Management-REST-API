using Microsoft.AspNetCore.Mvc;
using StudentAPIBusinessLayer;
using StudentDataAccessLayer;


namespace StudentApi.Controllers
{
    [Route("api/Students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        [HttpGet(Name = "GetAllStudents")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetAllStudents()
        {
            List<StudentDTO> StudentsList = await clsStudent.GetAllStudents();

            if (StudentsList.Count == 0)
                return NotFound("No Students Found!");
            else
                return Ok(StudentsList);
        }
    }
}
