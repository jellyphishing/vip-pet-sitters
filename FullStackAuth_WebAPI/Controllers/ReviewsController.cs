using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.DataTransferObjects;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;


using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Security.Claims;
using FullStackAuth_WebAPI.Migrations;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost, Authorize]
        public IActionResult Post([FromBody] ReviewByClientDto reviewByClientDto)
        {
            try
            {
                //Get the user ID of the authenticated client
                string clientId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (string.IsNullOrEmpty(clientId))
                {
                    return Unauthorized("Invalid client ID");
                }

                //Check if the client exists
                var client = _context.Users.FirstOrDefault(u => u.Id == clientId && !u.IsSitter);

                if (client == null)
                {
                    return NotFound("Client not found");
                }

               // Check if the sitter(review target) exists
               var sitter = _context.Users.FirstOrDefault(u => u.Id == reviewByClientDto.SitterId && u.IsSitter);

                if (sitter == null)
                {
                    return NotFound("Sitter not found");
                }

               // Create a new review
                var review = new Review
                {
                    Text = reviewByClientDto.Text,
                    ClientId = clientId,
                    SitterId = reviewByClientDto.SitterId
                };

               // Add the review to the database
                _context.Reviews.Add(review);
                _context.SaveChanges();

                return StatusCode(201, review);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}






//using FullStackAuth_WebAPI.DataTransferObjects;
//using FullStackAuth_WebAPI.Models;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using System.Threading.Tasks;
//using System.Security.Claims;
//using FullStackAuth_WebAPI.Migrations;
//using FullStackAuth_WebAPI.Data;
//using Microsoft.AspNetCore.Authorization;
//using Org.BouncyCastle.Bcpg;
//using Microsoft.EntityFrameworkCore;

//namespace FullStackAuth_WebAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ReviewsController : ControllerBase
//    {
//        private readonly ApplicationDbContext _context;
//        public ReviewsController(ApplicationDbContext context)
//        {
//            _context = context;
//        }
//        //[HttpPost, Authorize]
//        //public IActionResult Post([FromBody] Review data)
//        //{
//        //    try
//        //    {

//        //        _context.Reviews.Add(data);
//        //        if (!ModelState.IsValid)
//        //        {
//        //            return BadRequest(ModelState);
//        //        }
//        //        _context.SaveChanges();
//        //        return StatusCode(201, data);
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        return StatusCode(500, ex.Message);
//        //    }
//        //}
//        [HttpPost]
//        [Authorize]
//        public IActionResult Post([FromBody] Review data)
//        {
//            try
//            {
//                // Check if the incoming data is null
//                if (data == null)
//                {
//                    return BadRequest("Review data is null");
//                }

//                // Add the review to the context
//                _context.Reviews.Add(data);

//                // Validate the model state
//                if (!ModelState.IsValid)
//                {
//                    return BadRequest(ModelState);
//                }

//                // Save changes to the database
//                _context.SaveChanges();

//                // Return a Created (201) status code with the created data
//                return StatusCode(201, data);
//            }
//            catch (Exception ex)
//            {
//                // Log the exception or handle it accordingly
//                return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
//            }
//        }
//        [HttpGet("{sitterId}"), Authorize]
//        public IActionResult GetClientReviews(string sitterId)
//        {
//            string clientId = User.FindFirstValue("id");
//            var reviews = _context.Reviews.Where(r => r.SitterId.Equals(sitterId) && r.ClientId.Equals(clientId)).ToList();

//            return StatusCode(200, reviews);
//        }

//        //    }
//    }
//            //[HttpGet("{sitterId}"), Authorize]
//            //public IActionResult GetClientReviews(string sitterId)
//            //{
//            //    string clientId = User.FindFirstValue("id");

////    var reviews = _context.Reviews
////        .Where(r => r.SitterId.Equals(sitterId) && r.ClientId.Equals(clientId))
////        .ToList();

////    return StatusCode(200, reviews);
////}