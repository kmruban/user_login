using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webapi_login.Entities;
using webapi_login.Services;

namespace webapi_login.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IUserServices _service;
        public UserController(ILogger<UserController> logger, IUserServices services)
        {
            _logger = logger;
            _service = services;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            IEnumerable<User> list = _service.GetUsers();
            if (list != null)
            {
                return Ok(list);
            }
            else
                return BadRequest();
        }

        [HttpGet("{Username}")]
        public IActionResult GetUserByName(string Username)
        {
            User obj = _service.GetUserByName(Username);
            if (obj != null)
                return Ok(obj);
            return BadRequest();
        }

        [HttpGet("{Id}")]
        public IActionResult GetUserById(string Id)
        {
            User obj = _service.GetUserById(Id);
            if (obj != null)
                return Ok(obj);
            return BadRequest();
        }

        [HttpGet("{u}/uname/{p}/pwd")]
        public IActionResult Login(string u, string p)
        {
            User obj = _service.Login(u, p);
            if (obj != null)
            {
                return Ok(obj);
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult CreateUser(User m)
        {
            _service.CreateUser(m);
            // might need to add code to return if successful
            return NoContent();
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateUser(string Id, User userIn)
        {
            _service.UpdateUser(Id, userIn);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteUser(string Id)
        {
            _service.DeleteUser(Id);
            return NoContent();
        }

    }
}

