using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EscolaScaffolding.Models;

public partial class MeuAppDbContext : DbContext
{
    public MeuAppDbContext()
    {
    }

    public MeuAppDbContext(DbContextOptions<MeuAppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aluno> Alunos { get; set; }

    public virtual DbSet<AlunosMateria> AlunosMaterias { get; set; }

    public virtual DbSet<Materia> Materias { get; set; }

    public virtual DbSet<Professore> Professores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer(File.ReadAllText("Models/.connectionstring"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aluno>(entity =>
        {
            entity.HasKey(e => e.AlunoId).HasName("PK__Alunos__1ADCAB69188B384F");

            entity.Property(e => e.AlunoId).HasColumnName("aluno_id");
            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("cpf");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Ra)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ra");
        });

        modelBuilder.Entity<AlunosMateria>(entity =>
        {
            entity.HasKey(e => e.AlunoMateriaId).HasName("PK__AlunosMa__4AA711B6E3111316");

            entity.Property(e => e.AlunoMateriaId).HasColumnName("aluno_materia_id");
            entity.Property(e => e.AlunoId).HasColumnName("aluno_id");
            entity.Property(e => e.Faltas).HasColumnName("faltas");
            entity.Property(e => e.MateriaId).HasColumnName("materia_id");
            entity.Property(e => e.Nota1)
                .HasColumnType("decimal(2, 0)")
                .HasColumnName("nota1");
            entity.Property(e => e.Nota2)
                .HasColumnType("decimal(2, 0)")
                .HasColumnName("nota2");

            entity.HasOne(d => d.Aluno).WithMany(p => p.AlunosMateria)
                .HasForeignKey(d => d.AlunoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_alunomateria_aluno_id");

            entity.HasOne(d => d.Materia).WithMany(p => p.AlunosMateria)
                .HasForeignKey(d => d.MateriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_alunomateria_materia_id");
        });

        modelBuilder.Entity<Materia>(entity =>
        {
            entity.HasKey(e => e.MateriaId).HasName("PK__Materias__9AD87C73813BD22A");

            entity.Property(e => e.MateriaId).HasColumnName("materia_id");
            entity.Property(e => e.Descricao)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descricao");
            entity.Property(e => e.ProfessorId).HasColumnName("professor_id");

            entity.HasOne(d => d.Professor).WithMany(p => p.Materia)
                .HasForeignKey(d => d.ProfessorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_materia_professor_id");
        });

        modelBuilder.Entity<Professore>(entity =>
        {
            entity.HasKey(e => e.ProfessorId).HasName("PK__Professo__7D9CA9A1AF1C3C94");

            entity.Property(e => e.ProfessorId).HasColumnName("professor_id");
            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("cpf");
            entity.Property(e => e.Matricula)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("matricula");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
