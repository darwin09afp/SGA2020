﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SIGA.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SIGADBEntities : DbContext
    {
        public SIGADBEntities()
            : base("name=SIGADBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TBL_MARCAS> TBL_MARCAS { get; set; }
        public virtual DbSet<TBL_MOVIMIENTOS> TBL_MOVIMIENTOS { get; set; }
        public virtual DbSet<TBL_PRODUCTOS> TBL_PRODUCTOS { get; set; }
        public virtual DbSet<TBL_PROVEEDORES> TBL_PROVEEDORES { get; set; }
        public virtual DbSet<TBL_TIPOS> TBL_TIPOS { get; set; }
        public virtual DbSet<TBL_UBICACIONES> TBL_UBICACIONES { get; set; }
    }
}
