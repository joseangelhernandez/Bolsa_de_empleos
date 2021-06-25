using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiRestEF.Models;

namespace Presentacion.Data
{
    public class PresentacionContext : DbContext
    {
        public PresentacionContext (DbContextOptions<PresentacionContext> options)
            : base(options)
        {
        }

        public DbSet<ApiRestEF.Models.Usuario> Usuario { get; set; }
    }
}
