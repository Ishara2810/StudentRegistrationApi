using Microsoft.AspNetCore.Mvc;
using StudentRegistrationApi.Models;
using StudentRegistrationApi.Services.Interfaces;
using System.Net.Http.Headers;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentRegistrationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly IStudentRepository _studentRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public StudentController(IStudentRepository studentRepository, IWebHostEnvironment webHostEnvironment)
        {
            _studentRepository = studentRepository;
            this.webHostEnvironment = webHostEnvironment;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> Get()
        {
            var students = await _studentRepository.GetAllStudents();
            return Ok(students);
        }

        // GETBYID api/<StudentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetById(int id)
        {
            var stuObj = await _studentRepository.GetStudentById(id);
            if(stuObj == null)
            {
                return NotFound();
            }
            return Ok(stuObj);
        }

        //// POST api/<StudentController>
        //[HttpPost]
        //public async Task<ActionResult<Student>> Post([FromBody] Student model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    try
        //    {
        //        var student = await _studentRepository.AddStudent(model);

        //        return Ok(student);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        // POST api/<StudentController>
        [HttpPost]
        public async Task<ActionResult<Student>> Post([FromForm] IFormCollection data, [FromForm] IFormFile? file)
        {
            try
            {
                var newStudent = new Student
                {
                    FirstName = data["firstName"],
                    LastName = data["lastName"],
                    MobileNo = data["mobileNo"],
                    Email = data["email"],
                    Nic = data["nic"],
                    DateOfBirth = Convert.ToDateTime(data["dateOfBirth"]),
                    Address = data["address"],
                    ImgPath = ""  // This will be populated with the file path in the server
                };

                if (file != null)
                {
                    var folderName = Path.Combine("Resources", "Images");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName); ;
                    string extension = Path.GetExtension(file.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    newStudent.ImgPath = dbPath;
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                var student = await _studentRepository.AddStudent(newStudent);

                return Ok(student);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT api/<StudentController>/5
        [HttpPut()]
        public async Task<ActionResult<Student>> Put([FromForm] IFormCollection data, [FromForm] IFormFile? file)
        {
            try
            {
                var model = new Student
                {
                    Id = Convert.ToInt32(data["id"]),
                    FirstName = data["firstName"],
                    LastName = data["lastName"],
                    MobileNo = data["mobileNo"],
                    Email = data["email"],
                    Nic = data["nic"],
                    DateOfBirth = Convert.ToDateTime(data["dateOfBirth"]),
                    Address = data["address"],
                    ImgPath = data["imgPath"]  // This will be populated with the file path in the server
                };

                if (file != null)
                {
                    var folderName = Path.Combine("Resources", "Images");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName); ;
                    string extension = Path.GetExtension(file.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    model.ImgPath = dbPath;
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    //Delete previous file when edit
                    var exStudentObj = await _studentRepository.GetStudentById(model.Id);
                    if (exStudentObj != null)
                    {
                        if (exStudentObj.ImgPath != "" && exStudentObj.ImgPath != null)
                        {
                            string filePath = Path.Combine(Directory.GetCurrentDirectory(), exStudentObj.ImgPath);
                            System.IO.File.Delete(filePath);
                        }
                    }
                    else
                    {
                        return NotFound();
                    }
                }

                var student = await _studentRepository.UpdateStudent(model);
                if (student == null)
                {
                    return NotFound();
                }

                return Ok(student);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> Delete(int id)
        {
            try
            {
                //Delete previous file when delete
                var exStudentObj = await _studentRepository.GetStudentById(id);
                if (exStudentObj != null)
                {
                    if (exStudentObj.ImgPath != "" && exStudentObj.ImgPath != null)
                    {
                        string filePath = Path.Combine(Directory.GetCurrentDirectory(), exStudentObj.ImgPath);
                        System.IO.File.Delete(filePath);
                    }
                }
                else
                {
                    return NotFound();
                }

                var student = await _studentRepository.DeleteStudent(id);
                
                return Ok(student);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
