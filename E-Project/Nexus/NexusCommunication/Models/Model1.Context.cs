//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NexusCommunication.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NexusEntities : DbContext
    {
        public NexusEntities()
            : base("name=NexusEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<admin> admins { get; set; }
        public virtual DbSet<customer> customers { get; set; }
        public virtual DbSet<employee> employees { get; set; }
        public virtual DbSet<hourly> hourlies { get; set; }
        public virtual DbSet<order> orders { get; set; }
        public virtual DbSet<planb> planbs { get; set; }
        public virtual DbSet<planbb> planbbs { get; set; }
        public virtual DbSet<plan> plans { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<sale> sales { get; set; }
        public virtual DbSet<store> stores { get; set; }
        public virtual DbSet<unlimite> unlimites { get; set; }
        public virtual DbSet<vendor> vendors { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
    }
}
