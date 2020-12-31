using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Curso_Ectotec_Back.Models.Entities
{
    public partial class curso2020Context : DbContext
    {
        public curso2020Context()
        {
        }

        public curso2020Context(DbContextOptions<curso2020Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Grupo> Grupos { get; set; }
        public virtual DbSet<GrupoPersona> GrupoPersonas { get; set; }
        public virtual DbSet<Materium> Materia { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=ectotec-cursos.database.windows.net;Initial Catalog=curso-2020;Persist Security Info=True;User ID=ectoadmin;Password=Ectotec.2020;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.ToTable("Grupo");

                entity.HasComment("Listado de grupos.");

                entity.Property(e => e.GrupoId).HasColumnName("GrupoID");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.MateriaId).HasColumnName("MateriaID");

                entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);

                entity.HasOne(d => d.Materia)
                    .WithMany(p => p.Grupos)
                    .HasForeignKey(d => d.MateriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grupo_Materia");
            });

            modelBuilder.Entity<GrupoPersona>(entity =>
            {
                entity.HasKey(e => new { e.GrupoId, e.PersonaId });

                entity.ToTable("GrupoPersona");

                entity.HasComment("Tabla de relación entre grupos y personas.");

                entity.Property(e => e.GrupoId).HasColumnName("GrupoID");

                entity.Property(e => e.PersonaId).HasColumnName("PersonaID");

                entity.HasOne(d => d.Grupo)
                    .WithMany(p => p.GrupoPersonas)
                    .HasForeignKey(d => d.GrupoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GrupoPersona_Grupo");

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.GrupoPersonas)
                    .HasForeignKey(d => d.PersonaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GrupoPersona_Persona");
            });

            modelBuilder.Entity<Materium>(entity =>
            {
                entity.HasKey(e => e.MateriaId);

                entity.HasComment("Catálogo de materias.");

                entity.Property(e => e.MateriaId)
                    .HasColumnName("MateriaID")
                    .HasComment("Identificador único de la materia.");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasComment("Titulo de la materia.");

                entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("Persona");

                entity.HasComment("Listado de personas");

                entity.Property(e => e.personaId).HasColumnName("PersonaID");

                entity.Property(e => e.correo).HasMaxLength(500);

                entity.Property(e => e.nombreCompleto).HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
