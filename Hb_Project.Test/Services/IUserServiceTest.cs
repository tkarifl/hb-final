using Hb_Project.Application.Dto.Create_Update;
using Hb_Project.Application.Dto.Read;
using Hb_Project.Application.IServices;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Hb_Project.Test.Services
{
    public class IUserServiceTest
    {
        private User_Dto_R userReadDto = new User_Dto_R() { Id = 2, Name = "Morgan", Surname = "Yu", Email = "morgan_yu@gmail.com", Gsm = "05343855738" };
        private User_Dto_Cu userCreateUpdateDto = new User_Dto_Cu() { Name = "Mikhaila", Surname = "Ilyushin", Email = "ilyushin_mi@gmail.com", Gsm = "05343855738" };
        private List<User_Dto_R> userReadDtoList = new List<User_Dto_R>() { new User_Dto_R
        { Id = 5, Name = "Alex", Surname = "Yu", Email = "alex_yu@gmail.com", Gsm = "05242155257" } };

        [Fact]
        public void UserServiceGetAllTest()
        {
            //Arrange
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(service => service.Get()).Returns(userReadDtoList);
            IUserService userService = mockUserService.Object;

            //Act
            var result = userService.Get();

            //Assert
            Assert.Equal(result, userReadDtoList);
        }
        [Fact]
        public void UserServiceGetTest()
        {
            //Arrange
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(service => service.Get(It.IsAny<int>())).Returns(userReadDto);
            IUserService userService = mockUserService.Object;

            //Act
            var result = userService.Get(It.IsAny<int>());

            //Assert
            Assert.Equal(result, userReadDto);
        }
        [Fact]
        public void UserServiceDeleteTest()
        {
            //Arrange
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(service => service.Delete(It.IsAny<int>())).Returns(true);
            IUserService userService = mockUserService.Object;

            //Act
            var result = userService.Delete(It.IsAny<int>());

            //Assert
            Assert.True(result);
        }
        [Fact]
        public void UserServiceAddTest()
        {
            //Arrange
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(service => service.Add(It.IsAny<User_Dto_Cu>())).Returns(2);
            IUserService userService = mockUserService.Object;

            //Act
            var result = userService.Add(userCreateUpdateDto);

            //Assert
            Assert.Equal(2, result);
        }
        [Fact]
        public void UserServiceUpdateTest()
        {
            //Arrange
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(service => service.Update(It.IsAny<int>(), It.IsAny<User_Dto_Cu>())).Returns(true);
            IUserService userService = mockUserService.Object;

            //Act
            var result = userService.Update(It.IsAny<int>(), userCreateUpdateDto);

            //Assert
            Assert.True(result);
        }
    }
}
