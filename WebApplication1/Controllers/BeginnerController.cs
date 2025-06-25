using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BeginnerController : ControllerBase
    {
        private static readonly string[] Foods = { "Pizza", "Burger", "Dosa", "Pasta" };

        [HttpGet("greet")]
        public IActionResult Greet(string name, int age)
        {
            string message = $"Hello {name}, you are {age} years old.";
            message += age < 18 ? " You're a minor." : " You're an adult.";
            return Ok(new { message });
        }

        [HttpGet("menu")]
        public IActionResult GetMenu()
        {
            var menu = Foods.Select((item, index) => new { id = index + 1, name = item });
            return Ok(menu);
        }

        [HttpGet("select")]
        public IActionResult SelectFood(int choice)
        {
            if (choice < 1 || choice > Foods.Length)
                return BadRequest("Invalid choice!");
            return Ok($"You selected: {Foods[choice - 1]}");
        }
    }
}
