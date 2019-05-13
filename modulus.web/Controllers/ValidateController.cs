using System;
using Microsoft.AspNetCore.Mvc;
using Modulus.Api;
using Modulus.Api.Helper;
using Modulus.Shared.Models;

namespace Modulus.Web.Controllers
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
               _wt = new WeightTable(new TextFile());
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