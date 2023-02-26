using FoldersApp.DbSerializator.DbSerializator.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace FoldersApp.Controllers
{
    public class SerializatorController : Controller
    {
        private readonly ISerializator _serializator;

        public SerializatorController(ISerializator serializator) => _serializator = serializator;

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormFile xmlFile)
        {
            try
            {
                var model = _serializator.ImportXmlToDb(xmlFile);
                ViewBag.Result = model;

                return View("Success");
            }
            catch (Exception)
            {
                ViewBag.Error = "Can't import xml file";
                return View("Index");
            }
        }

        [HttpPost]
        public IActionResult ExportFromDb(string path)
        {
            if (!path.Contains(".xml")) path += ".xml";
            _serializator.ExportDbToXml(path);

            return View("Success");
        }
    }
}
