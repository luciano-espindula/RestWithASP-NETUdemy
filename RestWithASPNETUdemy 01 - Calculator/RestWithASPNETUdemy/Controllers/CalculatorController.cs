using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase {

        // GET api/Calculator/sum/5/5
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber) {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid imput");
        }

        // GET api/Calculator/subtraction/5/5
        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber) {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) {
                var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid imput");
        }

        // GET api/Calculator/multiplication/5/5
        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber) {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) {
                var multiplication = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(multiplication.ToString());
            }
            return BadRequest("Invalid imput");
        }

        // GET api/Calculator/division/5/5
        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber) {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) {
                if (ConvertToDecimal(secondNumber) > 0) {
                    var division = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                    return Ok(division.ToString());
                }
                return BadRequest("Division by Zero");
            }
            return BadRequest("Invalid imput");
        }

        // GET api/Calculator/mean/5/5
        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber) {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) {
                var mean = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
                return Ok(mean.ToString());
            }
            return BadRequest("Invalid imput");
        }

        // GET api/Calculator/square-root/5
        [HttpGet("square-root/{Number}")]
        public IActionResult SquareRoot(string Number) {
            if (IsNumeric(Number)) {
                var squareRoot = Math.Sqrt((double)ConvertToDecimal(Number));
                return Ok(squareRoot.ToString());
            }
            return BadRequest("Invalid imput");
        }

        private decimal ConvertToDecimal(string Number) {
            decimal decimalValue;
            if (decimal.TryParse(Number, out decimalValue)) {
                return decimalValue;
            }
            return 0;
        }

        private bool IsNumeric(string sNumber) {
            double number;
            bool isNumber = double.TryParse(sNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return isNumber;
        }
    }
}

