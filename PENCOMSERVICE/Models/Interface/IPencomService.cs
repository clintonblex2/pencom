using PENCOMSERVICE.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PENCOMSERVICE.Models.Interface
{
    public interface IPencomService
    {
        Task<List<ECRDataModel>> GetPaginatedDataResult();
        Task<List<ECRDataModel>> GetPaginatedDataByDate(DateTime start, DateTime end);
        Task<int> GetPaginatedDataByDateCount(DateTime start, DateTime end);
        //Task<int> GetCount();
        Task<PencomResponse> SubmitData(ECRDataModel model);
        Task<List<ECRDataModel>> GetSubmittedData(int page, int pageSize);
        Task<List<ECRDataModel>> GetAwaitingStatusData(int page, int pageSize);
        Task<List<ECRDataModel>> GetAcceptedData(int page, int pageSize);
        string GetRequestStatus(string pin);
        Task<int> GetAcceptedCount();
        Task<int> GetSubmittedCount();
        Task<int> GetAwaitingStatusCount();

        Task<List<ECRDataModel>> GetXimoData();
        Task<List<ECRDataModel>> GetSearchResult(string searchString);
    }
}
