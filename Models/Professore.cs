using System;
using System.Collections.Generic;

namespace EscolaScaffolding.Models;

public partial class Professore
{
    public int ProfessorId { get; set; }

    public string Nome { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string Matricula { get; set; } = null!;

    public virtual ICollection<Materia> Materia { get; set; } = new List<Materia>();
}
