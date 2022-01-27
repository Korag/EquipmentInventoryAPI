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
    public class UserControllerTests
    {
        public IMapper mapper { get; set; }
        public UserController _userController { get; set; }

        public UserControllerTests()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfiles());
            });
            mapper = mockMapper.CreateMapper();

            _userController = new UserController(new UserRepository(new InMemoryContext()),
                                                   mapper);
        }

        [Fact]
        public void GetUser_ReturnInMemoryDbContent()
        {
            //Act
            var result = _userController.GetUsers().Result;

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<List<ShowUserDto>>(okResult.Value);
            Assert.NotNull(okResult.Value);
        }

        [Theory]
        [InlineData("c979968b-4e44-40ac-a948-2abe3aefc224")]
        public void GetUserById_ReturnUserIfIdIsValid(string id)
        {
            //Act
            var result = _userController.GetUser(id).Result;

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<ShowUserDto>(okResult.Value);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public void AddUser_ReturnCreatedUser()
        {
            //Arrange
            var userDto = new AddUserDto()
            {
                FirstName = "Testing",
                LastName = "User",
                EmailAddress = "testing.user@email.com",
                ContactPhone = "987654321"
            };

            //Act
            var result = _userController.PostUser(userDto).Result;

            //Assert
            var okResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.IsType<ShowUserDto>(okResult.Value);
            Assert.NotNull(okResult.Value);
        }

        [Theory]
        [InlineData("c979968b-4e44-40ac-a948-2abe3aefc224")]
        public void DeleteUser_IfUserExist_ReturnNoContent(string id)
        {
            //Act
            var result = _userController.DeleteUser(id).Result;

            //Assert
            var noContentResult = Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void DeleteUser_IfUserNotExist_ReturnNotFound()
        {
            var id = Guid.NewGuid().ToString();

            //Act
            var result = _userController.DeleteUser(id).Result;

            //Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void UpdateUser_IfUserNotExistButIdsAreEqual_ReturnNotFound()
        {
            var id = Guid.NewGuid();
            var idString = id.ToString();

            //Act
            var result = _userController.UpdateUser(idString, new UpdateUserDto() { Id = id }).Result;

            //Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void UpdateUser_IfUserIdsAreDifferent_ReturnBadRequest()
        {
            var id = Guid.NewGuid();
            var idString = Guid.NewGuid().ToString();

            //Act
            var result = _userController.UpdateUser(idString, new UpdateUserDto() { Id = id }).Result;

            //Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
