using System;
using System.Collections.Generic;

namespace TrabalhoPoo;

// LSP: Pode substituir Usuario sem quebrar o sistema
// OCP: Extende Usuario sem modificar a classe base
// SRP: Responsabilidade única - representar um técnico do sistema
public class Tecnico : Usuario{
    private string especialidade;
    private string nivel;
    private string telefone;
    private string cpf;
    private int qtdChamadosResolvidos;
    private TimeSpan cargaHoraria;

    public Tecnico(int idUsuario, string nome, string email, string senha, string especialidade, string nivel, TimeSpan cargaHoraria, string telefone, string cpf)
        : base(idUsuario, nome, email, senha){
            this.especialidade = especialidade;
            this.nivel = nivel;
            this.cargaHoraria = cargaHoraria;
            this.telefone = telefone;
            this.cpf = cpf;
            this.qtdChamadosResolvidos = 0;
        }

    public string Telefone {
        get { return telefone; }
        set { telefone = value; }
    }

    public string Cpf {
        get { return cpf; }
        set { cpf = value; }
    }

    public void AssumirChamado(Chamado chamado){
        if (chamado != null){
            chamado.Tecnico = this;
        }
    }

    public void ResolverChamado(){
        qtdChamadosResolvidos++;
    }

    public void EncaminharAtendimento(Chamado chamado, Tecnico novoTecnico){
        if (chamado != null && novoTecnico != null){
            chamado.Tecnico = novoTecnico;
        }
    }

    public void AdicionarObservacao(string observacao){
        Console.WriteLine($"Observação: {observacao}");
    }

    public override void ExibirInformacoes(){
        base.ExibirInformacoes();
        Console.WriteLine($"Tipo: Técnico");
        Console.WriteLine($"Especialidade: {especialidade}");
        Console.WriteLine($"Nível: {nivel}");
        Console.WriteLine($"Telefone: {telefone}");
        Console.WriteLine($"CPF: {cpf}");
        Console.WriteLine($"Carga Horária: {cargaHoraria.TotalHours} horas");
        Console.WriteLine($"Chamados Resolvidos: {qtdChamadosResolvidos}");
    }
}