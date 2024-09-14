using System.ComponentModel.DataAnnotations;

namespace StoreInfo.Web.Models
{
    public sealed class FileUploadViewModel
    {
        //[Required(ErrorMessage = "Please enter file name")]
        //public string FileName { get; set; }
        [Required(ErrorMessage = "Please select file")]
        public IFormFile File { get; set; }

        public bool IsRenderView { get; set; } = false;

        public IEnumerable<string> ColumnNames { get; set; } = Enumerable.Empty<string>();
    }
}
