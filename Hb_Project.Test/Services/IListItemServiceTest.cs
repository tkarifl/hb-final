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
    public class IListItemServiceTest
    {
        private ListItem_Dto_R listItemReadDto = new ListItem_Dto_R() { Id = 2, ItemId = 3, ListId = 4 };
        private ListItem_Dto_Cu listItemCreateUpdateDto = new ListItem_Dto_Cu() { ItemId = 3, ListId = 4 };
        private List<ListItem_Dto_R> listItemReadDtoList = new List<ListItem_Dto_R>() { new ListItem_Dto_R
        { Id = 2, ItemId = 3, ListId = 4 } };
        private List<ListItem_Dto_Cu> listItemCreateUpdateDtoList = new List<ListItem_Dto_Cu>() { new ListItem_Dto_Cu
        { ItemId = 3, ListId = 4 } };

        [Fact]
        public void ListItemServiceGetAllTest()
        {
            //Arrange
            var mockListItemService = new Mock<IListItemService>();
            mockListItemService.Setup(service => service.Get()).Returns(listItemReadDtoList);
            IListItemService ListItemService = mockListItemService.Object;

            //Act
            var result = ListItemService.Get();

            //Assert
            Assert.Equal(result, listItemReadDtoList);
        }
        [Fact]
        public void ListItemServiceGetTest()
        {
            //Arrange
            var mockListItemService = new Mock<IListItemService>();
            mockListItemService.Setup(service => service.Get(It.IsAny<int>())).Returns(listItemReadDto);
            IListItemService ListItemService = mockListItemService.Object;

            //Act
            var result = ListItemService.Get(It.IsAny<int>());

            //Assert
            Assert.Equal(result, listItemReadDto);
        }
        [Fact]
        public void ListItemServiceDeleteTest()
        {
            //Arrange
            var mockListItemService = new Mock<IListItemService>();
            mockListItemService.Setup(service => service.Delete(It.IsAny<int>())).Returns(true);
            IListItemService ListItemService = mockListItemService.Object;

            //Act
            var result = ListItemService.Delete(It.IsAny<int>());

            //Assert
            Assert.True(result);
        }
        [Fact]
        public void ListItemServiceAddTest()
        {
            //Arrange
            var mockListItemService = new Mock<IListItemService>();
            mockListItemService.Setup(service => service.Add(It.IsAny<ListItem_Dto_Cu>())).Returns(2);
            IListItemService ListItemService = mockListItemService.Object;

            //Act
            var result = ListItemService.Add(listItemCreateUpdateDto);

            //Assert
            Assert.Equal(2, result);
        }
        [Fact]
        public void ListItemServiceUpdateTest()
        {
            //Arrange
            var mockListItemService = new Mock<IListItemService>();
            mockListItemService.Setup(service => service.Update(It.IsAny<int>(), It.IsAny<ListItem_Dto_Cu>())).Returns(true);
            IListItemService ListItemService = mockListItemService.Object;

            //Act
            var result = ListItemService.Update(It.IsAny<int>(), listItemCreateUpdateDto);

            //Assert
            Assert.True(result);
        }
        [Fact]
        public void ListItemServiceBulkAddTest()
        {
            //Arrange
            string output = "Added 3 items";
            var mockListItemService = new Mock<IListItemService>();
            mockListItemService.Setup(service => service.BulkAdd(It.IsAny<List<ListItem_Dto_Cu>>())).Returns(output);
            IListItemService ListItemService = mockListItemService.Object;

            //Act
            var result = ListItemService.BulkAdd(listItemCreateUpdateDtoList);

            //Assert
            Assert.Equal(result,output);
        }
        [Fact]
        public void ListItemServiceBulkDeleteTest()
        {
            //Arrange
            string output = "Deleted 3 items";
            List<int> testList = new List<int>() { 1, 2, 3, 4 };
            var mockListItemService = new Mock<IListItemService>();
            mockListItemService.Setup(service => service.BulkDelete(It.IsAny<List<int>>())).Returns(output);
            IListItemService ListItemService = mockListItemService.Object;

            //Act
            var result = ListItemService.BulkDelete(testList);

            //Assert
            Assert.Equal(result, output);
        }
    }
}
