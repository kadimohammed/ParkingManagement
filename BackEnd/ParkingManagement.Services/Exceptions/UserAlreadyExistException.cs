using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagement.Services.Exceptions
{
    public class UserAlreadyExistException : Exception
    {
        public UserAlreadyExistException(string message) : base(message)
        {
            
        }
    }
}
