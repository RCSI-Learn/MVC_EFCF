#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC_EFCF.Models;

namespace MVC_EFCF.Data
{
    public class MVC_EFCFContext : DbContext
    {
        public MVC_EFCFContext (DbContextOptions<MVC_EFCFContext> options)
            : base(options)
        {
        }

        public DbSet<MVC_EFCF.Models.TaxDocument> TaxDocument { get; set; }
    }
}
