public class Usuario
{
    protected int IdUsuario;
    protected string Nome;
    protected string Email;
    private string Senha;

    public Usuario(int idUsuario, string nome, string email, string senha)
    {
        IdUsuario = idUsuario;
        Nome = nome;
        Email = email;
        Senha = senha;
    }

    public bool Login(string senha)
    {
        return Senha == senha;
    }

    public void Logout()
    {
        // lógica de logout
    }

    public void RecuperarSenha()
    {
        // lógica de recuperação
    }

    public void AlterarDados(string nome, string email)
    {
        Nome = nome;
        Email = email;
    }
}
