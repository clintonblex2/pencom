using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PENCOMSERVICE.Models.BaseModel
{
    public class PencomResponse
    {
        public string responsecode { get; set; }

        public string responsemessage { get; set; }

        public string setId { get; set; }

        public int Counter { get; set; } = 0;

        public List<PensioneerPin> PensioneerPins { get; set; }

        public class PensioneerPin
        {
            public string PIN { get; set; }
        }
    }
}
