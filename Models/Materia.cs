using System;
using System.Collections.Generic;

namespace EscolaScaffolding.Models;

public partial class Materia
{
    public int MateriaId { get; set; }

    public string Descricao { get; set; } = null!;

    public int ProfessorId { get; set; }

    public virtual ICollection<AlunosMateria> AlunosMateria { get; set; } = new List<AlunosMateria>();

    public virtual Professore Professor { get; set; } = null!;
}
