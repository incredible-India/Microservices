using Microsoft.AspNetCore.Mvc;
using UpdateStudent.Implemataion;
using UpdateStudent.Models;

namespace UpdateStudent.Controllers
{
    public class UpdateStudentController : ControllerBase
    {
        private readonly IStudent student;

        public UpdateStudentController(IStudent student)
        {
            this.student = student; 
        }



        [HttpPut]
        [Route("/update/student")]

        public IActionResult UpdateStudent([FromBody] Student student)
        {
            this.student.UpdateStudent(student);
            return Ok(student);
        }

    }
}
