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
    public class IItemServiceTest
    {
        private Item_Dto_R itemReadDto = new Item_Dto_R() { Id = 2, Name = "Playstation 5", Price = 9000, DiscountedPrice = 8000 };
        private Item_Dto_Cu itemCreateUpdateDto = new Item_Dto_Cu() { Name = "Playstation 5", Price = 9000, DiscountedPrice = 8000 };
        private List<Item_Dto_R> itemReadDtoList = new List<Item_Dto_R>() { new Item_Dto_R
        { Id=2, Name="Playstation 5", Price=9000, DiscountedPrice=8000  } };

        [Fact]
        public void UserServiceGetAllTest()
        {
            //Arrange
            var mockItemService = new Mock<IItemService>();
            mockItemService.Setup(service => service.Get()).Returns(itemReadDtoList);
            IItemService ItemService = mockItemService.Object;

            //Act
            var result = ItemService.Get();

            //Assert
            Assert.Equal(result, itemReadDtoList);
        }
        [Fact]
        public void ItemServiceGetTest()
        {
            //Arrange
            var mockItemService = new Mock<IItemService>();
            mockItemService.Setup(service => service.Get(It.IsAny<int>())).Returns(itemReadDto);
            IItemService ItemService = mockItemService.Object;

            //Act
            var result = ItemService.Get(It.IsAny<int>());

            //Assert
            Assert.Equal(result, itemReadDto);
        }
        [Fact]
        public void ItemServiceDeleteTest()
        {
            //Arrange
            var mockItemService = new Mock<IItemService>();
            mockItemService.Setup(service => service.Delete(It.IsAny<int>())).Returns(true);
            IItemService ItemService = mockItemService.Object;

            //Act
            var result = ItemService.Delete(It.IsAny<int>());

            //Assert
            Assert.True(result);
        }
        [Fact]
        public void ItemServiceAddTest()
        {
            //Arrange
            var mockItemService = new Mock<IItemService>();
            mockItemService.Setup(service => service.Add(It.IsAny<Item_Dto_Cu>())).Returns(2);
            IItemService ItemService = mockItemService.Object;

            //Act
            var result = ItemService.Add(itemCreateUpdateDto);

            //Assert
            Assert.Equal(2, result);
        }
        [Fact]
        public void ItemServiceUpdateTest()
        {
            //Arrange
            var mockItemService = new Mock<IItemService>();
            mockItemService.Setup(service => service.Update(It.IsAny<int>(), It.IsAny<Item_Dto_Cu>())).Returns(true);
            IItemService ItemService = mockItemService.Object;

            //Act
            var result = ItemService.Update(It.IsAny<int>(), itemCreateUpdateDto);

            //Assert
            Assert.True(result);
        }
    }
}
