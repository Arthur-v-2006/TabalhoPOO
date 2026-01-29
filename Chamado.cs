public class Chamado{
    private int idChamado;
    public string titulo;
    public string descricao;
    public string status;
    public string prioridade;
    private DateTime dataAbertura;
    private DateTime? dataFechamento;
    private Cliente cliente;
    private Tecnico tecnico;
    private Categoria categoria;
    private HistoricoChamado historico;
    
    public Chamado(int idChamado, string titulo, string descricao, Cliente cliente, Categoria categoria, string prioridade = "Média"){
        this.idChamado = idChamado;
        this.titulo = titulo;
        this.descricao = descricao;
        this.status = "Aberto";
        this.prioridade = prioridade;
        this.dataAbertura = DateTime.Now;
        this.dataFechamento = null;
        this.cliente = cliente;
        this.tecnico = null;
        this.categoria = categoria;
        this.historico = new HistoricoChamado(1);
    }

    public int IdChamado{
        get { return idChamado; }
    }

    public string Titulo{
        get { return titulo; }
        set { titulo = value; }
    }

    public string Descricao{
        get { return descricao; }
        set { descricao = value; }
    }

    public string Status{
        get { return status; }
        set { status = value; }
    }

    public string Prioridade{
        get { return prioridade; }
        set { prioridade = value; }
    }

    public DateTime DataAbertura{
        get { return dataAbertura; }
    }

    public DateTime? DataFechamento{
        get { return dataFechamento; }
        set { dataFechamento = value; }
    }

    public Cliente Cliente{
        get { return cliente; }
    }

    public Tecnico Tecnico{
        get { return tecnico; }
        set { tecnico = value; }
    }
    
    public Categoria Categoria{
        get { return categoria; }
    }

    public HistoricoChamado Historico{
        get { return historico; }
    }
    
    public string GerarProtocolo(){
        return $"CHM-{idChamado:0000}-{dataAbertura:yyyyMMdd}";
    }

    public void AlterarStatus(string novoStatus){
        status = novoStatus;
    }

    public void FecharChamado(){
        dataFechamento = DateTime.Now;
        status = "Fechado";
    }

    public void AtualizarDescricao(string novaDescricao){
        descricao = novaDescricao;
    }
}