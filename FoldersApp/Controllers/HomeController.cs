using FoldersApp.Application.Services.Interfaces;
using FoldersApp.Models;
using FoldersApp.Persistance.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FoldersApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDigitalImgFolderService _digitalService;
        private readonly IResourceFolderService _resourceService;
        private readonly IEvidenceFolderService _evidenceService;
        private readonly IGraphicProductFolderService _graphicProductService;
        private readonly IPrimarySourceFolderService _primarySourceService;
        private readonly ISecondarySourceFolderService _secondarySourceService;
        private readonly IProcessFolderService _processService;
        private readonly IFinalProductFolderService _finalProductService;

        public HomeController(IDigitalImgFolderService digitalService, IResourceFolderService resourceService, IEvidenceFolderService evidenceService, IGraphicProductFolderService graphicProductService, IPrimarySourceFolderService primarySourceService, ISecondarySourceFolderService secondarySourceService, IProcessFolderService processService, IFinalProductFolderService finalProductService)
        {
            _digitalService = digitalService;
            _resourceService = resourceService;
            _evidenceService = evidenceService;
            _graphicProductService = graphicProductService;
            _primarySourceService = primarySourceService;
            _secondarySourceService = secondarySourceService;
            _processService = processService;
            _finalProductService = finalProductService;
        }

        public IActionResult GetDigitalImgFolder()
        {
            var model = _digitalService.GetDigitalImgFolder();
            return View(model);
        }

        public IActionResult ResourceFolder()
        {
            var model = _resourceService.GetResourceFolder();
            return View(model);
        }

        public IActionResult EvidenceFolder()
        {
            var model = _evidenceService.GetEvidenceFolder();
            return View(model);
        }

        public IActionResult GraphicProductFolder()
        {
            var model = _graphicProductService.GetGraphicProductFolder();
            return View(model);
        }

        public IActionResult PrimarySourceFolder()
        {
            var model = _primarySourceService.GetPrimarySourceFolder();
            return View(model);
        }

        public IActionResult SecondarySourceFolder()
        {
            var model = _secondarySourceService.GetSecondarySourceFolder();
            return View(model);
        }

        public IActionResult ProcessFolder()
        {
            var model = _processService.GetProcessFolder();
            return View(model);
        }

        public IActionResult FinalProductFolder()
        {
            var model = _finalProductService.GetFinalProductFolder();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}