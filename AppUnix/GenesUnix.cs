using Desarrollo.Core.Aplication.Services;
using Desarrollo.Core.Domain.DTO;
using Desarrollo.Core.Domain.Models;
using Desarrollo.Core.Persistencia.Context;
using Desarrollo.Core.Persistencia.Hubs;
using Desarrollo.Core.Persistencia.Repositories.Common;
using DesarrollodeEtapas.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Moq;

namespace AppUnix
{
    public class GenesUnix
    {
      

        [Fact]
        public async Task Add_InvalidDescription_ReturnsErrorMessage()
        {
            // Arrange
            var mockProcess = new Mock<IProcess<ModGene>>();
            var mockHub = new Mock<IHubContext<NotificationHub>>();
            var service = new DTOServices(mockProcess.Object, mockHub.Object);

            var modGene = new ModGene { Description = "", DueDate = DateTime.Now.AddDays(1) };

            // Act
            var result = await service.Add(modGene);

            // Assert
            Assert.True(result.Successful);
            Assert.Equal("Tiene que ser una fecha futura y la descripcion no puede estar vacia", result.Message);
        }






    }
}