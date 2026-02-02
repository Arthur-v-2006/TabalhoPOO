using System;
using System.Collections.Generic;
using System.Linq;

namespace TrabalhoPoo;

// SRP: Responsabilidade única - gerenciar regras de negócio de chamados
// DIP: Depende de abstração (IChamadoRepository), não de implementação concreta
// ISP: Implementa apenas métodos necessários para serviços de chamado
public class ChamadoService{

    // DIP: Depende de interface IChamadoRepository, não de implementação concreta
    private readonly IChamadoRepository _chamadoRepository;

    // Dependency Injection - Inversão de dependência
    public ChamadoService(IChamadoRepository chamadoRepository)
    {
        _chamadoRepository = chamadoRepository ?? throw new ArgumentNullException(nameof(chamadoRepository));
    }
    
    public void AbrirChamado(Chamado chamado){
        if (chamado == null){
            Console.WriteLine("Erro: Chamado não pode ser nulo");
            return;
        }
        
        _chamadoRepository.Adicionar(chamado);
        Console.WriteLine($"Chamado #{chamado.IdChamado} aberto com sucesso!");
    }
    
    public List<Chamado> ListarPorStatus(string status){
        var resultado = _chamadoRepository.ListarPorStatus(status);
            
        Console.WriteLine($"Chamados com status '{status}': {resultado.Count}");
        return resultado;
    }
    
    public List<Chamado> ListarPorTecnico(Tecnico tecnico){
        if (tecnico == null){
            Console.WriteLine("Técnico não encontrado");
            return new List<Chamado>();
        }
        
        var resultado = _chamadoRepository.ListarPorTecnico(tecnico);
            
        Console.WriteLine($"Chamados do técnico {tecnico.Nome}: {resultado.Count}");
        return resultado;
    }
    
    public void AtribuirTecnico(int idChamado, Tecnico tecnico){
        var chamado = _chamadoRepository.BuscarPorId(idChamado);
        
        if (chamado == null){
            Console.WriteLine($"Chamado #{idChamado} não encontrado");
            return;
        }
        
        if (tecnico == null){
            Console.WriteLine("Técnico não pode ser nulo");
            return;
        }
        
        chamado.AtribuirTecnico(tecnico);
        chamado.Status = "Em Atendimento";
        
        Console.WriteLine($"Técnico {tecnico.Nome} atribuído ao chamado #{idChamado}");
    }
    
    public Chamado BuscarPorId(int id){
        return _chamadoRepository.BuscarPorId(id);
    }
    
    public void ListarTodos(){

        var chamados = _chamadoRepository.ListarTodos();

        if (chamados.Count == 0){
            Console.WriteLine("📭 Nenhum chamado cadastrado");
            return;
        }
        
        Console.WriteLine("📋 LISTA DE CHAMADOS:");
        foreach (var chamado in chamados){
            Console.WriteLine($"#{chamado.IdChamado} - {chamado.Titulo} - Status: {chamado.Status}");
        }
    }
    
    public void FecharChamado(int idChamado, string motivo){
        var chamado = _chamadoRepository.BuscarPorId(idChamado);
        
        if (chamado == null){
            Console.WriteLine($"Chamado #{idChamado} não encontrado");
            return;
        }
        
        chamado.Encerrar(motivo);
        Console.WriteLine($"Chamado #{idChamado} fechado");
    }

    public List<Chamado> ListarTodosChamados()
    {
        return _chamadoRepository.ListarTodos();
    }
    
    public void MostrarResumo(){

        var chamados = _chamadoRepository.ListarTodos();

        Console.WriteLine("RESUMO DO SISTEMA:");
        Console.WriteLine($"Total de chamados: {chamados.Count}");
        
        var abertos = chamados.Count(c => c.Status == "Aberto");
        var emAtendimento = chamados.Count(c => c.Status == "Em Atendimento");
        var fechados = chamados.Count(c => c.Status == "Fechado");
        
        Console.WriteLine($"• Abertos: {abertos}");
        Console.WriteLine($"• Em atendimento: {emAtendimento}");
        Console.WriteLine($"• Fechados: {fechados}");
    }
}