﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApi.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BolsaEmpleosEntities3 : DbContext
    {
        public BolsaEmpleosEntities3()
            : base("name=BolsaEmpleosEntities3")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<categoria> categorias { get; set; }
        public virtual DbSet<modulo> moduloes { get; set; }
        public virtual DbSet<operacione> operaciones { get; set; }
        public virtual DbSet<puesto> puestoes { get; set; }
        public virtual DbSet<rol> rols { get; set; }
        public virtual DbSet<rol_operacion> rol_operacion { get; set; }
        public virtual DbSet<usuario> usuarios { get; set; }
    }
}
