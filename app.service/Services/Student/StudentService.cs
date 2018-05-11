using app.data.AppContext;
using app.data.Domains;
using System;
using System.Collections.Generic;
using System.Linq;

namespace app.service.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private AppContext context;
        public StudentService()
        {
            context = new AppContext();
        }

        public Student GetStudent(Guid id)
        {
            var student = context.Students.Find(id);
            return student;
        }

        public List<Student> GetAll()
        {
            var students = context.Students.ToList();
            return students;
        }

        public Student Save(Student student)
        {
            student.Id = Guid.NewGuid();
            context.Students.Add(student);
            context.SaveChanges();
            return student;
        }

        public Student Update(Student student)
        {
            context.Entry(student).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return student;
        }

        public void Delete(Student student)
        {
            context.Students.Remove(student);
            context.SaveChanges();
        }
    }
}