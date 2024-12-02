using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ML_personalizacion.Models;

namespace ML_API1.Data
{
    public class ML_API1Context : DbContext
    {
        public ML_API1Context (DbContextOptions<ML_API1Context> options)
            : base(options)
        {
        }

        public DbSet<ML_personalizacion.Models.ML_personas> ML_personas { get; set; } = default!;
    }
}
