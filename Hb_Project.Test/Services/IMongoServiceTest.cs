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
    public class IMongoServiceTest
    {
        private List<Report_Dto> reportDtoList = new List<Report_Dto>() { new Report_Dto
        { ItemId=2, ItemName="Iphone 8", count=3  } };

        [Fact]
        public void GetGeneralFavouriteItemsTest()
        {
            //Arrange
            var mockMongoService = new Mock<IMongoService>();
            mockMongoService.Setup(service => service.GetGeneralFavouriteItems()).Returns(reportDtoList);
            IMongoService MongoService = mockMongoService.Object;

            //Act
            var result = MongoService.GetGeneralFavouriteItems();

            //Assert
            Assert.Equal(result, reportDtoList);
        }

        [Fact]
        public void GetUserFavouriteItemsTest()
        {
            //Arrange
            var mockMongoService = new Mock<IMongoService>();
            mockMongoService.Setup(service => service.GetUserFavouriteItems(It.IsAny<int>())).Returns(reportDtoList);
            IMongoService MongoService = mockMongoService.Object;

            //Act
            var result = MongoService.GetUserFavouriteItems(It.IsAny<int>());

            //Assert
            Assert.Equal(result, reportDtoList);
        }
    }
}
