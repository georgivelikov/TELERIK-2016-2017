﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AddingSampleData
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ComputersDbEntities : DbContext
    {
        public ComputersDbEntities()
            : base("name=ComputersDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Computer> Computers { get; set; }
        public virtual DbSet<ComputerType> ComputerTypes { get; set; }
        public virtual DbSet<Cpu> Cpus { get; set; }
        public virtual DbSet<Gpu> Gpus { get; set; }
        public virtual DbSet<GpuType> GpuTypes { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<ModelType> ModelTypes { get; set; }
        public virtual DbSet<StorageDevice> StorageDevices { get; set; }
        public virtual DbSet<StorageDeviceType> StorageDeviceTypes { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
    }
}
