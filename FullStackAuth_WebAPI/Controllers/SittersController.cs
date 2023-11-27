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
using System.Linq;

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

        [HttpPut("{id}"), Authorize]
        public IActionResult Put(string id, [FromBody] User user) //allows Sitters to update their info
        {
            var userToUpdate = _context.Users.Find(id);
            if (userToUpdate == null)
            {
                return NotFound();
            }
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.UserName = user.UserName;
            userToUpdate.Email = user.Email;
            userToUpdate.PhoneNumber = user.PhoneNumber;
            userToUpdate.StreetAddress = user.StreetAddress;
            userToUpdate.City = user.City;
            userToUpdate.ZipCode = user.ZipCode;
           // userToUpdate.IsSitter = user.IsSitter; //should this be included?
            userToUpdate.VIPServices = user.VIPServices;
            userToUpdate.Accommodations = user.Accommodations;
            userToUpdate.AllAboutMe = user.AllAboutMe;



            _context.Users.Update(userToUpdate);
            _context.SaveChanges();
            return Ok(userToUpdate);
        }


        [HttpGet, Authorize] //Gets all sitters by filtering through 2 diff users and counts the favorites of the sitter
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

            return StatusCode(200, users);
        }

        //[HttpGet("GetSitterById/{sitterId}"), Authorize]
        //public IActionResult GetSitterById(string sitterId)
        //{
        //    // Assuming there is a Sitter model in your context
        //    var sitter = _context.Sitters.Include(s => s.Reviews).Include(s => s.Favorites).FirstOrDefault(s => s.SitterId.Equals(sitterId));

        //    if (sitter == null)
        //    {
        //        return NotFound($"Sitter with id {sitterId} not found");
        //    }

        //    return Ok(sitter);
        //}






        [HttpGet("{sitterId}"), Authorize] //gets a sitters details page after clicking on a specific sitter and then posts their info and reviews
        public IActionResult GetSitterDetails(string sitterId)
        {
            var sitterReviews = _context.Reviews.Where(r => r.SitterId.Equals(sitterId)).Include(r => r.Client).Include(r => r.Sitter).ToList();




            return StatusCode(200, sitterReviews);
        }
        [HttpGet("name/{sitterName}"), Authorize] //gets a sitters details page after clicking on a specific sitter and then posts their info and reviews
        public IActionResult GetSitterByName(string sitterName)
        {

            var sitter = _context.Sitters.Where(u => u.FirstName.Equals(sitterName));

            return StatusCode(200, sitter);
        }




        [HttpGet("sitterId/{sitterId}"), Authorize] //gets a sitters details page after clicking on a specific sitter and then posts their info and reviews
        public IActionResult GetSitterById(string sitterId)
        {

            var sitter = _context.Sitters.Where(u => u.Id.Equals(sitterId));

            return StatusCode(200, sitter);
        }

        [HttpGet("accommodations/{sitterAccommodations}"), Authorize] //gets sitters based on accommodations they offer
        public IActionResult GetSitterByAccommodations(string sitterAccommodations)
        {
            var sitterByAccommodations = _context.Users.Where(u => u.Accommodations.Equals(sitterAccommodations));

            return StatusCode(200, sitterByAccommodations);
        }

        [HttpGet("VIPServices/{sitterServices}"), Authorize] //gets sitters based on VIP Services
        public IActionResult GetSitterByVIPServices(string sitterServices)
        {
            var sitterByVIPServices = _context.Users.Where(u => u.VIPServices.Equals(sitterServices));

            return StatusCode(200, sitterByVIPServices);
        }

        //URL example of "find" API route in sitters controller
        //localhost:<port>/api/sitters/find?accommodations=abc&vipservices=xyz
        [HttpGet("find")]
        public IActionResult FindSitters(string accommodations, string vipServices) {
            var results = _context.Users.Where(
                u => u.Accommodations.ToLower().Contains(accommodations.ToLower()) &&
                     u.VIPServices.ToLower().Contains(vipServices.ToLower()));

            return StatusCode(200, results);
        }

        /*
        public IActionResult FindSitters(string search_input)
        {
            var results = _context.Users.Where(
                u => u.Accommodations.StartsWith(search_input) ||
                     u.VIPServices.IndexOf(search_input) >= 0);

            return StatusCode(200, results);
        }
        */
    }
}