﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace chablon
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AdmSorskEntities : DbContext
    {
        private static AdmSorskEntities _context;
        public AdmSorskEntities()
            : base("name=AdmSorskEntities")
        {
        }

        public static AdmSorskEntities GetContext()
        {
            if (_context == null)
                _context = new AdmSorskEntities();
            return _context;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Departament> Departament { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<SumInfo> SumInfo { get; set; }
    }
}
