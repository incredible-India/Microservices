using Microsoft.AspNetCore.Mvc;
using ReadStudent.Services;

namespace ReadStudent.Controllers
{
    public class ReadStudentController : ControllerBase
    {
        private readonly IStudents students;
        public ReadStudentController(IStudents students)
        {
            this.students = students;
        }


        [HttpGet]
        [Route("/get/all/")]

        public IActionResult GetAllStundet()
        {
            return Ok(this.students.GetAllStudents().Result);
        }

        [HttpGet]
        [Route("/get/all/{id:int}")]

        public IActionResult GetStundetById([FromRoute] int id)
        {
            return Ok(this.students.GetStudentById(id).Result);
        }
    }
}
