using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsApp.Controllers.Auth;
using StudentsApp.DTOs;
using StudentsApp.Models;

namespace StudentsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        private readonly AuthRepo _repo;

        public AuthController(AuthRepo repo)
        {
            _repo = repo;
        }
       
        // GET: api/Auth
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST: api/Auth
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTOs data)
        {
            if (await _repo.StudentExist(data.username))
                return BadRequest("Username already use");

            var newStudent = await _repo.Register(new Student() { Username = data.username }, data.password);
            //return newStudent != null ? StatusCode(201) : BadRequest("Register error!");
            if (newStudent != null)
                return StatusCode(201);
            else
                return BadRequest("Register error!");
        }

    }
}
