using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aula_3.Models;

namespace Aula_3.Data
{
    public class Aula_3Context : DbContext
    {
        public Aula_3Context (DbContextOptions<Aula_3Context> options)
            : base(options)
        {
        }

        public DbSet<Aula_3.Models.Category> Category { get; set; } = default!;
    }
}
