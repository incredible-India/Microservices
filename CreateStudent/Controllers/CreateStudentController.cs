using CreateStudent.Implemataions;
using CreateStudent.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CreateStudent.Controllers
{
    public class CreateStudentController : ControllerBase
    {
        private readonly Istudent _student;

        public CreateStudentController(Istudent istudent)
        {

          //  student = istudent;
            _student = istudent;
        }


        //creating the new student
        /// <summary>
        /// Creatinf the new stundent 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/create/student/")]
        public async Task<CreatedResult> CreatedAt([FromBody] Students student)
        {

            try
            {
              var resposne =   _student.CreateStudent(student);
                
                return new  CreatedResult();
            }
            catch (Exception exception)
            {
              

                throw new Exception(exception.Message);
                
            }

        }

    }
}
