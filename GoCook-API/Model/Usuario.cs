using System;
using System.Collections.Generic;

namespace GoCook_API.Model;

public class Usuario
{
    // Usar GUID para cd_Usuario
    public Guid Cd_Usuario { get; set; }

    public string Nm_Usuario { get; set; }
    public string Nm_Email { get; set; }
    public string Ds_Senha { get; set; }

    // Relacionamento com Receitas
    public List<Receita> Receitas { get; set; }
}
