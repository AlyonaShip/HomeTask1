using HomeTask1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public ActionResult<string> Post([FromBody] User user)
        {

            string error = "error message";
            return error;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
           
            return users.ToArray();
            //string myObj = "[{\"Status\":\"Team Work Rocks\"},[{\"ProjectA\":\"1\"},{\"ProjectB\":\"2\"},{\"ProjectC\":\"3\"}]]";
            //return new JsonResult(myObj);

        }

        [HttpPut]
        public ActionResult<string> Put([FromBody] User user)
        {                        
            string myObj = user.FirstName + " " + user.LastName;
            return myObj;
        }

        //[HttpDelete]
        //public ActionResult<string> Delete()
        //{
            
        //}
    }

    //public class User
    //{
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //}
}
