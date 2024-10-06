using DeleteStudentController.Models;

namespace DeleteStudentController
{
    public class StudentService : Istudent
    {
        private readonly StudentDbContext _context;
        public StudentService(StudentDbContext _context)
        {
            this._context = _context;
        }
        public Task? DeleteStudent(Student student)
        {
         //checking the user exist or not
         var studentdata = this._context.Students.Where(i=>i.Email == student.Email);
            if (studentdata.Any()) { 
                this._context.Students.Attach(student);
                this._context.Students.Remove(student);
                this._context.SaveChanges();
                return Task.CompletedTask;

            }
            else
            {
                return null;
            }
        }
    }
}
