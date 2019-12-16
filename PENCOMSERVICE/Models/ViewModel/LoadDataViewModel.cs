using PENCOMSERVICE.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PENCOMSERVICE.Models.ViewModel
{
    public class LoadDataViewModel
    {
        public bool IsLoading { get; set; } = false;
        public string Message { get; set; }
        public IEnumerable<ECRDataModel> ECRDataModelList { get; set; }
        public int Count { get; set; }
    }
}
