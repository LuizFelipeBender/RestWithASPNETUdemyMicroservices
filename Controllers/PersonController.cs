using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNETUdemy.Models;
using RestWithASPNETUdemy.Services.Implementation;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber)&& IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber)+ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber)&& IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

         [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber)&& IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

         [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber)&& IsNumeric(secondNumber))
            {
                var sum = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) /2;
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }
        
        
         [HttpGet("square-root/{firstNumber}")]
        public IActionResult SquareRoot(string firstNumber)
        {
            if(IsNumeric(firstNumber))
            {
                var SquareRoot = Math.Sqrt((double)ConvertToDecimal(firstNumber)) ;
                return Ok(SquareRoot.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if(decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber)&& IsNumeric(secondNumber))
            {
                var sum = (ConvertToDecimal(firstNumber)/ConvertToDecimal(secondNumber)) ;
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("Person/1")]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }


        [HttpGet("Person/2/{id}")]
        public IActionResult Get(ulong id)
        {
            var person = _personService.FindByID(id);
            if(person == null) return NotFound();
            return Ok();
        }

        [HttpPost("Person/3")]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personService.Create(person));
        }

        
        [HttpPut("Person/4")]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personService.Update(person));
        }

        
        [HttpDelete("Person/5/{id}")]
        public IActionResult Delete(ulong id)
        {
            _personService.Delete(id);
            return NoContent();
        }
        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse
            (strNumber, 
            System.Globalization.NumberStyles.Any,
            System.Globalization.NumberFormatInfo.InvariantInfo,
            out number);
            return isNumber; 
            throw new NotImplementedException();        }
    }
}
