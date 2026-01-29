public class Usuario{
    protected int IdUsuario;
    protected string Nome;
    protected string Email;
    private string Senha;
    protected bool Ativo;

    public Usuario(int idUsuario, string nome, string email, string senha){
        this.IdUsuario = idUsuario;
        this.Nome = nome;
        this.Email = email;
        this.Senha = senha;
        this.Ativo = true
    }

    public string Email{
        get { return email; }
        protected set { email = value; }
    }

    public string Nome{
        get { return nome;}
        set { nome = value}
    }

    public int idUsuario{
        get { return = idUsuario}
    }

    public bool ativo{
        get { return ativo; }
        set { ativo = value}
    }

    public bool Login(string email, string senha){
        if (this.email == email && this.senha == senha && ativo){
        Console.WriteLine($"Usuário {nome} logado com sicesso");
        return true;
        }
        Console.WriteLine($"Email ou senha incorretos ou usário inativo");
        return false;
}

    public void Logout(){
        Console.WriteLine($"Usuário {nome} realizou logout.");
    }

    public void RecuperarSenha(){
        Console.WriteLine($"Instruções de recuperação enviadas para {email}");
    }

    public bool AlterarDados(string novoNome = null, string novoEmail = null, string senhaAtual = null, string novaSenha = null){
    bool dadosAlterados = false;

    if (!string.IsNullOrEmpty(novoNome) && novoNome != nome){
        nome = novoNome;
        Console.WriteLine($"Nome alterado para: {novoNome}");
        dadosAlterados = true;
        }

    if (!string.IsNullOrEmpty(novoEmail) && novoEmail != email){
        email = novoEmail;
        Console.WriteLine($"Email alterado para: {novoEmail}");
        dadosAlterados = true;
        }

    if (!string.IsNullOrEmpty(novaSenha)){
        if (string.IsNullOrEmpty(senhaAtual)){
            Console.WriteLine("Para alterar a senha, informe a senha atual.");
            return dadosAlterados;
            }
            if (this.senha != senhaAtual){
                Console.WriteLine("Senha atual incorreta.");
                return dadosAlterados;
                }
                if (novaSenha.Length >= 6){
                    senha = novaSenha;
                    Console.WriteLine($"Senha alterada com sucesso.");
                    dadosAlterados = true;
                    }else{
                        Console.WriteLine("A nova senha deve ter pelo menos 6 caracteres.");
                        }
                        }
                        return dadosAlterados;
                        }
}
