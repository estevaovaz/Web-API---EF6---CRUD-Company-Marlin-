using MarlinAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MarlinAPI.Repository
{
    public class MARLIN_DbContext : DbContext
    {
        public MARLIN_DbContext() : base("MARLIN")
        {

        }

        public virtual DbSet<Aluno> Alunos { get; set; }
        public virtual DbSet<Turma> Turmas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //TABELA ALUNO    

            modelBuilder.Entity<Aluno>().HasKey(e => e.Matricula);

            modelBuilder.Entity<Aluno>().ToTable("Aluno");

            modelBuilder.Entity<Aluno>().Property(x => x.Matricula)
                .IsRequired()
                .HasColumnName("Matricula");
               

            modelBuilder.Entity<Aluno>().Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar")
                .HasMaxLength(50);

            modelBuilder.Entity<Turma>().Property(x => x.numTurma)
                .HasColumnName("numTurma")
                .HasColumnType("varchar")
                .HasMaxLength(50);

            //TABELA Turma    

            modelBuilder.Entity<Turma>().HasKey(e => e.ID);

            modelBuilder.Entity<Turma>().ToTable("Turma");

            modelBuilder.Entity<Turma>().Property(x => x.ID)
                .IsRequired()
                .HasColumnName("ID");

            modelBuilder.Entity<Turma>().Property(x => x.numTurma)
               .HasColumnName("numTurma")
               .HasColumnType("varchar")
               .HasMaxLength(50);



            //TABELA USUARIO    

            modelBuilder.Entity<Usuario>().HasKey(e => e.ID);

            modelBuilder.Entity<Usuario>().ToTable("Usuario");

            modelBuilder.Entity<Usuario>().Property(x => x.ID)
                .IsRequired()
                .HasColumnName("ID");


            modelBuilder.Entity<Usuario>().Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar")
                .HasMaxLength(50);

            modelBuilder.Entity<Usuario>().Property(x => x.Senha)
                .HasColumnName("Senha")
                .HasColumnType("varchar")
                .HasMaxLength(10);

        }

    }
}