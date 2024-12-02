using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ML_personalizacion.Models;

namespace ML_API.Data
{
    public class ML_APIContext : DbContext
    {
        public ML_APIContext (DbContextOptions<ML_APIContext> options)
            : base(options)
        {
        }

        public DbSet<ML_personalizacion.Models.ML_personas> ML_personas { get; set; } = default!;
    }
}
