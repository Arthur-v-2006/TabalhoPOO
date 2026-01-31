using System;
using System.Collections.Generic;

namespace TrabalhoPoo;

public class ChamadoService{
    private readonly IRepositorioChamados _repositorio;
    
    public ChamadoService(IRepositorioChamados repositorio){
        _repositorio = repositorio;
    }
    
    public void AbrirChamado(Chamado chamado) { }
    public List<Chamado> ListarPorStatus(string status) { }
    public List<Chamado> ListarPorTecnico(Tecnico tecnico) { }
}

public interface IRepositorioChamados{
    void Adicionar(Chamado chamado);
    List<Chamado> ObterTodos();
    Chamado ObterPorId(int id);
}

public class RepositorioChamadosEmMemoria : IRepositorioChamados{
    private List<Chamado> _chamados = new List<Chamado>();
    
    public void Adicionar(Chamado chamado) { _chamados.Add(chamado); }
    public List<Chamado> ObterTodos() { return _chamados; }
    public Chamado ObterPorId(int id) { return _chamados.FirstOrDefault(c => c.IdChamado == id); }
}

public class SistemaChamados{
    private readonly ChamadoService _chamadoService;
    private List<Usuario> _usuarios = new List<Usuario>();
    private List<Categoria> _categorias = new List<Categoria>();
    
    public void Executar() { }
}