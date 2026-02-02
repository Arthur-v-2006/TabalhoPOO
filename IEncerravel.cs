using System;
using System.Collections.Generic;

namespace TrabalhoPoo;

// ISP: Interface pequena e específica - apenas um método  
// SRP: Responsabilidade única - definir contrato para encerramento de chamado
public interface IEncerravel{
    void Encerrar(string motivo);
}