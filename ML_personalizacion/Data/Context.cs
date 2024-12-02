using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ML_personalizacion.Models;

namespace ML_DB
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<ML_personalizacion.Models.ML_personas> ML_personas { get; set; } = default!;
    }
}
