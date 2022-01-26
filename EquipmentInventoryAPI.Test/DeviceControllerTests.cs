using AutoMapper;
using EquipmentInventoryAPI.Controllers;
using EquipmentInventoryAPI.DataAccess.Models;
using EquipmentInventoryAPI.DataAccess.Repositories;
using EquipmentInventoryAPI.Library.DataTransferObjects;
using EquipmentInventoryAPI.Library.Profiles;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace EquipmentInventoryAPI.Test
{
    public class DeviceControllerTests
    {
        [Fact]
        public void GetDevices_ReturnInMemoryDbContent()
        {
            //Auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfiles());
            });
            var mapper = mockMapper.CreateMapper();

            var deviceController = new DeviceController(new DeviceRepository(new DataAccess.DbContext.InMemoryContext()), mapper);

            //Act
            var result = deviceController.GetDevices().Result;

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<List<ShowDeviceDto>>(okResult.Value);
            Assert.NotNull(okResult.Value);
        }

        [Theory]
        [InlineData("c579968b-4e44-40ac-a948-2abe3aefc054")]
        public void GetDeviceById_ReturnDeviceIfIdIsValid(string id)
        {
            //Auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfiles());
            });
            var mapper = mockMapper.CreateMapper();
            var deviceController = new DeviceController(new DeviceRepository(new DataAccess.DbContext.InMemoryContext()), mapper);

            //Act
            var result = deviceController.GetDevice(id).Result;

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<ShowDeviceDto>(okResult.Value);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public void AddDevice_ReturnCreatedDevice()
        {
            //Auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfiles());
            });
            var mapper = mockMapper.CreateMapper();
    
            var addDeviceDto = new AddDeviceDto()
            {
                SerialNumber = "ABVC",
                Name = "Test notebook 3",
                PresentPrice = 5200,
                PurchasePrice = 2000,
                PurchaseDate = System.DateTime.UtcNow
            };

            addDeviceDto.Model = new AddDeviceModelDto()
            {
                ModelNumber = "ASDASDASD"
            };

            addDeviceDto.Model.Manufacturer = new AddManufacturerDto()
            {
                Name = "Test",
                ContactNumber = "123456789",
                EmailAddress = "test@test.com",
                Country = "Poland",
                City = "XYZ",
                Address = "Polna 1"
            };

            var deviceController = new DeviceController(new DeviceRepository(new DataAccess.DbContext.InMemoryContext()), mapper);

            //Act
            var result = deviceController.PostDevice(addDeviceDto).Result;

            //Assert
            var okResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.IsType<ShowDeviceDto>(okResult.Value);
            Assert.NotNull(okResult.Value);
        }

        [Theory]
        [InlineData("c579968b-4e44-40ac-a948-2abe3aefc054")]
        public void DeleteDevice_IfDeviceExist_ReturnNoContent(string id)
        {
            //Auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfiles());
            });
            var mapper = mockMapper.CreateMapper();

            var deviceController = new DeviceController(new DeviceRepository(new DataAccess.DbContext.InMemoryContext()), mapper);

            //Act
            var result = deviceController.DeleteDevice(id).Result;

            //Assert
            var noContentResult = Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void DeleteDevice_IfDeviceNotExist_ReturnNotFound()
        {
            //Auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfiles());
            });
            var mapper = mockMapper.CreateMapper();

            var deviceController = new DeviceController(new DeviceRepository(new DataAccess.DbContext.InMemoryContext()), mapper);
            var id = Guid.NewGuid().ToString();

            //Act
            var result = deviceController.DeleteDevice(id).Result;

            //Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void UpdateDevice_IfDeviceNotExistButIdsAreEqual_ReturnNotFound()
        {
            //Auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfiles());
            });
            var mapper = mockMapper.CreateMapper();

            var deviceController = new DeviceController(new DeviceRepository(new DataAccess.DbContext.InMemoryContext()), mapper);
            var id = Guid.NewGuid();
            var idString = id.ToString();

            //Act
            var result = deviceController.UpdateDevice(idString, new UpdateDeviceDto() { Id = id }).Result;

            //Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
        }
    }
}
