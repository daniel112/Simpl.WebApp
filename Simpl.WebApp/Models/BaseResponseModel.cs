using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simpl.WebApp.Models
{
    public class BaseResponseModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
