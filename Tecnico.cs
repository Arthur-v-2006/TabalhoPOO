public class Tecnico : Usuario{
    private string Especialidade;
    private string Nivel;
    private int QtdChamadosResolvidos;
    private TimeSpan CargaHoraria;

    public Tecnico(
        int idUsuario, string nome, string email, string senha, string especialidade, string nivel,TimeSpan cargaHoraria)
        : base(idUsuario, nome, email, senha){
            this.Especialidade = especialidade;
            this.Nivel = nivel;
            this.CargaHoraria = cargaHoraria;
            this.QtdChamadosResolvidos = 0;
        }

    public void AssumirChamado(Chamado chamado){
        if (chamado != null){
            chamado.Tecnico = this;
        }
        
    }

    public void ResolverChamado(){
        QtdChamadosResolvidos++;
    }

    public void EncaminharAtendimento(Chamado chamado, Tecnico novoTecnico){
        if (chamado != null && novoTecnico != null){
            chamado.Tecnico = novoTecnico;
        }
    }

    public void AdicionarObservacao(string observacao){
        Console.WriteLine($"Observação: {observacao}");
    }
}
