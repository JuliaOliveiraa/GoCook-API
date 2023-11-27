using GoCook_API.Model;

namespace GoCook_API.DTO;

public class ReceitaDTO
{
    public int Cd_Receita { get; set; }
    public string Nm_Receita { get; set; }
    public int Qt_TempoPreparo { get; set; }
    public string Ds_ModoPreparo { get; set; }
    public int Qt_PessoasServidas { get; set; }
    public int Cd_Usuario { get; set; }
    public List<Ingrediente> Ingredientes { get; set; }
}

