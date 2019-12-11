using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PENCOMSERVICE.Models.BaseModel
{
    public class PencomDbContext : IdentityDbContext
    {
        public PencomDbContext(DbContextOptions<PencomDbContext> options) : base(options) { }

        public virtual DbSet<ECRDataModel> ECRDataModel { get; set; }
    }
}
