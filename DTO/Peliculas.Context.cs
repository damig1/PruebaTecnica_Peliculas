﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DTO
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class PeliculasEntities : DbContext
    {
        public PeliculasEntities()
            : base("name=PeliculasEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Film> Film { get; set; }
        public virtual DbSet<vFilm> vFilm { get; set; }
    
        public virtual int Delete_FilmSP(Nullable<int> filmId)
        {
            var filmIdParameter = filmId.HasValue ?
                new ObjectParameter("FilmId", filmId) :
                new ObjectParameter("FilmId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Delete_FilmSP", filmIdParameter);
        }
    }
}