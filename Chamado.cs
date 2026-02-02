using System;
using System.Collections.Generic;

namespace TrabalhoPoo;

// SRP: Responsabilidade única - representar um chamado de suporte
// ISP: Implementa interfaces específicas (IAtribuivel, IEncerravel)
// LSP: Pode ser usado onde IAtribuivel ou IEncerravel são esperados
public class Chamado : IAtribuivel, IEncerravel{
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

    public void AtribuirTecnico(Tecnico tecnico){
        if (tecnico == null)
            throw new ArgumentNullException(nameof(tecnico));
            
        this.tecnico = tecnico;
        Console.WriteLine($"Técnico {tecnico.Nome} atribuído ao chamado {IdChamado}");
    }
    
    public void Encerrar(string motivo)
    {
        if (string.IsNullOrWhiteSpace(motivo))
            throw new ArgumentException("Motivo do encerramento é obrigatório");
            
        this.dataFechamento = DateTime.Now;
        this.status = "Fechado";
        
        historico.RegistrarHistorico($"Chamado encerrado. Motivo: {motivo}", "Fechado", status);
        
        Console.WriteLine($"Chamado {IdChamado} encerrado. Motivo: {motivo}");
    }
    
    public void FecharChamado(){
        Encerrar("Fechamento padrão pelo sistema");
    }
    
    public string GerarProtocolo(){
        return $"CHM-{idChamado:0000}-{dataAbertura:yyyyMMdd}";
    }

    public void AlterarStatus(string novoStatus){
        status = novoStatus;
    }

    public void AtualizarDescricao(string novaDescricao){
        descricao = novaDescricao;
    }
}