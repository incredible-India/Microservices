using UpdateStudent.Models;

namespace UpdateStudent.Implemataion
{
    public interface IStudent
    {
        public  Task UpdateStudent(Student student);
    }
}
