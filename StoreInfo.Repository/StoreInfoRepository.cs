using StoreInfo.Common.Helpers;
using StoreInfo.Model.DataTransferObjects;
using StoreInfo.Repository.Interface;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;

namespace StoreInfo.Repository
{
    public sealed class StoreInfoRepository : IStoreInfoRepository
    {
        private readonly string _connectionString;

        public StoreInfoRepository()
        {
            _connectionString = ConfigurationHelper.GetConfigurationValue<string>("ConnectionStrings:ExcelConnection");
        }


        public async Task<IList<StoreInfoDto>> GetAllAsync(string filename)
        {
            string connectionString = string.Format(_connectionString, filename);

            List<StoreInfoDto> storeInfoList = new();

            using OleDbConnection connection = new(connectionString);
            if (connection.State == ConnectionState.Closed)
                connection.Open();

            using OleDbCommand command = new("SELECT * FROM [Sheet1$A1:AI16]", connection);
            using DbDataReader reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    storeInfoList.Add(
                        new StoreInfoDto
                        {
                            AssignedDriver = reader["Assigned Driver"].ToString(),
                            CustomerReference = reader["Customer reference"].ToString(),
                            DeliveryContactEmail = reader["Delivery Contact Email"].ToString(),
                            DeliveryContactFirstName = reader["Delivery Contact First Name"].ToString(),
                            DeliveryContactLastName = reader["Delivery Contact Last Name"].ToString(),
                            DeliveryContactMobileNo = reader["Delivery Contact Mobile Number (need 0 at the front)"].ToString(),
                            DeliveryEnableSMS = reader["Delivery Enable SMS Notification_(No=0/Yes=1)"].ToString(),
                            DeliveryAddress = reader["Delivery formatted Address"].ToString(),
                            DeliveryLat = reader["Delivery lat _(req if adding new customer)"].ToString(),
                            DeliveryLon = reader["Delivery long_(req if adding new customer)"].ToString(),
                            DeliveryServiceTime = reader["Delivery Service Time (min)"].ToString(),
                            DeliveryStoreNo = reader["Delivery store #"].ToString(),
                            DeliveryStoreName = reader["Delivery store Name"].ToString(),
                            DeliveryTime = reader["Delivery Time"].ToString(),
                            DeliveryToleranceMin = reader["Delivery Tolerance (Min past Delivery Time)"].ToString(),
                            IsImport = reader["Import _(No=0/Yes=1)"].ToString(),
                            OrderDetails = reader["Order Details"].ToString(),
                            OrderType = reader["Order type _(Pickup/Delivery/_Pickup-Delivery)"].ToString(),
                            Payer = reader["Payer"].ToString(),
                            PickupContactEmail = reader["Pickup Contact Email"].ToString(),
                            PickupContactMobileNo = reader["Pickup Contact Mobile Number"].ToString(),
                            PickupContactFirstName = reader["Pickup Contact Name First Name"].ToString(),
                            PickupContactLastName = reader["Pickup Contact Name Last Name"].ToString(),
                            PickupEnableSMS = reader["Pickup Enable SMS Notification"].ToString(),
                            PickupAddress = reader["Pickup formatted Address"].ToString(),
                            PickupLat = reader["Pickup lat"].ToString(),
                            PickupLon = reader["Pickup lon"].ToString(),
                            PickupServiceTime = reader["Pickup Service Time"].ToString(),
                            PickupStoreNo = reader["Pickup store #"].ToString(),
                            PickupStoreName = reader["Pickup store Name"].ToString(),
                            PickupTime = reader["Pickup Time"].ToString(),
                            PickupToleranceMin = reader["Pickup tolerance (min)"].ToString(),
                            Price = reader["Price"].ToString(),
                            Vehicle = reader["Vehicle"].ToString(),
                            Weight = reader["Weight"].ToString()
                        }
                     );
                }
            }

            return storeInfoList;
        }

        public IEnumerable<string> GetColumnNames(string filename)
        {
            string connectionString = string.Format(_connectionString, filename);

            IEnumerable<string> columnNames = Enumerable.Empty<string>();

            using OleDbConnection connection = new(connectionString);
            if (connection.State == ConnectionState.Closed)
                connection.Open();

            DataTable schemaDT = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, null);
            DataRow[] shtRows = schemaDT.Select("[TABLE_NAME] = 'Sheet1$'");
            columnNames = shtRows.Select(x => x.Field<string>("COLUMN_NAME"));

            return columnNames;
        }
    }
}
