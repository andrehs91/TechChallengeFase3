using FIAP.Producer.Enum;

namespace FIAP.Producer.DTO;

public class RespostaDTO(TiposDeResposta tipo, string mensagem)
{
    public TiposDeResposta Tipo { get; set; } = tipo;
    public string Mensagem { get; set; } = mensagem;

    public static RespostaDTO Aviso(string mensagem) => new(TiposDeResposta.Aviso, mensagem);
    public static RespostaDTO Erro(string mensagem) => new(TiposDeResposta.Erro, mensagem);
    public static RespostaDTO Sucesso(string mensagem) => new(TiposDeResposta.Sucesso, mensagem);
}
