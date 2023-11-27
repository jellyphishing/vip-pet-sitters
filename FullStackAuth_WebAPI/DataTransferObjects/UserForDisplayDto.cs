using System.ComponentModel.DataAnnotations;
using FullStackAuth_WebAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class UserForDisplayDto
    {
        //DTO used when displaying User linked with FK
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string VIPServices { get; set; } //do these go here?

        public string Accommodations { get; set; } //do these go here?
        public bool IsSitter { get; set; }
    }
}
