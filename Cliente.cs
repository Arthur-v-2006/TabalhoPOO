public class Cliente : Usuario
{
    private string Empresa;
    private string Telefone;
    private string CpfCnpj;
    private string Endereco;

    public Cliente(
        int idUsuario,
        string nome,
        string email,
        string senha,
        string empresa,
        string telefone,
        string cpfCnpj,
        string endereco
    ) : base(idUsuario, nome, email, senha)
    {
        Empresa = empresa;
        Telefone = telefone;
        CpfCnpj = cpfCnpj;
        Endereco = endereco;
    }

    public void AbrirChamado()
    {
    }

    public void AcompanharChamado()
    {
    }

    public void AvaliarAtendimento()
    {
    }

    public void CancelarAtendimento()
    {
    }
}
