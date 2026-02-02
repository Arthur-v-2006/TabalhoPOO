using System.Collections.Generic;

namespace TrabalhoPoo;

// DIP: Interface para inversão de dependência
// ISP: Interface pequena e específica para operações de chamado
public interface IChamadoRepository
{
    void Adicionar(Chamado chamado);
    Chamado BuscarPorId(int id);
    List<Chamado> ListarTodos();
    List<Chamado> ListarPorStatus(string status);
    List<Chamado> ListarPorTecnico(Tecnico tecnico);
}