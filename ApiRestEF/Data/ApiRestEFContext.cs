using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiRestEF.Models;

namespace ApiRestEF.Data
{
    public class ApiRestEFContext : DbContext
    {
        public ApiRestEFContext (DbContextOptions<ApiRestEFContext> options)
            : base(options)
        {
        }

        public DbSet<ApiRestEF.Models.Usuario> Usuario { get; set; }

        public DbSet<ApiRestEF.Models.Puesto> Puesto { get; set; }

        public DbSet<ApiRestEF.Models.Categoria> Categoria { get; set; }

        public DbSet<ApiRestEF.Models.Modulo> Modulo { get; set; }

        public DbSet<ApiRestEF.Models.Operaciones> Operaciones { get; set; }

        public DbSet<ApiRestEF.Models.Rol> Rol { get; set; }

        public DbSet<ApiRestEF.Models.RolOperacion> RolOperacion { get; set; }
    }
}
