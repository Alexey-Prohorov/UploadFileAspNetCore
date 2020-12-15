using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UploadFileTest.Models;

namespace UploadFileTest.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        public IActionResult ReadExcelFileAsync(IFormFile file)
        {
            //if (file == null || file.Length == 0)
              //  return Content("File Not Selected");

            string fileExtension = Path.GetExtension(file.FileName);

            if (fileExtension == ".xls" || fileExtension == ".xlsx")
            {
                //var rootFolder = @"E:\Files";
                var rootFolder = @"wwwroot";
                var fileName = file.FileName;
                var filePath = Path.Combine(rootFolder, fileName);
                var fileLocation = new FileInfo(filePath);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyToAsync(fileStream);
                } 
            }
            return Ok();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
