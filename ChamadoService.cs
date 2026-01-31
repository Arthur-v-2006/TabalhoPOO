using System;
using System.Collections.Generic;
using System.Linq;

namespace TrabalhoPoo;

public class ChamadoService{
    private List<Chamado> _chamados = new List<Chamado>();
    
    public void AbrirChamado(Chamado chamado){
        if (chamado == null){
            Console.WriteLine("Erro: Chamado não pode ser nulo");
            return;
        }
        
        _chamados.Add(chamado);
        Console.WriteLine($"Chamado #{chamado.IdChamado} aberto com sucesso!");
    }
    
    public List<Chamado> ListarPorStatus(string status){
        var resultado = _chamados
            .Where(c => c.Status.ToLower() == status.ToLower())
            .ToList();
            
        Console.WriteLine($"Chamados com status '{status}': {resultado.Count}");
        return resultado;
    }
    
    public List<Chamado> ListarPorTecnico(Tecnico tecnico){
        if (tecnico == null){
            Console.WriteLine("Técnico não encontrado");
            return new List<Chamado>();
        }
        
        var resultado = _chamados
            .Where(c => c.Tecnico != null && c.Tecnico.IdUsuario == tecnico.IdUsuario)
            .ToList();
            
        Console.WriteLine($"Chamados do técnico {tecnico.Nome}: {resultado.Count}");
        return resultado;
    }
    
    public void AtribuirTecnico(int idChamado, Tecnico tecnico){
        var chamado = BuscarPorId(idChamado);
        
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
        return _chamados.FirstOrDefault(c => c.IdChamado == id);
    }
    
    public void ListarTodos(){
        if (_chamados.Count == 0){
            Console.WriteLine("📭 Nenhum chamado cadastrado");
            return;
        }
        
        Console.WriteLine("📋 LISTA DE CHAMADOS:");
        foreach (var chamado in _chamados){
            Console.WriteLine($"#{chamado.IdChamado} - {chamado.Titulo} - Status: {chamado.Status}");
        }
    }
    
    public void FecharChamado(int idChamado, string motivo){
        var chamado = BuscarPorId(idChamado);
        
        if (chamado == null){
            Console.WriteLine($"Chamado #{idChamado} não encontrado");
            return;
        }
        
        chamado.Encerrar(motivo);
        Console.WriteLine($"Chamado #{idChamado} fechado");
    }
    
    public void MostrarResumo(){
        Console.WriteLine("RESUMO DO SISTEMA:");
        Console.WriteLine($"Total de chamados: {_chamados.Count}");
        
        var abertos = _chamados.Count(c => c.Status == "Aberto");
        var emAtendimento = _chamados.Count(c => c.Status == "Em Atendimento");
        var fechados = _chamados.Count(c => c.Status == "Fechado");
        
        Console.WriteLine($"• Abertos: {abertos}");
        Console.WriteLine($"• Em atendimento: {emAtendimento}");
        Console.WriteLine($"• Fechados: {fechados}");
    }
}