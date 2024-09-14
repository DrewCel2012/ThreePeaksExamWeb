using StoreInfo.Model.DataTransferObjects;

namespace StoreInfo.Service.Interface
{
    public interface IStoreInfoService
    {
        Task<IList<StoreInfoDto>> GetAllAsync(string filename);

        IEnumerable<string> GetColumnNames(string filename);
    }
}
