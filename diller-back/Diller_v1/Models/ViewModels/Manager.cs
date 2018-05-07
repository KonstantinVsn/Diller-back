using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diller.Models.ViewModels
{
    public class Manager
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class ManagerRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
    
}
