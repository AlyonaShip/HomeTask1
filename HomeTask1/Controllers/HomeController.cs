﻿using HomeTask1.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public List<User> Post(User user)
        {
            users.Add(user);
            return users;
        }

        [HttpGet]
        public List<User> Get()
        {           
            return users;
        }

        //[HttpPut]
        //public List<User> Put(User user)
        //{

        //}

        [HttpDelete]
        public ActionResult Delete()
        {
            //HttpStatusCode
            
            //return HttpStatusCode.BadRequest;

            return BadRequest();



        }
    }   
}
