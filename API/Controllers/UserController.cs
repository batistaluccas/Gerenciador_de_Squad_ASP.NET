﻿using API.Services;
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

        private readonly IUserService _userService;
        public UserController(IPersonService personService, IUserService userService)
        {
            _personService = personService;
            _userService = userService;         
        }

        /// <summary>
        /// Autentica o Usuário
        /// </summary>
        /// <param name="user">Username e senha do usuário</param>
        /// <returns>Ok se estiver ok</returns>

        [HttpPost]
        public  IActionResult Login(UserModel user)
        {
            var result = _userService.Login(user);

            if (result != null)
            {
                return Ok(new
                {
                    UserId = result.Id,
                    PersonId = result.PersonId,
                    Email = result.Person.Email,
                    Username = result.Person.Username
                });
            }
            else
            {
                return Ok(new { response = "ERROR" });
            }
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

                return Ok(new { response = "ERROR" });
            }



            var personId = _personService.AddPerson(new PersonModel()
            {
                Email = user.Person.Email,
                Username = user.Person.Username,
            });

            _userService.AddUser(new UserModel()
            {
                PersonId = personId,
                Password = user.Password,

            });

            return Ok(new { response = "OK" });                
        }

        /// <summary>
        /// API para edição de usuário
        /// </summary>
        /// <param name="user">modelo de usuário</param>
        /// <returns>Ok se tudo certo</returns>
        [HttpPatch("update")]

        public IActionResult Update(UserModel user)
        {
            _userService.UpdateUser(user);

            _personService.UpdatePerson(user.Person);

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
