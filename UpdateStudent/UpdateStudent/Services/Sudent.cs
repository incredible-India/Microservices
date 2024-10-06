using Microsoft.EntityFrameworkCore;
using UpdateStudent.Implemataion;
using UpdateStudent.Models;

namespace UpdateStudent.Services
{
    public class Sudent : IStudent
    {
        private readonly StudentDbContext _context;

        public Sudent(StudentDbContext studentDbContext)
        {
            _context = studentDbContext;
        }

        public   Task UpdateStudent(Student student)
        {
            //first check student exist or not

            var studentdata = _context.Students.Where(i => i.Email == student.Email);
            if (studentdata.Any()) {
                var dataToUpdate = studentdata.FirstOrDefault();
                dataToUpdate.Name = student.Name;
                dataToUpdate.Email = student.Email;
               // _context.Students.Update(student);
                _context.SaveChanges();
                return Task.CompletedTask;
            }
            else
            {
              return Task.FromResult(0);
            }


        }
    }
}
