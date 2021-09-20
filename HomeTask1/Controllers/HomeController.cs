using HomeTask1.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace HomeTask1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public static readonly List<User> users = new List<User>
        {
            new User() { FirstName = "Tyler", LastName = "Durden "},
            new User() { FirstName = "Marla", LastName = "Singer "}
        };

        [HttpPost]      
        public ObjectResult Post()
        {
            Random rnd = new Random();

            var result1 = new ObjectResult(new
            {
                code = 500,
                message = "A server error occurred.",
            });

            var result2 = new ObjectResult(new
            {
                code = 400,
                message = "Bad Request",
            });

            var result3 = new ObjectResult(new
            {
                code = 404,
                message = "Not Found",
            });
            var list = new List<ObjectResult>();
            list.Add(result1);
            list.Add(result2);
            list.Add(result3);

            int r = rnd.Next(list.Count);
            
            return list[r];
        }

        [HttpGet]
        public ActionResult<List<User>> Get()
        {            
            return users;
        }

        [HttpPut]
        public ActionResult<List<User>> Put(User user)
        {
            if (user.IsSuccess)
            {
                users.Add(user);
                return users;
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public ObjectResult Delete()
        {            
            var result = new ObjectResult(new
            {
                code = 500,
                message = "A server error occurred.",                
            });                   
            return result;
        }
    }   
}
