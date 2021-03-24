using Fahrenheit.Resource;
using Fahrenheit.Resource.Models.Base;
using Fahrenheit.Resource.Models.User;
using Fahrenheit.Web;
using Fahrenheit.Web.Controllers;
using Fahrenheit.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json.Linq;

namespace Fahrenheit.Tests
{
    public class AuthControllerTests
    {

        [Fact]
        public async Task Login()
        {

            var mock = new Mock<IRepository>();
            mock.Setup(repo => repo.GetUser("admin")).ReturnsAsync(GetUser());
            var options = Options.Create(new AuthOptions() { Issuer = "authServer",
                                                                Audience = "resourseServer",
                                                                Secret = "secretKey1234567789+-",
                                                                TokenLifetime = 3600 });
            var controller = new AuthController(options, mock.Object);
            var contextMock = new Mock<HttpContext>();
            controller.ControllerContext.HttpContext = contextMock.Object;

            //// Act
            var result = await controller.Login(new Login { Name = GetUser().Name });
            var okResult = Assert.IsType<OkObjectResult>(result);
            var token = okResult.Value as string;

            //// Assert
            Assert.NotNull(result);
            Assert.Equal(200, okResult.StatusCode);
        }

        private User GetUser()
        {
            return new User("admin") {};
        }
    }
}
