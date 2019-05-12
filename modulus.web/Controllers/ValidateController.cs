using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Modulus.api;
using Newtonsoft.Json.Serialization;

namespace modulus.web.Controllers
{
    [Route("api/validate")]
    [ApiController]
    public class ValidateController : ControllerBase
    {
        private static WeightTable _wt { get; set; }
       
        public ValidateController()
        {
            if (_wt == null)
            {
               _wt = new WeightTable();
               _wt.LoadFromFile();
            }
        }

            // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] AccountInfo accountInfo)
        {
            ModulusProcessor processor = new ModulusProcessor(_wt, accountInfo);

            try
            {
                if (processor.IsValid())
                {
                    // 200
                    return Ok();
                }
                else
                {
                    // 404
                    return NotFound(new {message = "Invalid account number"});
                }
            }
            catch (Exception ex)
            {
                // 400
                Console.WriteLine(ex.Message);
                // I don't know the client so masking actual exception message
                return BadRequest(new {message = "An error occurred. This has been logged and will be investigated"});
            }
        }
     
    }
}