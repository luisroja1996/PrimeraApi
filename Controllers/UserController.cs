using PrimeraApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace PrimeraApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private static List<ResponseUser> users = new List<ResponseUser>()
        {
            new ResponseUser {Nombre = "Milena", Edad = 25, Categoria = "mayor de edad"},
            new ResponseUser {Nombre = "Gabriel", Edad = 5, Categoria = "menor de edad"},
            new ResponseUser {Nombre = "Valentino", Edad = 68, Categoria = "mayor de edad"},
            new ResponseUser {Nombre = "Sofía", Edad = 13, Categoria = "menor de edad"},
            new ResponseUser {Nombre = "Carlos", Edad = 30, Categoria = "mayor de edad"},
            new ResponseUser {Nombre = "Isabella", Edad = 7, Categoria = "menor de edad"},
            new ResponseUser {Nombre = "Laura", Edad = 86, Categoria = "mayor de edad"}
        };

        [HttpGet]
        [Route("GetUsers")]
        public IEnumerable<ResponseUser> GetUsers()
        {
            return users;
        }

        [HttpPost]
        [Route("CreateUser")]
        public ActionResult<ResponseUser> CreateUser(RequestUser requestUser)
        {
            if (requestUser.Edad < 0)
            {
                return BadRequest("La edad no puede ser negativa.");
            }

            var responseUser = new ResponseUser
            {
                Nombre = requestUser.Nombre,
                Edad = requestUser.Edad,
                Categoria = requestUser.Edad >= 18 ? "mayor de edad" : "menor de edad"
            };

            users.Add(responseUser);
            return Ok(responseUser);
            //sdvsdvds
        }
    }

}