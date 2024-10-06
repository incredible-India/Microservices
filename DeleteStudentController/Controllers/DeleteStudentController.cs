using DeleteStudentController.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeleteStudentController.Controllers
{
    public class DeleteStudentController : ControllerBase
    {
        private readonly Istudent student;
        public DeleteStudentController(Istudent student)
        {
            this.student = student;    
        }

        [HttpDelete]
        [Route("/delete/student")]
        public IActionResult DeleteStudent([FromBody] Student student)
        {
            var response = this.student.DeleteStudent(student);
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
