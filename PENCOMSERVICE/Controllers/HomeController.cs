using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PENCOMSERVICE.Extensions.Alerts;
using PENCOMSERVICE.Models;
using PENCOMSERVICE.Models.BaseModel;
using PENCOMSERVICE.Models.Interface;
using PENCOMSERVICE.Models.ViewModel;

namespace PENCOMSERVICE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private PencomDbContext _dbContext;
        private PFAContext _pfaContext;
        private IMAGESContext _imagesContext;
        public bool IsLoading { get; set; } = true;
        private IPencomService _pencomService;
        LoadDataViewModel loadDataModel = new LoadDataViewModel();
        PaginationModel paginationModel = new PaginationModel();
        public List<ECRDataModel> ecrData = new List<ECRDataModel>();

        public HomeController(ILogger<HomeController> logger, PencomDbContext context, PFAContext pfaContext, IMAGESContext imagesContext, IPencomService iPencomService)
        {
            _logger = logger;
            _dbContext = context;
            _pfaContext = pfaContext;
            _imagesContext = imagesContext;
            IsLoading = true;
            _pencomService = iPencomService;
           
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //var ximoData = _dbContext.ECRDataModel.ToList();
            
            
            paginationModel = new PaginationModel();

            ecrData = await _pencomService.GetPaginatedDataResult();
            int count = ecrData.Count();

            loadDataModel.ECRDataModelList = ecrData;
            loadDataModel.IsLoading = IsLoading;
            loadDataModel.Count = count;
            
            return View(loadDataModel).WithSuccess($"Successfully acquired {count} users data from ECR database", "");
        }

        [HttpGet]
        public async Task<IActionResult> Search(string searchString)
        {
            paginationModel = new PaginationModel();
            ecrData = await _pencomService.GetSearchResult(searchString);
            int count = ecrData.Count();

            loadDataModel.ECRDataModelList = ecrData;
            loadDataModel.IsLoading = IsLoading;
            loadDataModel.Count = count;

            return View(loadDataModel).WithSuccess($"Search Results for {searchString} : {count} {(count > 1 ? "Results" : "Result")}", "");
        }

        //[HttpPost]
        public async Task<IActionResult> Submit(List<ECRDataModel> eCRDataModels)
        {
            ecrData = await _pencomService.GetPaginatedDataResult();
            var result = new PencomResponse();

            foreach (var data in ecrData)
            {
                result = await _pencomService.SubmitData(data);
            }
            // Create SubmitData ViewModel and pass all the needed fields to it
            return RedirectToAction(nameof(SubmittedData)).WithSuccess($"Successfully submitted {result.Counter} users data to ECR database for Recapture Processing","");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SubmittedData(int page = 1, int pageSize = 50)
        {
            var dataCount = await _pencomService.GetSubmittedCount();
            ecrData = await _pencomService.GetSubmittedData(page, pageSize);
            ViewData["TotalPages"] = (int)Math.Ceiling(decimal.Divide(dataCount, pageSize));
            ViewData["CurrentPage"] = page;

            loadDataModel.ECRDataModelList = ecrData;
            loadDataModel.IsLoading = IsLoading;
            loadDataModel.Count = ecrData.Count();
            
            return View(loadDataModel);
        }

        [HttpGet]
        public async Task<IActionResult> AcceptedData(int page = 1, int pageSize = 50)
        {
            var dataCount = await _pencomService.GetAcceptedCount();
            ecrData = await _pencomService.GetAcceptedData(page, pageSize);
            ViewData["TotalPages"] = (int)Math.Ceiling(decimal.Divide(dataCount, pageSize));
            ViewData["CurrentPage"] = page;

            loadDataModel.ECRDataModelList = ecrData;
            loadDataModel.IsLoading = IsLoading;
            loadDataModel.Count = ecrData.Count();

            return View(loadDataModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
