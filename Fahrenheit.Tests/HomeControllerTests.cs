using Fahrenheit.Resource;
using Fahrenheit.Resource.Models.Base;
using Fahrenheit.Web;
using Fahrenheit.Web.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Fahrenheit.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public async Task ReturnListGuns()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(repo =>repo.GetGuns()).ReturnsAsync(GetGuns());
            var controller = new HomeController(mock.Object);

            // Act
            var result = await controller.GetGuns();

            // Assert
            var okObjectResult = result as OkObjectResult;
            Assert.Equal(200, okObjectResult.StatusCode);
            Assert.IsAssignableFrom<IEnumerable<Gun>>(okObjectResult.Value);
        }
        [Fact]
        public async Task ReturnListCharacters()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(repo => repo.GetCharactersWithGuns()).ReturnsAsync(GetСharacters());
            var controller = new HomeController(mock.Object);

            // Act
            var result = await controller.GetCharacters();

            // Assert
            var okObjectResult = result as OkObjectResult;
            Assert.Equal(200, okObjectResult.StatusCode);
            Assert.IsAssignableFrom<IEnumerable<Сharacter>>(okObjectResult.Value);
        }

        private List<Gun> GetGuns()
        {
            var guns = new List<Gun>();
            guns.Add(
                new Gun("Gun1", 10) { Damage = 10, FireRate = 2, ReloadSpeed = 10, MagazineSize = 3 }
                );
            guns.Add(
                new Gun("Gun2", 15) { Damage = 5, FireRate = 5, ReloadSpeed = 7, MagazineSize = 10 }
                );
            guns.Add(
                new Gun("Gun3", 20) { Damage = 15, FireRate = 1, ReloadSpeed = 20, MagazineSize = 1 }
                );
            return guns;
        }
        private List<Сharacter> GetСharacters()
        {
            var characters = new List<Сharacter>
            {
                    new Сharacter("Char1", 100 ),
                    new Сharacter("Char2", 150 )
            };
            return characters;
        }
    }
}
