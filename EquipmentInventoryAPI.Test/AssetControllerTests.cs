using AutoMapper;
using EquipmentInventoryAPI.Controllers;
using EquipmentInventoryAPI.DataAccess.DbContext;
using EquipmentInventoryAPI.DataAccess.Repositories;
using EquipmentInventoryAPI.Library.DataTransferObjects;
using EquipmentInventoryAPI.Library.Profiles;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace EquipmentInventoryAPI.Test
{
    public class AssetControllerTests
    {
        public IMapper mapper { get; set; }

        public AssetControllerTests()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfiles());
            });
            mapper = mockMapper.CreateMapper();
        }

        [Fact]
        public void GetDevices_ReturnInMemoryDbContent()
        {
            //Arrange
            var assetController = new AssetController(new AssetRepository(new InMemoryContext()),
                                                       new UserAssetsOwnershipRepository(new InMemoryContext()), mapper);

            //Act
            var result = assetController.GetDevices().Result;

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<List<ShowAssetDto>>(okResult.Value);
            Assert.NotNull(okResult.Value);
        }

        [Theory]
        [InlineData("c579968b-4e44-40ac-a948-2abe3aefc054")]
        public void GetDeviceById_ReturnDeviceIfIdIsValid(string id)
        {
            //Arrange
            var assetController = new AssetController(new AssetRepository(new InMemoryContext()),
                                                       new UserAssetsOwnershipRepository(new InMemoryContext()), mapper);

            //Act
            var result = assetController.GetDevice(id).Result;

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<ShowAssetDto>(okResult.Value);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public void AddDevice_ReturnCreatedDevice()
        {
            //Arrange
            var assetDto = new AddAssetDto()
            {
                SerialNumber = "ABVC",
                Name = "Test notebook 3",
                PresentPrice = 5200,
                PurchasePrice = 2000,
                PurchaseDate = DateTimeOffset.UtcNow
            };

            var assetController = new AssetController(new AssetRepository(new InMemoryContext()),
                                                      new UserAssetsOwnershipRepository(new InMemoryContext()), mapper);

            //Act
            var result = assetController.PostDevice(assetDto).Result;

            //Assert
            var okResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.IsType<ShowAssetDto>(okResult.Value);
            Assert.NotNull(okResult.Value);
        }

        [Theory]
        [InlineData("c579968b-4e44-40ac-a948-2abe3aefc054")]
        public void DeleteDevice_IfDeviceExist_ReturnNoContent(string id)
        {
            //Arrange
            var assetController = new AssetController(new AssetRepository(new InMemoryContext()),
                                                        new UserAssetsOwnershipRepository(new InMemoryContext()), mapper);

            //Act
            var result = assetController.DeleteDevice(id).Result;

            //Assert
            var noContentResult = Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void DeleteDevice_IfDeviceNotExist_ReturnNotFound()
        {
            //Arrange
            var assetController = new AssetController(new AssetRepository(new InMemoryContext()),
                                                        new UserAssetsOwnershipRepository(new InMemoryContext()), mapper);

            var id = Guid.NewGuid().ToString();

            //Act
            var result = assetController.DeleteDevice(id).Result;

            //Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void UpdateDevice_IfDeviceNotExistButIdsAreEqual_ReturnNotFound()
        {
            //Arrange
            var assetController = new AssetController(new AssetRepository(new InMemoryContext()),
                                                        new UserAssetsOwnershipRepository(new InMemoryContext()), mapper);
            var id = Guid.NewGuid();
            var idString = id.ToString();

            //Act
            var result = assetController.UpdateDevice(idString, new UpdateAssetDto() { Id = id }).Result;

            //Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void UpdateDevice_IfDeviceIdsAreDifferent_ReturnBadRequest()
        {
            //Arrange
            var assetController = new AssetController(new AssetRepository(new InMemoryContext()),
                                                        new UserAssetsOwnershipRepository(new InMemoryContext()), mapper);
            var id = Guid.NewGuid();
            var idString = Guid.NewGuid().ToString();

            //Act
            var result = assetController.UpdateDevice(idString, new UpdateAssetDto() { Id = id }).Result;

            //Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        }

        [Theory]
        [InlineData("c579968b-4e44-40ac-a948-2abe3aefc224")]
        public void GetAssetsByUserId_ReturnAssetIfIdIsValid(string id)
        {
            //Arrange
            var assetController = new AssetController(new AssetRepository(new InMemoryContext()), 
                                                        new UserAssetsOwnershipRepository(new InMemoryContext()), mapper);

            //Act
            var result = assetController.GetDevicesByOwnerId(id).Result;

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<List<ShowAssetDto>>(okResult.Value);
            Assert.NotNull(okResult.Value);
        }
    }
}
