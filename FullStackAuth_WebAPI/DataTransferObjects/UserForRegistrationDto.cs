﻿using System.ComponentModel.DataAnnotations;

namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class UserForRegistrationDto
    {
        //DTO used when registering
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string StreetAddress { get; set; }
        public string City { get; set; }

        public string ZipCode { get; set; }
        public bool IsSitter { get; set; }
        public string VIPServices { get; set; } 
        public string Accommodations { get; set; }
        public string AllAboutMe { get; set; }



    }
}
