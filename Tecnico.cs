public class Tecnico : Usuario
{
    private string Especialidade;
    private string Nivel;
    private int QtdChamadosResolvidos;
    private TimeSpan CargaHoraria;

    public Tecnico(
        int idUsuario,
        string nome,
        string email,
        string senha,
        string especialidade,
        string nivel,
        TimeSpan cargaHoraria
    ) : base(idUsuario, nome, email, senha)
    {
        Especialidade = especialidade;
        Nivel = nivel;
        CargaHoraria = cargaHoraria;
        QtdChamadosResolvidos = 0;
    }

    public void AssumirChamado()
    {
    }

    public void ResolverChamado()
    {
        QtdChamadosResolvidos++;
    }

    public void EncaminharAtendimento()
    {
    }

    public void AdicionarObservacao()
    {
    }
}
