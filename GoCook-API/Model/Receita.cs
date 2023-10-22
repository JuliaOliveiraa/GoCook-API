namespace GoCook_API.Model;

public class Receita
{
    public int Cd_Receita { get; set; }
    public string Nm_Receita { get; set; }
    public int Qt_TempoPreparo { get; set; }
    public string Ds_ModoPreparo { get; set; }
    public int Qt_PessoasServidas { get; set; }
    public int Cd_Usuario { get; set; }

    // Relacionamento com Ingredientes
    public List<Ingrediente> Ingredientes { get; set; }

    // Relacionamento com Usuário
    public Usuario Usuario { get; set; }
}

