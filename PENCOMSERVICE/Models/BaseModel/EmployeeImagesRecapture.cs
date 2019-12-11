using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PENCOMSERVICE.Models.BaseModel
{
    public partial class EmployeeImagesRecapture
    {
        public string RegistrationCode { get; set; }
        public string Pin { get; set; }
        public byte[] PictureImage { get; set; }
        public byte[] SignatureImage { get; set; }
        public byte[] Thumbprint { get; set; }
        public byte[] Thumbprint1 { get; set; }
        public decimal? InvestorId { get; set; }
        public decimal Transid { get; set; }

    }
}
