using System;
using System.Collections.Generic;
using System.Linq;

namespace TrabalhoPoo;

// DIP: Implementação concreta da interface IChamadoRepository
public class ChamadoRepository : IChamadoRepository
{
    private List<Chamado> _chamados = new List<Chamado>();
    
    public void Adicionar(Chamado chamado)
    {
        if (chamado == null)
            throw new ArgumentNullException(nameof(chamado));
            
        _chamados.Add(chamado);
    }
    
    public Chamado BuscarPorId(int id)
    {
        return _chamados.FirstOrDefault(c => c.IdChamado == id);
    }
    
    public List<Chamado> ListarTodos()
    {
        return _chamados.ToList();
    }
    
    public List<Chamado> ListarPorStatus(string status)
    {
        if (string.IsNullOrWhiteSpace(status))
            return new List<Chamado>();
            
        return _chamados
            .Where(c => c.Status.Equals(status, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
    
    public List<Chamado> ListarPorTecnico(Tecnico tecnico)
    {
        if (tecnico == null) 
            return new List<Chamado>();
        
        return _chamados
            .Where(c => c.Tecnico != null && c.Tecnico.IdUsuario == tecnico.IdUsuario)
            .ToList();
    }
}