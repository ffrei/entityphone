﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityPhone.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class appEntities : DbContext
    {
        public appEntities()
            : base("name=appEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<call_history> call_history { get; set; }
        public virtual DbSet<client> client { get; set; }
        public virtual DbSet<history> history { get; set; }
        public virtual DbSet<option> option { get; set; }
        public virtual DbSet<plan> plan { get; set; }
        public virtual DbSet<sms_history> sms_history { get; set; }
        public virtual DbSet<sub_option> sub_option { get; set; }
        public virtual DbSet<subscription> subscription { get; set; }
    }
}