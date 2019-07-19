using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitafeAPI.Web.Api.Model
{
    public class EmployeeModel
    {
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ImagePath { get; set; }
        public string ContactPhone { get; set; }
        public string EmailAdress { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
