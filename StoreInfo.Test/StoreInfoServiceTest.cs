using Moq;
using StoreInfo.Model.DataTransferObjects;
using StoreInfo.Repository.Interface;
using StoreInfo.Service;
using StoreInfo.Test.MockDataObjects;

namespace StoreInfo.Test
{
    public sealed class StoreInfoServiceTest
    {
        private readonly Mock<IStoreInfoRepository> _storeInfoRepositoryMock;

        public StoreInfoServiceTest()
        {
            _storeInfoRepositoryMock = new Mock<IStoreInfoRepository>();                
        }


        [Fact]
        public void GetAllAsync_ShouldReturnListOfStoreInfo()
        {
            ShouldReturnListOfStoreInfo().Wait();
        }

        [Fact]
        public void GetColumnNames_ShouldReturnListOfColumnNames()
        {
            IEnumerable<string> _listMockData = StoreInfoMockData.GetColumnNamesMockData();

            //Arrange:
            _storeInfoRepositoryMock.Setup(x => x.GetColumnNames(It.IsAny<string>())).Returns(_listMockData);
            var _storeInfoService = new StoreInfoService(_storeInfoRepositoryMock.Object);

            //Act:
            IEnumerable<string> result = _storeInfoService.GetColumnNames("");

            //Assert:
            Assert.NotNull(result);
            Assert.True(result.Count() > 1);
        }


        private async Task ShouldReturnListOfStoreInfo()
        {
            IList<StoreInfoDto> _listMockData = StoreInfoMockData.GetStoreInfoMockData();

            //Arrange:
            _storeInfoRepositoryMock.Setup(x => x.GetAllAsync(It.IsAny<string>())).Returns(Task.FromResult(_listMockData));
            var _storeInfoService = new StoreInfoService(_storeInfoRepositoryMock.Object);

            //Act:
            IList<StoreInfoDto> result = await _storeInfoService.GetAllAsync("");

            //Assert:
            Assert.NotNull(result);
            Assert.True(result.Count > 1);
        }
    }
}