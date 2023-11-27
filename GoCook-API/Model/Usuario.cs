using System;
using System.Collections.Generic;

namespace GoCook_API.Model;

public class Usuario
{
    public int Cd_Usuario { get; set; }

    public string Nm_Usuario { get; set; }
    public string Nm_Email { get; set; }
    public string Ds_Senha { get; set; }

    // Relacionamento com Receitas
    public virtual List<Receita>? Receitas { get; set; }
}
