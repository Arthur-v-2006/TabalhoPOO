using System;
using System.Collections.Generic;

namespace TrabalhoPoo;

// ISP: Interface pequena e específica - apenas um método
// SRP: Responsabilidade única - definir contrato para atribuição de técnico
public interface IAtribuivel{
    void AtribuirTecnico(Tecnico tecnico);
}