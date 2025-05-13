using System;
using System.Collections.Generic;

namespace EscolaScaffolding.Models;

public partial class Aluno
{
    public int AlunoId { get; set; }

    public string Nome { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string Ra { get; set; } = null!;

    public virtual ICollection<AlunosMateria> AlunosMateria { get; set; } = new List<AlunosMateria>();
}
