using ReadStudent.Models;

namespace ReadStudent.Services
{
    public interface IStudents
    {

        public Task<List<Student>> GetAllStudents();

        public Task<Student> GetStudentById(int id);
    }
}
