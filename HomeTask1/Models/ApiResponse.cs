using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTask1.Models
{
    public class ApiResponse<T>
    {        
        public string ErrorMessage { get; set; }
        public List<T> ReturnObject { get; set; }
        public bool IsSuccess { get; set; }
    }
}
