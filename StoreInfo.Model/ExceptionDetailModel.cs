using System.Net;

namespace StoreInfo.Model
{
    public sealed class ExceptionDetailModel
    {
        public string Message { get; set; } = string.Empty;
        public int StatusCode { get; set; } = (int)HttpStatusCode.OK;
        public bool HasError { get; set; } = false;
        public string StackTrace { get; set; } = string.Empty;
        public string DateTime { get; set; } = string.Empty;
    }
}
