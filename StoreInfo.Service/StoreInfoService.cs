using StoreInfo.Model.DataTransferObjects;
using StoreInfo.Repository.Interface;
using StoreInfo.Service.Interface;

namespace StoreInfo.Service
{
    public sealed class StoreInfoService : IStoreInfoService
    {
        private readonly IStoreInfoRepository _storeInfoRepository;
        
        public StoreInfoService(IStoreInfoRepository storeInfoRepository)
        {
            _storeInfoRepository = storeInfoRepository;
        }

        //public StoreInfoService()
        //{
        //    _storeInfoRepository = new StoreInfoRepository();
        //}


        public async Task<IList<StoreInfoDto>> GetAllAsync(string filename)
        {
            return await _storeInfoRepository.GetAllAsync(filename);
        }

        public IEnumerable<string> GetColumnNames(string filename)
        {
            return _storeInfoRepository.GetColumnNames(filename);
        }
    }
}
