using System;
using System.Collections.Generic;

namespace TrabalhoPoo;

public class Categoria{
    private int idCategoria;
    public string nome;
    public string descricao;
    private string departamentoResponsavel;

    public Categoria(int idCategoria, string nome, string descricao, string departamentoResponsavel){
        this.idCategoria = idCategoria;
        this.nome = nome;
        this.descricao = descricao;
        this.departamentoResponsavel = departamentoResponsavel;
    }

    public int IdCategoria{
        get { return idCategoria; }
    }

    public string DepartamentoResponsavel{
        get { return departamentoResponsavel; }
        set { departamentoResponsavel = value; }
    }

    public static Categoria CadastrarCategoria(int id, string nome, string descricao, string departamento){
        return new Categoria(id, nome, descricao, departamento);
    }

    public void EditarCategoria(string novoNome, string novaDescricao, string novoDepartamento){
        this.nome = novoNome;
        this.descricao = novaDescricao;
        this.departamentoResponsavel = novoDepartamento;
    }

    public List<Chamado> ListarChamadoPorCategoria(List<Chamado> todosChamados){
        var chamadosDaCategoria = new List<Chamado>();
        
        foreach (var chamado in todosChamados){
            if (chamado.Categoria != null && chamado.Categoria.idCategoria == this.idCategoria){
                chamadosDaCategoria.Add(chamado);
            }
        }
        
        return chamadosDaCategoria;
    }
}
