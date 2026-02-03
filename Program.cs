using System;
using System.Collections.Generic;

namespace TrabalhoPoo;

// Programa principal para demonstrar o sistema completo
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== SISTEMA DE GERENCIAMENTO DE CHAMADOS ===");
        
        IChamadoRepository chamadoRepository = new ChamadoRepository();
        ChamadoService chamadoService = new ChamadoService(chamadoRepository);
        
        Console.WriteLine("=== CATEGORIAS ===");
        Categoria categoriaHardware = new Categoria(1, "Hardware", "Problemas com equipamentos físicos", "TI");
        Categoria categoriaSoftware = new Categoria(2, "Software", "Problemas com programas e aplicativos", "Desenvolvimento");
        Categoria categoriaRede = new Categoria(3, "Rede", "Problemas de conexão e infraestrutura", "Infraestrutura");
        
        Console.WriteLine($"Categoria criada: {categoriaHardware.nome}");
        Console.WriteLine($"Categoria criada: {categoriaSoftware.nome}");
        Console.WriteLine($"Categoria criada: {categoriaRede.nome}");
        Console.WriteLine();
        
        Console.WriteLine("=== CLIENTES ===");
        Cliente cliente1 = new Cliente(
            1, 
            "João Silva", 
            "joao@empresa.com", 
            "senha123", 
            "Empresa ABC", 
            "(11) 99999-8888", 
            "123.456.789-00", 
            "Rua das Flores, 123"
        );
        
        Cliente cliente2 = new Cliente(
            2, 
            "Maria Santos", 
            "maria@empresa.com", 
            "senha456", 
            "Empresa XYZ", 
            "(11) 97777-6666", 
            "987.654.321-00", 
            "Av. Paulista, 1000"
        );
        
        Console.WriteLine($"Cliente: {cliente1.Nome}");
        Console.WriteLine($"Cliente: {cliente2.Nome}");
        Console.WriteLine();
        
        Console.WriteLine("=== TÉCNICOS ===");
        Tecnico tecnico1 = new Tecnico(
            10, 
            "Carlos Andrade", 
            "carlos@helpdesk.com", 
            "tec123", 
            "Redes", 
            "Sênior",
            TimeSpan.FromHours(8)
        );
        
        Tecnico tecnico2 = new Tecnico(
            11, 
            "Ana Pereira", 
            "ana@helpdesk.com", 
            "tec456", 
            "Software", 
            "Pleno",
            TimeSpan.FromHours(6)
        );
        
        Console.WriteLine($"Técnico: {tecnico1.Nome}");
        Console.WriteLine($"Técnico: {tecnico2.Nome}");
        Console.WriteLine();
        
        Console.WriteLine("=== ABRINDO CHAMADOS ===");
        
        Chamado chamado1 = new Chamado(
            1001, 
            "Computador não liga", 
            "O computador não dá sinal de vida quando pressiono o botão de ligar", 
            cliente1, 
            categoriaHardware,
            "Alta"
        );
        
        Chamado chamado2 = new Chamado(
            1002, 
            "Programa travando", 
            "O software de gestão trava ao gerar relatórios", 
            cliente2, 
            categoriaSoftware,
            "Média"
        );
        
        Chamado chamado3 = new Chamado(
            1003, 
            "Internet lenta", 
            "A conexão com a internet está muito lenta desde ontem", 
            cliente1, 
            categoriaRede,
            "Alta"
        );
        
        chamadoService.AbrirChamado(chamado1);
        chamadoService.AbrirChamado(chamado2);
        chamadoService.AbrirChamado(chamado3);
        Console.WriteLine();
        
        Console.WriteLine("=== LISTANDO TODOS OS CHAMADOS ===");
        chamadoService.ListarTodos();
        Console.WriteLine();
        
        Console.WriteLine("=== ATRIBUINDO TÉCNICOS ===");
        chamadoService.AtribuirTecnico(1001, tecnico1);
        chamadoService.AtribuirTecnico(1002, tecnico2);
        chamadoService.AtribuirTecnico(1003, tecnico1); 
        Console.WriteLine();
        
        Console.WriteLine("=== CHAMADOS POR TÉCNICO ===");
        var chamadosTecnico1 = chamadoService.ListarPorTecnico(tecnico1);
        var chamadosTecnico2 = chamadoService.ListarPorTecnico(tecnico2);
        Console.WriteLine();
        
        Console.WriteLine("=== STATUS ===");
        chamadoService.ListarPorStatus("Aberto");
        chamadoService.ListarPorStatus("Em Atendimento");
        Console.WriteLine();
        
        Console.WriteLine("=== FECHANDO CHAMADO ===");
        chamadoService.FecharChamado(1001, "Computador consertado - fonte substituída");
        Console.WriteLine();
        
        Console.WriteLine("=== INFORMAÇÕES DOS USUÁRIOS ===");
        cliente1.ExibirInformacoes();
        Console.WriteLine();
        tecnico1.ExibirInformacoes();
        Console.WriteLine();
        
        chamadoService.MostrarResumo();
        Console.WriteLine();
        
        Console.WriteLine("=== FUNCIONALIDADES DE CLIENTE ===");
        cliente1.AbrirChamado("Novo problema", "Descrição do novo problema");
        Console.WriteLine();
        
        cliente1.AcompanharChamado(1003);
        Console.WriteLine();
        
        cliente1.AvaliarAtendimento(1001, 5, "Atendimento excelente, rápido e eficiente");
        Console.WriteLine();
        
        Console.WriteLine("=== FUNCIONALIDADES DE TÉCNICO ===");
        tecnico1.AssumirChamado(chamado3);
        tecnico1.AdicionarObservacao("Verificado router, parece ser problema no switch principal");
        tecnico1.ResolverChamado();
        Console.WriteLine();
        
        Console.WriteLine("=== LOGIN ===");
        cliente1.Login("joao@empresa.com", "senha123");
        cliente1.Login("email@errado.com", "senhaerrada");
        Console.WriteLine();
        
        Console.WriteLine("=== ALTERAÇÃO DE DADOS ===");
        cliente1.AlterarDados("João Silva Santos", null, "senha123", "novaSenha456");
        Console.WriteLine();
        
        Console.WriteLine("=== CHAMADOS POR CATEGORIA (EXTRA) ===");
        List<Chamado> todosChamados = chamadoService.ListarTodosChamados();
        List<Chamado> chamadosHardware = categoriaHardware.ListarChamadoPorCategoria(todosChamados);
        Console.WriteLine($"Chamados na categoria Hardware: {chamadosHardware.Count}");
        
        foreach (var chamado in chamadosHardware)
        {
            Console.WriteLine($"- {chamado.Titulo} (Status: {chamado.Status})");
        }
        Console.WriteLine();
        
        Console.WriteLine("=== GERANDO PROTOCOLOS ===");
        Console.WriteLine($"Protocolo chamado 1: {chamado1.GerarProtocolo()}");
        Console.WriteLine($"Protocolo chamado 2: {chamado2.GerarProtocolo()}");
        Console.WriteLine($"Protocolo chamado 3: {chamado3.GerarProtocolo()}");
        Console.WriteLine();
        
        Console.WriteLine("=== EDITANDO CATEGORIA ===");
        Console.WriteLine($"Antes da edição: {categoriaHardware.nome} - {categoriaHardware.descricao}");
        categoriaHardware.EditarCategoria("Hardware e Periféricos", "Problemas com equipamentos físicos e periféricos", "Suporte Técnico");
        Console.WriteLine($"Após edição: {categoriaHardware.nome} - {categoriaHardware.descricao}");
        Console.WriteLine();
        
        Console.WriteLine("=== SISTEMA EXECUTADO COM SUCESSO! ===");
    }
}