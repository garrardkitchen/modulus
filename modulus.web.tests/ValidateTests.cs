using System;
using Microsoft.AspNetCore.Mvc;
using Modulus.Shared.Models;
using Modulus.Web.Controllers;
using Xunit;

namespace modulus.web.tests
{
    public class ValidateTests
    {
        [Fact]
        public void Pass_Validate_Ok_Response()
        {
            ValidateController controller = new ValidateController();
            
            AccountInfo accountInfo = new AccountInfo("0899999", "66374958");
            var result = controller.Post(accountInfo);
            Assert.IsType<OkResult>(result);
        }
        
        [Fact]
        public void Pass_Validate_Invalid_Request_Response()
        {
            ValidateController controller = new ValidateController();
            
            AccountInfo accountInfo = new AccountInfo("", "");
            var result = controller.Post(accountInfo);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Pass_Validate_NotFound_Response()
        {
            ValidateController controller = new ValidateController();
            
            AccountInfo accountInfo = new AccountInfo("100000", "12121212");
            var result = controller.Post(accountInfo);
            Assert.IsType<NotFoundObjectResult>(result);
        }

    }
}