public class Cliente : Usuario{
    private string Empresa;
    private string Telefone;
    private string CpfCnpj;
    private string Endereco;

    public Cliente( int idUsuario, string nome, string email, string senha, string empresa, string telefone,string cpfCnpj, string endereco)
    : base(idUsuario, nome, email, senha){
        this.Empresa = empresa;
        this.Telefone = telefone;
        this.CpfCnpj = cpfCnpj;
        this.Endereco = endereco;
    }

    public string Empresa{
        get { return empresa;}
        set { empresa = value}
    }

    public string Telefone{
        get { return telefone;}
        set { telefone = value}
    }

    public string CpfCnpj{
        get { return cpfCnpj;}
        set { cpfCnpj = value}
    }

    public string Endereco{
        get { return endereco;}
        set { endereco = value}
    }

    public void AbrirChamado(string titulo, string descricao){
        Console.WriteLine($"Cliente {Nome} abriu um chamado:");
        Console.WriteLine($"Título: {titulo}");
        Console.WriteLine($"Descrição: {descricao}");
        Console.WriteLine($"Empresa: {empresa}");
    }

    public void AcompanharChamado(int idChamado){
        Console.WriteLine($"Cliente estar acompanhado o chamado #{idChamado}");
        Console.WriteLine($"Contato: {telefone}");
    }

    public void AvaliarAtendimento(){
        Console.WriteLine($"Cliente {Nome} avaliou atendimento do chamado #{idChamado}");
        Console.WriteLine($"Nota: {nota}/5");
        Console.WriteLine($"Comentário: {comentario}");
    }

    public void CancelarAtendimento(){
        Console.WriteLine($"Cliente {Nome} cancelou o chamado")
        Console.WriteLine($"Motivo: solicitação do cliente")
    }
}
