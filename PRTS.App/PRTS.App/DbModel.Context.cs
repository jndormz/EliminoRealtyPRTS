﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PRTS.App
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbEntities : DbContext
    {
        public DbEntities()
            : base("name=DbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserPrivilege> UserPrivileges { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Agent> Agents { get; set; }
        public virtual DbSet<AreaProfile> AreaProfiles { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Lot> Lots { get; set; }
    }
}
