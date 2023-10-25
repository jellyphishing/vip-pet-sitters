using System.ComponentModel.DataAnnotations;

namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class UserForDisplayDto
    {
        //DTO used when displaying User linked with FK
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; } //Why do I need a UserName displayed?

        public string VIPServices { get; set; } //I want this displayed only if theyre a sitter.

        public string Accommodations { get; set; } //I want this disaplyed only if theyre a sitter.
    }
}
