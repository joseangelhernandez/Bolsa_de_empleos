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

        public DbSet<ApiRestEF.Models.Categoria> Categoria { get; set; }

        public DbSet<ApiRestEF.Models.Administrador> Administrador { get; set; }

        public DbSet<ApiRestEF.Models.Poster> Poster { get; set; }

        public DbSet<ApiRestEF.Models.Puesto> Puesto { get; set; }

        public DbSet<ApiRestEF.Models.Solicita> Solicita { get; set; }

        public DbSet<ApiRestEF.Models.Solicitante> Solicitante { get; set; }
    }
}
