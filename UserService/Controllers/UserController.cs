using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private IEnumerable<User> getUserList()
        {
            List<User> lst = new List<User>()
            {
                new User {UserId=1,Name="Test1",Address="Pune"},
                new User {UserId=2,Name="Test2",Address="Mumbai"},
                new User {UserId=3,Name="Test3",Address="Pune"},
                new User {UserId=4,Name="Test4",Address="Mumbai"}
            };

            return lst;
        }

        //[HttpGet("getData")]
        //public IActionResult getData()
        //{
        //    List<User> lst = new List<User>()
        //    {
        //        new User {UserId=1,Name="Test1",Address="Pune"},
        //        new User {UserId=2,Name="Test2",Address="Mumbai"},
        //        new User {UserId=3,Name="Test3",Address="Pune"},
        //        new User {UserId=4,Name="Test4",Address="Mumbai"}
        //    };
        //    return Ok(lst);
        //}

        //[HttpGet("getData/{id}")]
        //public IActionResult getData(int id)
        //{
        //    List<User> lst = new List<User>()
        //    {
        //        new User {UserId=1,Name="Test1",Address="Pune"},
        //        new User {UserId=2,Name="Test2",Address="Mumbai"},
        //        new User {UserId=3,Name="Test3",Address="Pune"},
        //        new User {UserId=4,Name="Test4",Address="Mumbai"}
        //    };

        //    var result = lst.Where(x => x.UserId == id).FirstOrDefault();
        //    return Ok(result);
        //}

        [HttpGet]
        public IActionResult getData()
        {
            var result = getUserList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult getData(int id)
        {
            var result = getUserList().Where(x => x.UserId == id).FirstOrDefault();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult saveData([FromBody] User userModel)
        {
            var lst = getUserList().ToList();
            lst.Add(userModel);
            return Ok(lst);
        }

        [HttpPut]
        public IActionResult updateData([FromBody] User userModel)
        {
            var obj = getUserList().Where(x => x.UserId == userModel.UserId).FirstOrDefault();
            obj = userModel;
            return Ok(obj);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteData(int id)
        {
            var obj = getUserList().Where(x => x.UserId != id).ToList();
            return Ok(obj);
        }
    }
}
