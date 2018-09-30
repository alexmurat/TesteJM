using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationC.Models
{
    public class SampleDataBase : DbContext
    {
        public SampleDataBase (DbContextOptions<SampleDataBase> options)
            : base(options)
        {
        }

        public DbSet<WebApplicationC.Models.Usuario> Usuario { get; set; }
    }
}
