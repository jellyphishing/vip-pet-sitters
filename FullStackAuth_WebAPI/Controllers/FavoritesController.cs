using FullStackAuth_WebAPI.DataTransferObjects;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Security.Claims;
using FullStackAuth_WebAPI.Migrations;
using FullStackAuth_WebAPI.Data;
using Microsoft.AspNetCore.Authorization;
using Org.BouncyCastle.Cms;
using Microsoft.EntityFrameworkCore;

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
        //[HttpGet("{clientId}"), Authorize]
        //public IActionResult GetClientFavorites(string clientId)
        //{
        //    var clientFavorites = _context.Favorites.Where(f => f.ClientId.Equals(clientId)).Include(f => f.Sitter).Include(f => f.Client).ToList();
        //    return StatusCode(200, clientFavorites);
        //}

        [HttpGet("{clientId}"), Authorize]
        public IActionResult GetClientFavorites(string clientId)
        {
            
            var clientFavorites = _context.Favorites.Where(f => f.ClientId.Equals(clientId)).Include(f => f.Sitter).Include(f => f.Client).ToList();
            return StatusCode(200, clientFavorites);
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

        [HttpGet("count/{sitterId}"), Authorize]
        public IActionResult GetSitterFavoritesCount(string sitterId)
        {
            try
            {
                int favoritesCount = _context.Favorites.Count(f => f.SitterId.Equals(sitterId));
                return StatusCode(200, new { SitterId = sitterId, FavoritesCount = favoritesCount });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
