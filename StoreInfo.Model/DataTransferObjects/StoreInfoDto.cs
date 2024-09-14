namespace StoreInfo.Model.DataTransferObjects
{
    public sealed class StoreInfoDto
    {
        public string OrderType { get; set; } = string.Empty;
        public string IsImport { get; set; } = string.Empty;
        public string PickupStoreNo { get; set; } = string.Empty;
        public string PickupStoreName { get; set; } = string.Empty;
        public string PickupLat { get; set; } = string.Empty;
        public string PickupLon { get; set; } = string.Empty;
        public string PickupAddress { get; set; } = string.Empty;
        public string PickupContactFirstName { get; set; } = string.Empty;
        public string PickupContactLastName { get; set; } = string.Empty;
        public string PickupContactEmail { get; set; } = string.Empty;
        public string PickupContactMobileNo { get; set; } = string.Empty;
        public string PickupEnableSMS { get; set; } = string.Empty;
        public string PickupTime { get; set; } = string.Empty;
        public string PickupToleranceMin { get; set; } = string.Empty;
        public string PickupServiceTime { get; set; } = string.Empty;
        public string DeliveryStoreNo { get; set; } = string.Empty;
        public string DeliveryStoreName { get; set; } = string.Empty;
        public string DeliveryLat { get; set; } = string.Empty;
        public string DeliveryLon { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;
        public string DeliveryContactFirstName { get; set; } = string.Empty;
        public string DeliveryContactLastName { get; set; } = string.Empty;
        public string DeliveryContactEmail { get; set; } = string.Empty;
        public string DeliveryContactMobileNo { get; set; } = string.Empty;
        public string DeliveryEnableSMS { get; set; } = string.Empty;
        public string DeliveryTime { get; set; } = string.Empty;
        public string DeliveryToleranceMin { get; set; } = string.Empty;
        public string DeliveryServiceTime { get; set; } = string.Empty;
        public string OrderDetails { get; set; } = string.Empty;
        public string AssignedDriver { get; set; } = string.Empty;
        public string CustomerReference { get; set; } = string.Empty;
        public string Payer { get; set; } = string.Empty;
        public string Vehicle { get; set; } = string.Empty;
        public string Weight { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
    }
}
