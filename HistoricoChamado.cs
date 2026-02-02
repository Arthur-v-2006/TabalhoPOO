using System;
using System.Collections.Generic;

namespace TrabalhoPoo;

// SRP: Responsabilidade única - gerenciar histórico de alterações de chamados
// OCP: Aberta para extensão de novos tipos de registro histórico
public class HistoricoChamado{
    private int idHistorico;
    private DateTime data;
    private string descricao;
    private string novoStatus;
    private string statusAnterior;
    private List<string> comentarios = new List<string>();
    
    public HistoricoChamado(int idHistorico){
        this.idHistorico = idHistorico;
        this.data = DateTime.Now;
        this.descricao = string.Empty;
        this.novoStatus = string.Empty;
        this.statusAnterior = string.Empty;
    }

    public int IdHistorico{
        get { return idHistorico; }
    }

    public DateTime Data{
        get { return data; }
    }

    public string Descricao{
        get { return descricao; }
        set { descricao = value; }
    }

    public string NovoStatus{
        get { return novoStatus; }
        set { novoStatus = value; }
    }

    public string StatusAnterior{
        get { return statusAnterior; }
        set { statusAnterior = value; }
    }

    public void RegistrarHistorico(string descricao, string novoStatus, string statusAnterior){
        this.data = DateTime.Now;
        this.descricao = descricao;
        this.statusAnterior = statusAnterior;
        this.novoStatus = novoStatus;
    }

    public void AdicionarComentarios(string comentario){
        string comentarioCompleto = $"{DateTime.Now}: {comentario}";
        comentarios.Add(comentarioCompleto);
    }
}