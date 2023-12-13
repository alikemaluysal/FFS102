using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Context;
using WebAPI.DTOs;
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


        //domain.com/kullanicigetir (route)

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        public IActionResult Get()
        {
            var users = _context.Users.ToList();
            //List<User>? users = null;
            return Ok(users);
        }

        //domain.com/users/6 (route)
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
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult Create([FromBody] UserCreateDto dto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (dto == null)
                return BadRequest("Hatalı giriş");

            try
            {
                //Manuel Mapping -> Auto Mapping (Auto Mapper)
                User user = new User()
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Email = dto.Email,
                };

                _context.Users.Add(user);
                _context.SaveChanges();
                return Ok(user);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromBody] User user)
        {

            try
            {
                _context.Users.Update(user);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
                return BadRequest("Bu id'li bir kullanıcı bulunamadı");

            _context.Users.Remove(user);
            _context.SaveChanges();
            return Ok(user);
        }

    }
}
