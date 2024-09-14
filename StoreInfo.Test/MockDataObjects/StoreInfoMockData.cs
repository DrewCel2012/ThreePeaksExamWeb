using StoreInfo.Model.DataTransferObjects;

namespace StoreInfo.Test.MockDataObjects
{
    public static class StoreInfoMockData
    {
        public static List<StoreInfoDto> GetStoreInfoMockData()
        {
            return new List<StoreInfoDto>
            {
                new() { PickupStoreNo = "001", PickupStoreName = "A STEAK IN THE GAME", PickupAddress = "100 The Pkwy, Bradbury NSW 2560, Australia" },
                new() { PickupStoreNo = "002", PickupStoreName = "SALAAM NAMASTE HALAL BUTCHERY", PickupAddress = "20 Station St, Kogarah NSW 2217, Australia" },
            };
        }

        public static IEnumerable<string> GetColumnNamesMockData()
        {
            return new List<string>
            {
                "Assigned Driver",
                "Customer reference",
                "Delivery Contact Email"
            };
        }
    }
}
