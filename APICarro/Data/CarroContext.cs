using APICarro.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICarro.Data
{
    public class CarroContext : DbContext
    {
        public CarroContext(DbContextOptions<CarroContext> opt) : base(opt)
        {

        }

        public DbSet<Carro> Carros { get; set; }
    }
}
