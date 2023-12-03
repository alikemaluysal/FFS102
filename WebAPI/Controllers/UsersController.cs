using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Context;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DatabaseContext _context;

        //Constructor Injection (Dependency Injection)
        public UsersController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        public IActionResult Get()
        {
            var users = _context.Users.ToList();
            //List<User>? users = null;

            return Ok(users);
        }

        //domain.com/users/3 (route)
        //domain.com/users?id=3 (query)
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get([FromRoute] int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            if (user is null)
                return NotFound("Kullanıcı bulunamadı");

            return Ok(user);
        }


        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            if (user == null)
                return BadRequest("Hatalı giriş");

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(user);
        }

    }
}
