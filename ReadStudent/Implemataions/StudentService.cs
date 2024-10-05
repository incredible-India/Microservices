using Microsoft.EntityFrameworkCore;

using ReadStudent.Models;
using ReadStudent.Services;

namespace ReadStudent.Implemataions
{
    public class StudentService : IStudents
    {
        private readonly StudentDbContext _studentContext;

        public StudentService(StudentDbContext studentContext)
        {
            _studentContext = studentContext;
        }

       public async Task<List<Student>>GetAllStudents()
        {
            var data= _studentContext.Students.ToList() ;
            return data;
        }

     public async   Task<Student>   GetStudentById(int id)
        {
           //check student exist or not

            var stundet =  _studentContext.Students.Where(i=>i.Id == id).FirstOrDefault();

            if (stundet != null) {
                return new Student { Id = stundet.Id, Email = stundet.Email, Name = stundet.Name };
            }
            else
            {
                return null;
            }
        }
    }
}
