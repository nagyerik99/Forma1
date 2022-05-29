using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Forma1.Models;

namespace Forma1.Data
{
    public class Forma1Context : DbContext
    {
        public Forma1Context (DbContextOptions<Forma1Context> options)
            : base(options)
        {
        }

        public DbSet<Forma1.Models.RaceGroup> RaceGroup { get; set; }
    }
}
