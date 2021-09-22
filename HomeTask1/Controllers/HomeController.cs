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
        public ApiResponse<User> Post()
        {
            List<string> errMessages = new List<string>(new string[] { "Error1!", "Error2!", "Error3!" });
            Random r = new Random();
            int index = r.Next(errMessages.Count);
            ApiResponse<User> response = new ApiResponse<User>();            
            response.ErrorMessage = errMessages[index];
            response.IsSuccess = false;           
            return response;
        }

        [HttpGet]
        public ApiResponse<User> Get()
        {
            ApiResponse<User> response = new ApiResponse<User>();            
            response.ErrorMessage = "Success!";
            response.IsSuccess = true;
            response.ReturnObject = users;
            return response;
        }

        [HttpPut]
        public ApiResponse<User> Put(User user)
        {            
            users.Add(user);
            ApiResponse<User> response = new ApiResponse<User>();            
            response.ErrorMessage = "Success!";
            response.IsSuccess = true;
            response.ReturnObject = users;
            return response;            
        }

        [HttpDelete]
        public ApiResponse<User> Delete()
        {            
            ApiResponse<User> response = new ApiResponse<User>();                        
            try
            {                
                throw new Exception("Exception");
            }
            catch (Exception ex)
            {                
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
                return response;                
            }
        }
    }   
}
