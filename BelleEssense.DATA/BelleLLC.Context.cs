﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BelleEssense.DATA
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BelleLLCEntities1 : DbContext
    {
        public BelleLLCEntities1()
            : base("name=BelleLLCEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Candle> Candles { get; set; }
        public virtual DbSet<Label> Labels { get; set; }
        public virtual DbSet<Lotion> Lotions { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Scent> Scents { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}