using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FullStackAuth_WebAPI.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        

        public bool IsSitter { get; set; }
        
        public string StreetAddress { get; set; }
        public string City { get; set; }

        public string ZipCode { get; set; }

        public string? VIPServices { get; set; } 

        public string? Accommodations { get; set; } 
    }
}
