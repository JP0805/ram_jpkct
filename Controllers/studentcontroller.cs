using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace app.Controllers{
    [ApiController]
    [Route("[controller]")]

    public class Studentcontroller: ControllerBase{
        private static readonly List<Student> Students = new List<Student>(){
            new Student(){
                Id = 1,
                Name  = "Jp",
                Department = "IT",
                Joindate = new DateTime(2017,7,7),
                Course = "AI"
            },
             new Student(){
                Id = 2,
                Name  = "Ram",
                Department = "IT",
                Joindate = new DateTime(2017,8,8),
                Course = "AI"
            },
        };
        [HttpGet]
        public List<Student> Get(){
            return Students;
        }
        [HttpPost]
        public Student Post(Student student){
            student.Id = Students.Select(x=>x.Id).Max()+1;
            Students.Add(student);
            return student;       
        }
        [HttpPut]
        public Student Put(Student student){
            Student updateStudent  = Students.Single(x=>x.Id == student.Id);
            updateStudent.Name = student.Name;
            updateStudent.Id = student.Id;
            updateStudent.Department = student.Department;
            updateStudent.Joindate = student.Joindate;
            updateStudent.Course = student.Course;
            return updateStudent;
        }
   
    }

}

