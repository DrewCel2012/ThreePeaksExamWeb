using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StoreInfo.Model;
using StoreInfo.Service.Interface;
using StoreInfo.Web.Models;
using System.Diagnostics;
using System.Net.Mime;
using System.Text.Json;

namespace StoreInfo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStoreInfoService _storeInfoService;
        private readonly ILogger<HomeController> _logger;
        private readonly AppSetting _appSetting;

        public HomeController(ILogger<HomeController> logger, 
            IStoreInfoService storeInfoService,
            IOptions<AppSetting> appSetting)
        {
            _storeInfoService = storeInfoService;
            _appSetting = appSetting.Value;
            _logger = logger;
        }


        //public async Task<IActionResult> Index()
        //{
        //    var list = await _storeInfoService.GetAllAsync(@"D:\DREWCELFiles\_PROJECTS\_THREEPEAKS\_OTHERS\Sample import.xlsx");
        //    return View(new FileUploadViewModel { IsRenderView = false });
        //}

        public IActionResult Index()
        {
            return View(new FileUploadViewModel { IsRenderView = false });
        }


        [HttpPost]
        public IActionResult Upload(FileUploadViewModel model)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), _appSetting.TargetDirectory);

                //Create folder if not exist:
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string fileName = Path.Combine(path, model.File.FileName);

                using (FileStream stream = new(fileName, FileMode.Create))
                model.File.CopyTo(stream);

                model.ColumnNames = _storeInfoService.GetColumnNames(fileName);
                model.IsRenderView = true;
            }

            return View("Index", model);
        }


        public FileStreamResult Download()
        {
            string sourcefile = Path.Combine(Directory.GetCurrentDirectory(), _appSetting.TargetDirectory, "Sample import.xlsx");
            string filename = $"importFile_{DateTime.Now:MMddyyyy_HHmmss}.json";

            var json = JsonSerializer.Serialize(new { Message = "File does not exist." });
            if (System.IO.File.Exists(sourcefile))
            {
                var records = _storeInfoService.GetAllAsync(sourcefile);
                json = JsonSerializer.Serialize(records);
            }
            var characters = json.ToCharArray();
            var bytes = new byte[characters.Length];

            for (var i = 0; i < characters.Length; i++)
            {
                bytes[i] = (byte)characters[i];
            }
            var stream = new MemoryStream();
            stream.Write(bytes);
            stream.Position = 0;

            return File(stream, MediaTypeNames.Application.Octet, filename);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
