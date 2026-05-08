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

        [HttpGet("{ID}", Name = "GetByID")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<StudentDTO>> GetStudentByID(int ID)
        {
            if (ID < 1)
            {
                return BadRequest("Invalid Student ID");
            }

            clsStudent student = await clsStudent.Find(ID);

            if (student == null)
            {
                return NotFound($"Student with id {ID} Not Found!");
            }


            //here we get only the DTO object to send it back.
            StudentDTO sDTO = student.ToDTO();

            // we return only the DTO not the student object
            return Ok(sDTO);

        }


        [HttpPost(Name = "AddNewStudent")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<StudentDTO>> AddNewStudent(StudentDTO sDTO)
        {
            if (sDTO == null || string.IsNullOrEmpty(sDTO.Name) || sDTO.Age < 7 || sDTO.Grade < 0 || sDTO.Grade > 100)
            {
                return BadRequest("Invalid Student Data");
            }

            clsStudent student = new clsStudent(sDTO, clsStudent.enMode.AddNew);

            if (await student.Save())
            {
                sDTO.ID = student.ID;
                return CreatedAtRoute("GetByID", new { ID = student.ID }, sDTO);
            }

            return this.Problem("Failed to Add Student");

        }
    }
}
