using StudentRegistrationApi.Models;

namespace StudentRegistrationApi.Services.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<Student> AddStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task<Student> GetStudentById(int id);
        Task<Student> DeleteStudent(int id);
    }
}
