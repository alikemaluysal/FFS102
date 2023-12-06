using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Context;
using WebAPI.DTOs;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersOdevController : ControllerBase
    {
        private static readonly List<User> _users;
        private static int _index;

        //Constructor Injection (Dependency Injection)
        static UsersOdevController()
        {
            _users = new List<User>(){ 
                new User(){Id = 1, FirstName = "Ali", LastName = "Uysal", Email = "ali@mail.com"},
                new User(){Id = 2, FirstName = "Furkan", LastName = "Güneş", Email = "furkan@mail.com"},
                new User(){Id = 3, FirstName = "Mehmet", LastName = "Okyar", Email = "mehmet@mail.com"},
            };

            _index = _users.Count + 1;
        }


        //domain.com/kullanicigetir (route)

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        public IActionResult Get()
        {
            var users = _users;
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
            var user = _users.FirstOrDefault(u => u.Id == id);

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
            if (dto == null)
                return BadRequest("Hatalı giriş");

            try
            {
                //Manuel Mapping -> Auto Mapping (Auto Mapper)
                User user = new User()
                {
                    Id = _index++,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Email = dto.Email,
                };
                _users.Add(user);
                return Ok(user);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromBody] User user, int id)
        {

            if(String.IsNullOrEmpty(user.FirstName) || String.IsNullOrEmpty(user.LastName))
            {
                return BadRequest("Ad ve soyad alanları boş geçilemez");
            }

            try
            {
                var userToUpdate = _users.FirstOrDefault(x => x.Id == id);
                int index = _users.IndexOf(userToUpdate);
                _users[index] = user;
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
            var userToDelete = _users.FirstOrDefault(x => x.Id == id);
            int index = _users.IndexOf(userToDelete);

            if (userToDelete == null)
                return NoContent();

            _users.Remove(userToDelete);
            //_users.RemoveAt(index);
            return Ok(userToDelete);
        }



        // 0: Kemal
        // 1: Mehmet
        // 3: İbrahim

    }
}
