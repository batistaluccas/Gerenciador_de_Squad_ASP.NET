using API.Services;
using API.Validator;
using Common;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IPersonService _personService;
        public UserController(IPersonService personService)
        {
            _personService = personService;
        }

        /// <summary>
        /// Autentica o Usuário
        /// </summary>
        /// <param name="user">Username e senha do usuário</param>
        /// <returns>Ok se estiver ok</returns>

        [HttpPost]
        public  IActionResult Login(UserModel user)
        {
            if (user.Password == "123")
                return Ok(new { response = "OK" });
            else
                return Ok(new { response = "ERROR" });
        }

        /// <summary>
        /// API para criar usuário
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public IActionResult Create(UserModel user)
        {
            UserValidator validator = new UserValidator();

            ValidationResult results = validator.Validate(user);

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
            }


            if (user.Password == "123")
                return Ok(new { response = "OK" });
            else
                return Ok(new { response = "ERROR" });
        }

        /// <summary>
        /// API para resetar senha
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("forgot")]
        public IActionResult Forgot([FromBody] string email)
        {
            return Ok(new { response = "OK" });
        }

        /// <summary>
        /// API para redefinir a senha
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("reset")]
        public IActionResult Reset(UserModel user)
        {
            return Ok(new {response = "OK"});
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            _personService.AddPerson(new PersonModel()
            {
                Email="alalal@alala.com",
                Username="Caslu"
            });
            return Ok(new { response = "OK" });
        }
    }
}
