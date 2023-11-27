namespace GoCook_API.Model;

public class Ingrediente
{
    public int Cd_Ingrediente { get; set; }
    public int Cd_Receita { get; set; }
    public string Nm_Ingrediente { get; set; }
    public string Qt_Ingrediente { get; set; }

    // Relacionamento com Receita
    public Receita Receita { get; set; }
}