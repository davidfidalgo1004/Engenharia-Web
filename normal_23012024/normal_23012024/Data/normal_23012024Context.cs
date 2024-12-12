using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using normal_23012024.Models;

namespace normal_23012024.Data
{
    public class normal_23012024Context : DbContext
    {
        public normal_23012024Context (DbContextOptions<normal_23012024Context> options)
            : base(options)
        {
        }

        public DbSet<normal_23012024.Models.RegistoUtilizador> RegistoUtilizador { get; set; } = default!;
    }
}
