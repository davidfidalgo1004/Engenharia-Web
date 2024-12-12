using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Normal_20232024.Models;

namespace Normal_20232024.Data
{
    public class Normal_20232024Context : DbContext
    {
        public Normal_20232024Context (DbContextOptions<Normal_20232024Context> options)
            : base(options)
        {
        }

        public DbSet<Normal_20232024.Models.Proprietario> Proprietario { get; set; } = default!;
        public DbSet<Veiculo> Veiculos { get; set; }

    }
}
