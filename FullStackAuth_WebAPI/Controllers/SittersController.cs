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
    [Route("api/[controller")]
    [ApiController]
    public class SittersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public SittersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
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

        [HttpGet("{sitterId}")]
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
