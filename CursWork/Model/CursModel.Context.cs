﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CursWork.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CursWorkEntities : DbContext
    {
        public CursWorkEntities()
            : base("name=CursWorkEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Pack> Pack { get; set; }
        public virtual DbSet<PackRef> PackRef { get; set; }
        public virtual DbSet<Reference> Reference { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<SavedPack> SavedPack { get; set; }
        public virtual DbSet<SavedRef> SavedRef { get; set; }
        public virtual DbSet<Subscriber> Subscriber { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
