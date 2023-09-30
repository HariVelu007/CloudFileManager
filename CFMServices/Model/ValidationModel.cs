using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFMServices.Model
{
    public class ValidationModel<T>: Validation
    {        
        public T Model { get; set; }
    }
    public class Validation
    {
        public bool IsError { get; set; } = false;
        public string Message { get; set; } = "";
    }
}
