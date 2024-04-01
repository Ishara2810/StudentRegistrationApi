using Microsoft.EntityFrameworkCore;
using StudentRegistrationApi.Models;
using StudentRegistrationApi.Services.Interfaces;

namespace StudentRegistrationApi.Services.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDBContext _context;

        public StudentRepository(StudentDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            var stuObj = await _context.Students.FindAsync(id);
            return stuObj;
        }

        public async Task<Student> AddStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return student;
        }

        public async Task<Student> DeleteStudent(int id)
        {
            var stuObj = await _context.Students.FindAsync(id);
            if (stuObj != null)
            {
                _context.Students.Remove(stuObj);
                _context.SaveChanges();
            }
            return stuObj;
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            var stuObj = await _context.Students.FindAsync(student.Id);
            if(stuObj != null)
            {
                stuObj.Address = student.Address;
                stuObj.DateOfBirth = student.DateOfBirth;
                stuObj.FirstName = student.FirstName;
                stuObj.LastName = student.LastName;
                stuObj.Email = student.Email;
                stuObj.MobileNo = student.MobileNo;
                stuObj.Nic = student.Nic;
                stuObj.ImgPath = student.ImgPath;
                await _context.SaveChangesAsync();
            }

            return student;
        }

        
    }
}
