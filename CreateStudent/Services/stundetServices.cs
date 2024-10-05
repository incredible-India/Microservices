using CreateStudent.Database;
using CreateStudent.Implemataions;
using CreateStudent.Models;

namespace CreateStudent.Services
{
    public class stundetServices : Istudent
    {
        private readonly StudentContext _context;

        public stundetServices(StudentContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(StudentContext));
        }

        public   Task CreateStudent(Students student)
        {
            //checking the student exist or not

            var Studentdata = _context.Students.Where(i => i.Email == student.Email);

            if(Studentdata.Any())
            {
                return Task.FromResult(1);
            }
            else
            {
               
                _context.Students.Add(student);
                _context.SaveChangesAsync();

                return Task.FromResult(0);
            }
        }
    }
}
