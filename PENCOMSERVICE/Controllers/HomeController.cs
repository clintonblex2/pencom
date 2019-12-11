using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        public List<ECRDataModel> ximoData = new List<ECRDataModel>();

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

            ximoData = await _pencomService.GetPaginatedDataResult();
            int count = await _pencomService.GetCount();

            loadDataModel.ECRDataModelList = ximoData;
            loadDataModel.IsLoading = IsLoading;
            loadDataModel.Count = count;
            
            return View(loadDataModel);
        }

        //[HttpPost]
        public async Task<IActionResult> Submit(List<ECRDataModel> eCRDataModels)
        {
            ximoData = await _pencomService.GetPaginatedDataResult();
            var result = new PencomResponse();
            foreach (var data in ximoData)
            {

                result = await _pencomService.SubmitData(data);
                
            }
            // Create SubmitData ViewModel and pass all the needed fields to it
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SubmittedData()
        {
            ximoData = await _pencomService.GetSubmittedData();

            loadDataModel.ECRDataModelList = ximoData;
            loadDataModel.IsLoading = IsLoading;
            loadDataModel.Count = ximoData.Count();
            
            return View(loadDataModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
