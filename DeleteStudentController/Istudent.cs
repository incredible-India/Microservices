using DeleteStudentController.Models;

namespace DeleteStudentController
{
    public interface Istudent
    {
        public Task DeleteStudent(Student student);
    }
}
