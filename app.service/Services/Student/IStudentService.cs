using app.data.Domains;
using System;
using System.Collections.Generic;

namespace app.service.Services.StudentService
{
    public interface IStudentService
    {
        Student GetStudent(Guid id);
        List<Student> GetAll();
        Student Save(Student student);
        Student Update(Student student);
        void Delete(Student student);
    }
}