using CreateStudent.Models;

namespace CreateStudent.Implemataions
{
    public interface Istudent
    {
        public Task  CreateStudent(Students student);
    }
}
