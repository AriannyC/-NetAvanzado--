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
        private readonly Mock<IProcess<ModGene>> _mockProcess;
        private readonly Mock<IHubContext<NotificationHub>> _mockHub;
        private readonly DTOServices _service;

        public GenesUnix()
        {
            _mockProcess = new Mock<IProcess<ModGene>>();
            _mockHub = new Mock<IHubContext<NotificationHub>>();
            _service = new DTOServices(_mockProcess.Object, _mockHub.Object);
        }

        [Fact]
        public async Task Add_InvalidDescription()
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

        [Fact]
      public void insertat()
        {
            // Arrange
            var mockProcess = new Mock<IProcess<ModGene>>();
            var mockHub = new Mock<IHubContext<NotificationHub>>();
            var service = new DTOServices(mockProcess.Object, mockHub.Object);

            string descripcion = "Descripcion";

            string Status = "proceso";

          var mod=  new ModGene
            {
                Description = descripcion,
                Status = Status

            };
            var res = service.Add(mod);
            Assert.Equal(descripcion, mod.Description);
            Assert.Equal(Status,mod.Status);






        }


        [Fact]
        public async Task ItemExists()
        {
            // Arrange
            var expectedGene = new ModGene { Id = 1, Description = "Tarea de prueba", DueDate = DateTime.Now.AddDays(-1) };

            _mockProcess.Setup(p => p.GetByAsync(1)).ReturnsAsync(expectedGene);

            // Act
            var result = await _service.Getby(1);

            // Assert
            Assert.True(result.Successful);
            Assert.Equal(expectedGene, result.SingleData);
        }

        [Fact]
        public async Task idexiste()
        {
            var expectedGene = new ModGene { Id = 1 };


            _mockProcess.Setup(p => p.GetByAsync(1)).ReturnsAsync(expectedGene);
            var result = await _service.Getby(1);

            // Assert
            Assert.True(result.Successful);
            Assert.Equal(expectedGene, result.SingleData);

        }


        [Fact]
        public async Task Calculate_ReturnsDaysUntilDueDate()
        {
            // Arrange
            var mockProcess = new Mock<IProcess<ModGene>>();
            var mockHub = new Mock<IHubContext<NotificationHub>>();
            var service = new DTOServices(mockProcess.Object, mockHub.Object);

            var tarea = new ModGene { DueDate = DateTime.Now.AddDays(2) };

            // Act
            var resultado = await service.Calculate(tarea);

            // Assert
            Assert.True(resultado.Successful);
            Assert.Contains("1", resultado.Message);
        }


        [Fact]
        public void CalculateCompletionRate_ShouldReturnCorrectPercentage()
        {
            // Arrange
            var tareas = new List<ModGene>
    {
        new ModGene { Status = "Completo" },
        new ModGene { Status = "Completo" },
        new ModGene { Status = "Pendiente" }
    };

            // Act
            var porcentaje = DTOServices.CalculateCompletionRate(tareas);

            // Assert 
            Assert.Equal(66.67, porcentaje, 2);
        }


        [Fact]
        public async Task GetAll_ReturnsAllItems()
        {
            // Arrange
            var mockProcess = new Mock<IProcess<ModGene>>();
            var mockHub = new Mock<IHubContext<NotificationHub>>();
            var service = new DTOServices(mockProcess.Object, mockHub.Object);

            mockProcess.Setup(p => p.GetAllAsync())
                       .ReturnsAsync(new List<ModGene> { new ModGene(), new ModGene() });

            // Act
            var result = await service.Getall();

            // Assert
            Assert.True(result.Successful);
            Assert.Equal(2, result.DataList.Count());
        }



    }
}