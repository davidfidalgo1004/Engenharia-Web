using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aula7.Models;

namespace Aula7.Data
{
    public class Aula7Context : DbContext
    {
        public Aula7Context (DbContextOptions<Aula7Context> options)
            : base(options)
        {
        }

        public DbSet<Aula7.Models.User> User { get; set; } = default!;
    }
}
