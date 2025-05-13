using System;
using System.Collections.Generic;

namespace EscolaScaffolding.Models;

public partial class AlunosMateria
{
    public int AlunoMateriaId { get; set; }

    public int MateriaId { get; set; }

    public int AlunoId { get; set; }

    public decimal Nota1 { get; set; }

    public decimal Nota2 { get; set; }

    public int Faltas { get; set; }

    public virtual Aluno Aluno { get; set; } = null!;

    public virtual Materia Materia { get; set; } = null!;
}
