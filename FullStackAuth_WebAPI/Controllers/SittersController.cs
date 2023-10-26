using FullStackAuth_WebAPI.DataTransferObjects;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Security.Claims;
using FullStackAuth_WebAPI.Migrations;
using FullStackAuth_WebAPI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;


namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller")]
    [ApiController]
    public class SittersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public SittersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{sitterId}")]
        public IActionResult GetSitter(string sitterId)
        {
            var sitterReviews = _context.Reviews.Where(r => r.SitterId.Equals(sitterId)).Include(r => r.Client).Select(r => new ReviewByClientDto)
             {
                Id = r.Id,
                SitterId = r.sitterId,
                Text = r.Text,
                User = new UserForDisplayDto //Is this going to need Client instead of User?
                {
                    Id = r.User.Id, //Same here, do I need r.Client.Id
                    FirstName = r.User.LastName,
                    LastName = r.User.LastName,
                }

             }).ToList();

            return StatusCode(200, sitterReviews);
        }

    }
}
