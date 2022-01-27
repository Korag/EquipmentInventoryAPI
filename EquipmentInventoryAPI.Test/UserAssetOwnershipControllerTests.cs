using AutoMapper;
using EquipmentInventoryAPI.Controllers;
using EquipmentInventoryAPI.DataAccess.DbContext;
using EquipmentInventoryAPI.DataAccess.Repositories;
using EquipmentInventoryAPI.Library.DataTransferObjects;
using EquipmentInventoryAPI.Library.Profiles;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EquipmentInventoryAPI.Test
{
    public class UserAssetOwnershipControllerTests
    {
        public IMapper mapper { get; set; }
        public UserAssetOwnershipController _userAssetOwnershipController { get; set; }

        public UserAssetOwnershipControllerTests()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfiles());
            });
            mapper = mockMapper.CreateMapper();

            InMemoryContext context = new InMemoryContext();
            _userAssetOwnershipController = new UserAssetOwnershipController(new UserAssetsOwnershipRepository(context),
                                            new UserRepository(context),
                                            mapper);
        }

        [Fact]
        public void GetUsersAssets_ReturnInMemoryDbContent()
        {
            //Act
            var result = _userAssetOwnershipController.GetUsersAssets().Result;

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<List<ShowUserAssetsOwnershipDto>>(okResult.Value);
            Assert.NotNull(okResult.Value);
        }

        [Theory]
        [InlineData("c979968b-4e44-40ac-a948-2abe3aefc224")]
        public void GetUserAssetsOwnershipById_ReturnUserAssetsIfIdIsValid(string id)
        {
            //Act
            var result = _userAssetOwnershipController.GetUserAssetsOwnershipByUserId(id).Result;

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<ShowUserAssetsOwnershipDto>(okResult.Value);
            Assert.NotNull(okResult.Value);
        }

        [Theory]
        [InlineData(36)]
        public void GetUsesrAssetsOwnershipOwnedOverPeriodOfTime_ReturnUsersAssets(int months)
        {
            //Act
            var result = _userAssetOwnershipController.GetUserAssetsOwnedOverPeriodOfTime(months).Result;

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<List<ShowUserAssetsOwnershipDto>>(okResult.Value);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public void AddUserAssetOwnership_ReturnUserAssets()
        {
            var userAsset = new AddUserAssetDto();
            userAsset.AssetId = Guid.NewGuid();
            userAsset.AquireDate = DateTimeOffset.UtcNow;
            userAsset.DisposalDate = null;

            var addUserAssetDto = new AddUserAssetOwnershipDto()
            {
                UserId = Guid.NewGuid(),
                Asset = userAsset
            };

            //Act
            var result = _userAssetOwnershipController.AquireUserAssetOwnership(addUserAssetDto).Result;

            //Assert
            var okResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.IsType<ShowUserAssetsOwnershipDto>(okResult.Value);
            Assert.NotNull(okResult.Value);
        }

        [Theory]
        [InlineData("c579968b-4e44-40ac-a948-2abe3aefc224")]
        public void DeleteUserAssetsOwnership_IfItExist_ReturnNoContent(string id)
        {
            //Act
            var result = _userAssetOwnershipController.DeleteUserAssetOwnership(id).Result;

            //Assert
            var noContentResult = Assert.IsType<NoContentResult>(result);
        }

        [Theory]
        [InlineData("c579968b-4e44-40ac-a948-2abe3aefc224")]
        public void UpdateUserAssetsOwnership_IfOwnershipExistAndIdsAreEqual_ReturnNoContent(string id)
        {
            UpdateUserAssetsOwnershipDto updateUserAssetsOwnership = new UpdateUserAssetsOwnershipDto()
            {
                UserId = Guid.Parse(id),
                Assets = new List<UpdateUserAssetDto>()
            };

            //Act
            var result = _userAssetOwnershipController.UpdateUserAssetOwnership(id, updateUserAssetsOwnership).Result;

            //Assert
            var noContentResult = Assert.IsType<NoContentResult>(result);
        }
    }
}
