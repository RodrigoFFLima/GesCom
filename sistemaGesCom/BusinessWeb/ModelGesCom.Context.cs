﻿//------------------------------------------------------------------------------
// <auto-generated>
//    O código foi gerado a partir de um modelo.
//
//    Alterações manuais neste arquivo podem provocar comportamento inesperado no aplicativo.
//    Alterações manuais neste arquivo serão substituídas se o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessWeb
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GesComEntities : DbContext
    {
        public GesComEntities()
            : base("name=GesComEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<tb_chamados> tb_chamados { get; set; }
        public DbSet<tb_cidades> tb_cidades { get; set; }
        public DbSet<tb_empresasManutencao> tb_empresasManutencao { get; set; }
        public DbSet<tb_estado> tb_estado { get; set; }
        public DbSet<tb_licencas> tb_licencas { get; set; }
        public DbSet<tb_localizacao> tb_localizacao { get; set; }
        public DbSet<tb_maquinario> tb_maquinario { get; set; }
        public DbSet<tb_mobilias> tb_mobilias { get; set; }
        public DbSet<tb_perifericos> tb_perifericos { get; set; }
        public DbSet<tb_relacionamentos> tb_relacionamentos { get; set; }
        public DbSet<tb_usuario> tb_usuario { get; set; }
    }
}