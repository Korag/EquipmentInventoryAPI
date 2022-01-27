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
        public void GetAssets_ReturnInMemoryDbContent()
        {
            //Arrange
            var assetController = new AssetController(new AssetRepository(new InMemoryContext()),
                                                       new UserAssetsOwnershipRepository(new InMemoryContext()), mapper);

            //Act
            var result = assetController.GetAssets().Result;

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<List<ShowAssetDto>>(okResult.Value);
            Assert.NotNull(okResult.Value);
        }

        [Theory]
        [InlineData("c579968b-4e44-40ac-a948-2abe3aefc054")]
        public void GetAssetById_ReturnAssetIfIdIsValid(string id)
        {
            //Arrange
            var assetController = new AssetController(new AssetRepository(new InMemoryContext()),
                                                       new UserAssetsOwnershipRepository(new InMemoryContext()), mapper);

            //Act
            var result = assetController.GetAsset(id).Result;

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<ShowAssetDto>(okResult.Value);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public void AddAsset_ReturnCreatedAsset()
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
            var result = assetController.PostAsset(assetDto).Result;

            //Assert
            var okResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.IsType<ShowAssetDto>(okResult.Value);
            Assert.NotNull(okResult.Value);
        }

        [Theory]
        [InlineData("c579968b-4e44-40ac-a948-2abe3aefc054")]
        public void DeleteAsset_IfAssetExist_ReturnNoContent(string id)
        {
            //Arrange
            var assetController = new AssetController(new AssetRepository(new InMemoryContext()),
                                                        new UserAssetsOwnershipRepository(new InMemoryContext()), mapper);

            //Act
            var result = assetController.DeleteAsset(id).Result;

            //Assert
            var noContentResult = Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void DeleteAsset_IfAssetNotExist_ReturnNotFound()
        {
            //Arrange
            var assetController = new AssetController(new AssetRepository(new InMemoryContext()),
                                                      new UserAssetsOwnershipRepository(new InMemoryContext()), mapper);

            var id = Guid.NewGuid().ToString();

            //Act
            var result = assetController.DeleteAsset(id).Result;

            //Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void UpdateAsset_IfAssetNotExistButIdsAreEqual_ReturnNotFound()
        {
            //Arrange
            var assetController = new AssetController(new AssetRepository(new InMemoryContext()),
                                                        new UserAssetsOwnershipRepository(new InMemoryContext()), mapper);
            var id = Guid.NewGuid();
            var idString = id.ToString();

            //Act
            var result = assetController.UpdateAsset(idString, new UpdateAssetDto() { Id = id }).Result;

            //Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void UpdateAsset_IfAssetIdsAreDifferent_ReturnBadRequest()
        {
            //Arrange
            var assetController = new AssetController(new AssetRepository(new InMemoryContext()),
                                                      new UserAssetsOwnershipRepository(new InMemoryContext()), mapper);
            var id = Guid.NewGuid();
            var idString = Guid.NewGuid().ToString();

            //Act
            var result = assetController.UpdateAsset(idString, new UpdateAssetDto() { Id = id }).Result;

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
            var result = assetController.GetAssetsByOwnerId(id).Result;

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<List<ShowAssetDto>>(okResult.Value);
            Assert.NotNull(okResult.Value);
        }
    }
}