using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCHulladek.Models;

namespace MVCHulladek.Data
{
    public class MVCHulladekContext : DbContext
    {
        public MVCHulladekContext (DbContextOptions<MVCHulladekContext> options)
            : base(options)
        {
        }
        public DbSet<MVCHulladek.Models.Szolgaltatas> Szolgaltatas { get; set; } = default!;
        public DbSet<MVCHulladek.Models.Naptar> Naptar { get; set; } = default!;
        public DbSet<MVCHulladek.Models.Lakig> Lakig { get; set; } = default!;
    }
}
