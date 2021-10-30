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
    public class IListServiceTest
    {
        private List_Dto_R listReadDto = new List_Dto_R() { Id = 2, Name = "favourites", Description = "favourite items", Category = "favourites", UserId = 5 };
        private List_Dto_Cu listCreateUpdateDto = new List_Dto_Cu() { Name = "favourites", Description = "favourite items", Category = "favourites", UserId = 5 };
        private List<List_Dto_R> listReadDtoList = new List<List_Dto_R>() { new List_Dto_R
        { Id=2, Name="favourites",Description="favourite items",Category= "favourites",UserId=5  } };

        [Fact]
        public void UserServiceGetAllTest()
        {
            //Arrange
            var mockListService = new Mock<IListService>();
            mockListService.Setup(service => service.Get()).Returns(listReadDtoList);
            IListService ListService = mockListService.Object;

            //Act
            var result = ListService.Get();

            //Assert
            Assert.Equal(result, listReadDtoList);
        }
        [Fact]
        public void ListServiceGetTest()
        {
            //Arrange
            var mockListService = new Mock<IListService>();
            mockListService.Setup(service => service.Get(It.IsAny<int>())).Returns(listReadDto);
            IListService ListService = mockListService.Object;

            //Act
            var result = ListService.Get(It.IsAny<int>());

            //Assert
            Assert.Equal(result, listReadDto);
        }
        [Fact]
        public void ListServiceDeleteTest()
        {
            //Arrange
            var mockListService = new Mock<IListService>();
            mockListService.Setup(service => service.Delete(It.IsAny<int>())).Returns(true);
            IListService ListService = mockListService.Object;

            //Act
            var result = ListService.Delete(It.IsAny<int>());

            //Assert
            Assert.True(result);
        }
        [Fact]
        public void ListServiceAddTest()
        {
            //Arrange
            var mockListService = new Mock<IListService>();
            mockListService.Setup(service => service.Add(It.IsAny<List_Dto_Cu>())).Returns(2);
            IListService ListService = mockListService.Object;

            //Act
            var result = ListService.Add(listCreateUpdateDto);

            //Assert
            Assert.Equal(2, result);
        }
        [Fact]
        public void ListServiceUpdateTest()
        {
            //Arrange
            var mockListService = new Mock<IListService>();
            mockListService.Setup(service => service.Update(It.IsAny<int>(), It.IsAny<List_Dto_Cu>())).Returns(true);
            IListService ListService = mockListService.Object;

            //Act
            var result = ListService.Update(It.IsAny<int>(), listCreateUpdateDto);

            //Assert
            Assert.True(result);
        }
    }
}
