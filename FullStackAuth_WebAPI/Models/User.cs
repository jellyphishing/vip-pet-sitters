using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FullStackAuth_WebAPI.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //I think I removed username from here
        //public string UserName { get; set; } //why this one too?
        
        
        public bool IsSitter { get; set; }
       // public string PhoneNumber { get; set; } //why is this an issue??

        public string StreetAddress { get; set; }
        public string City { get; set; }

        public string ZipCode { get; set; }

        public string? VIPServices { get; set; } 

        public string? Accommodations { get; set; } 
        public string AllAboutMe { get; set; }
    }
}
