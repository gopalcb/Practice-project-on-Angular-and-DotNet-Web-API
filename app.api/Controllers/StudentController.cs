using app.api.Authentication;
using app.data.Domains;
using app.service.Services.StudentService;
using app.service.Services.UserService;
using StrataSpot.Api.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace app.api.Controllers
{
    [RoutePrefix("api/student")]
    public class StudentController : ApiController
    {
        protected IUserService _userService { set; get; }
        protected IStudentService _studentService { set; get; }

        public StudentController(IUserService userService, IStudentService studentService)
        {
            _userService = userService;
            _studentService = studentService;
        }
        
        [Route("get-students")]
        [HttpGet]
        public IHttpActionResult GetStudents(string keyword)
        {
            var students = new List<Student>();
            if (!string.IsNullOrEmpty(keyword))
            {
                students = _studentService.GetAll().Where(s => s.Name.ToLower().Contains(keyword.ToLower()) || s.Email.ToLower().Contains(keyword.ToLower())).ToList();
            }
            else
            {
                students = _studentService.GetAll();
            }
            return Ok(students);
        }

        [Route("get-student/{id}")]
        [HttpGet]
        public IHttpActionResult GetStudent(Guid? id)
        {
            var student = _studentService.GetStudent(id ?? Guid.NewGuid());
            return Ok(student);
        }

        [Route("save-student")]
        [HttpPost]
        public IHttpActionResult Save(Student student)
        {
            var item = _studentService.Save(student);
            return Ok(item);
        }

        [Route("update-student")]
        [HttpPost]
        public IHttpActionResult Update(Student student)
        {
            var item = _studentService.Update(student);
            return Ok(item);
        }

        [Route("delete-student/{id}")]
        [HttpPost]
        public IHttpActionResult Delete(Guid id)
        {
            var student = _studentService.GetStudent(id);
            _studentService.Delete(student);
            return Ok(true);
        }
    }
}
