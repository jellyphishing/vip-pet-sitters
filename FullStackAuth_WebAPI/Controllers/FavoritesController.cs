using FullStackAuth_WebAPI.DataTransferObjects;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Security.Claims;
using FullStackAuth_WebAPI.Migrations;
using FullStackAuth_WebAPI.Data;
using Microsoft.AspNetCore.Authorization;

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FavoritesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet, Authorize]
        public IActionResult GetClientsFavorites()
        {
            try
            {
                string clientId = User.FindFirstValue("id");
                var favorites = _context.Favorites.Where(f => f.ClientId.Equals(clientId));
                return StatusCode(200, favorites);
            }
            catch (Exception ex) 
            {
            return StatusCode(500, ex);
            }

        }
        

        [HttpPost, Authorize]

        public IActionResult Post([FromBody] Favorite data)
        {
            try 
            {
                _context.Favorites.Add(data);
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _context.SaveChanges();
                return StatusCode(201, data);
            
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
