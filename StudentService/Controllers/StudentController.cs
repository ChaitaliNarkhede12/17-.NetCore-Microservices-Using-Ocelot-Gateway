using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IEnumerable<Student> getStudentList()
        {
            List<Student> lst = new List<Student>()
            {
                new Student {StudentId=1,StudentName="Test1",Class="6th"},
                new Student {StudentId=2,StudentName="Test2",Class="7th"},
                new Student {StudentId=3,StudentName="Test3",Class="10th"},
                new Student {StudentId=4,StudentName="Test4",Class="5th"}
            };
            return lst;
        }

        [HttpGet]
        public IActionResult getStudentData()
        {
            var result = getStudentList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult getStudentData(int id)
        {
            var result = getStudentList().Where(x => x.StudentId == id).FirstOrDefault();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult saveData([FromBody] Student studModel)
        {
            var lst = getStudentList().ToList();
            lst.Add(studModel);
            return Ok(lst);
        }

        [HttpPut]
        public IActionResult updateData([FromBody] Student studModel)
        {
            var obj = getStudentList().Where(x => x.StudentId == studModel.StudentId).FirstOrDefault();
            obj = studModel;
            return Ok(obj);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteData(int id)
        {
            var obj = getStudentList().Where(x => x.StudentId != id).ToList();
            return Ok(obj);
        }
    }
}
