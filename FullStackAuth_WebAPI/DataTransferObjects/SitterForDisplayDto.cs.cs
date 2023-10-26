using System.ComponentModel.DataAnnotations;
using FullStackAuth_WebAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;


namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class SitterForDisplayDto
    {
        public int Id { get; set; }
        public string VIPServices { get; set; }

        public string Accommodations { get; set; }

        public bool IsFavorited { get; set; }
        public List<ReviewByClientDto> Reviews { get; set; }
    }
}
