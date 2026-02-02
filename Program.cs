using System;

namespace TrabalhoPoo;

public class Program{
    public static void Main(string[] args){
        Console.WriteLine("SISTEMA DE CHAMADOS");

         // DIP: Criando a implementação concreta do repositório
    IChamadoRepository chamadoRepository = new ChamadoRepository();
    
    // DIP: Injetando a dependência no serviço (Dependency Injection)
    ChamadoService chamadoService = new ChamadoService(chamadoRepository);
        
        Categoria categoriaTI = Categoria.CadastrarCategoria(
            1, 
            "Problemas de TI", 
            "Chamados relacionados a hardware, software e rede", 
            "Departamento de TI"
        );
        
        Categoria categoriaFinanceiro = Categoria.CadastrarCategoria(
            2, 
            "Financeiro", 
            "Problemas financeiros e contábeis", 
            "Departamento Financeiro"
        );
        
        Cliente cliente1 = new Cliente(
            1, 
            "João Silva", 
            "joao@empresa.com", 
            "senha123", 
            "Empresa XYZ", 
            "(11) 99999-9999", 
            "123.456.789-00", 
            "Rua das Flores, 123"
        );
        
        Cliente cliente2 = new Cliente(
            2, 
            "Maria Santos", 
            "maria@empresa.com", 
            "senha456", 
            "Empresa ABC", 
            "(11) 98888-8888", 
            "987.654.321-00", 
            "Av. Paulista, 1000"
        );
        
        Tecnico tecnico1 = new Tecnico(
            3, 
            "Carlos Souza", 
            "carlos@helpdesk.com", 
            "tec123", 
            "Redes e Infraestrutura", 
            "Sênior", 
            TimeSpan.FromHours(40)
        );
        
        Tecnico tecnico2 = new Tecnico(
            4, 
            "Ana Lima", 
            "ana@helpdesk.com", 
            "tec456", 
            "Software e Aplicações", 
            "Pleno", 
            TimeSpan.FromHours(40)
        );
        
        
        Chamado chamado1 = new Chamado(
            1001, 
            "Computador não liga", 
            "O computador da sala 101 não está ligando", 
            cliente1, 
            categoriaTI, 
            "Alta"
        );
        
        Chamado chamado2 = new Chamado(
            1002, 
            "Problema com sistema financeiro", 
            "Não consigo gerar relatório mensal", 
            cliente2, 
            categoriaFinanceiro
        );
        
        chamadoService.AbrirChamado(chamado1);
        chamadoService.AbrirChamado(chamado2);
        
        chamadoService.ListarTodos();
        
        chamadoService.AtribuirTecnico(1001, tecnico1);
        chamadoService.AtribuirTecnico(1002, tecnico2);
        
        var chamadosAbertos = chamadoService.ListarPorStatus("Aberto");
        var chamadosAtendimento = chamadoService.ListarPorStatus("Em Atendimento");
        
        var chamadosDoTecnico1 = chamadoService.ListarPorTecnico(tecnico1);
        
        chamadoService.FecharChamado(1001, "Problema resolido - Fonte substituída");
        
        chamadoService.MostrarResumo();
        
        Console.WriteLine("INFORMAÇÕES DOS USUÁRIOS");
        cliente1.ExibirInformacoes();
        Console.WriteLine();
        tecnico1.ExibirInformacoes();
        
        Console.WriteLine("TESTES DE FUNCIONALIDADES");
        
        Console.WriteLine("Teste de Login:");
        cliente1.Login("joao@empresa.com", "senha123");
        cliente1.Login("joao@empresa.com", "senha_errada");
        
        Console.WriteLine("Alterando dados do cliente:");
        cliente1.AlterarDados(novoNome: "João Silva Santos", novaSenha: "novaSenha123", senhaAtual: "senha123");
        
        Console.WriteLine("Cliente abrindo chamado:");
        cliente1.AbrirChamado("Novo problema", "Descrição do novo problema");
        
        Console.WriteLine("Adicionando comentário ao histórico:");
        chamado1.Historico.AdicionarComentarios("Técnico visitou local e verificou o problema");
        chamado1.Historico.AdicionarComentarios("Peça solicitada ao almoxarifado");
        
        Console.WriteLine($"Protocolo do chamado 1001: {chamado1.GerarProtocolo()}");
        
        Console.WriteLine("\n=== CHAMADOS POR CATEGORIA ===");
        var chamadosCategoriaTI = categoriaTI.ListarChamadoPorCategoria(chamadoService.ListarTodosChamados());
        Console.WriteLine($"Chamados na categoria TI: {chamadosCategoriaTI.Count}");
        
        Console.WriteLine("\n=== FIM DO PROGRAMA ===");
        Console.ReadKey();
    }
}