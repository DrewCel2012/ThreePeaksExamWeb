using StoreInfo.Model.DataTransferObjects;

namespace StoreInfo.Repository.Interface
{
    public interface IStoreInfoRepository
    {
        Task<IList<StoreInfoDto>> GetAllAsync(string filename);

        IEnumerable<string> GetColumnNames(string filename);
    }
}
