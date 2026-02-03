using System;
using System.Collections.Generic;

namespace TrabalhoPoo;

// LSP: Pode substituir Usuario sem quebrar o sistema
// OCP: Extende Usuario sem modificar a classe base  
// SRP: Responsabilidade única - representar um técnico do sistema
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

    public override void ExibirInformacoes(){
        base.ExibirInformacoes();
        Console.WriteLine($"Tipo: Técnico");
        Console.WriteLine($"Especialidade: {Especialidade}");
        Console.WriteLine($"Nível: {Nivel}");
        Console.WriteLine($"Carga Horária: {CargaHoraria.TotalHours} horas");
        Console.WriteLine($"Chamados Resolvidos: {QtdChamadosResolvidos}");
    }
}
