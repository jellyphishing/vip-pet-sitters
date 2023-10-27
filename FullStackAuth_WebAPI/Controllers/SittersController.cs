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
using System.Reflection.Metadata.Ecma335;

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SittersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public SittersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPut]
        public IActionResult Put(int id, [FromBody] User user)
        {
            var userToUpdate = _context.Users.Find(id);
            if (userToUpdate == null)
            {
                return NotFound();
            }
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Email = user.Email;
            userToUpdate.PhoneNumber = user.PhoneNumber;
            userToUpdate.StreetAddress = user.StreetAddress;
            userToUpdate.City = user.City;
            userToUpdate.ZipCode = user.ZipCode;
            userToUpdate.IsSitter = user.IsSitter; //should this be included?
            userToUpdate.VIPServices = user.VIPServices;
            userToUpdate.Accommodations = user.Accommodations;



            _context.Users.Update(userToUpdate);
            _context.SaveChanges();
            return Ok(userToUpdate);
        }


        [HttpGet] //Gets all sitters by filtering through 2 diff users and counts the favorites of the sitter
        public IActionResult GetAllSitters() 
        {
            var users = _context.Users.Where(u => u.IsSitter.Equals(true)).Select(u => new TableSittersForDisplayDto
            {
                Id = u.Id,
                VIPServices = u.VIPServices,
                Accommodations = u.Accommodations,
                FavoriteCount = _context.Favorites.Where(f => f.SitterId.Equals(u.Id)).Count()
            }

            );

            return StatusCode(200, users );
        }

        [HttpGet("{sitterId}")] //gets a sitters details page after clicking on a specific sitter and then posts their info and reviews
        public IActionResult GetSitter(string sitterId)
        {
            var sitterReviews = _context.Reviews.Where(r => r.SitterId.Equals(sitterId)).Include(r => r.Client).Select(r => new ReviewByClientDto
             {
                Id = r.Id,
                SitterId = r.SitterId,
                Text = r.Text,
                User = new UserForDisplayDto 
                {
                    Id = r.Client.Id, 
                    FirstName = r.Client.LastName,
                    LastName = r.Client.LastName,
                }

             }).ToList();

            return StatusCode(200, sitterReviews);
        }

    }
}
