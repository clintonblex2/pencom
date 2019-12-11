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
        Task<int> GetCount();
        Task<PencomResponse> SubmitData(ECRDataModel model);
        Task<List<ECRDataModel>> GetSubmittedData();
        Task<string> GetRequestStatus(string pin);
    }
}
