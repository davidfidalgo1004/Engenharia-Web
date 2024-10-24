using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aula5.Models;

namespace Aula5.Data
{
    public class Aula5Context : DbContext
    {
        public Aula5Context (DbContextOptions<Aula5Context> options)
            : base(options)
        {
        }

        public DbSet<Aula5.Models.Book> Book { get; set; } = default!;
    }
}
