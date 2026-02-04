﻿using System;
using System.Collections.Generic;

namespace TrabalhoPoo;

class Program
{
    private static SistemaAutenticacao sistemaAutenticacao;
    private static ChamadoService chamadoService;
    private static Usuario usuarioLogado;
    
    static void Main(string[] args){
        InicializarSistema();
        MenuPrincipal();
    }
    
    static void InicializarSistema(){
        sistemaAutenticacao = new SistemaAutenticacao();
        
        IChamadoRepository chamadoRepository = new ChamadoRepository();
        chamadoService = new ChamadoService(chamadoRepository);
        
        Categoria categoriaHardware = new Categoria(1, "Hardware", "Problemas com equipamentos físicos", "TI");
        Categoria categoriaSoftware = new Categoria(2, "Software", "Problemas com programas e aplicativos", "Desenvolvimento");
        Categoria categoriaRede = new Categoria(3, "Rede", "Problemas de conexão e infraestrutura", "Infraestrutura");
        
        Console.Title = "Sistema de Gerenciamento de Chamados";
    }
    
    static void MenuPrincipal(){
        bool sair = false;
        
        while (!sair){
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("SISTEMA DE GERENCIAMENTO DE CHAMADOS");
            Console.WriteLine("====================================\n");
            
            if (usuarioLogado == null){
                MenuNaoLogado(ref sair);
            }
            else{
                MenuLogado();
            }
        }
    }
    
    static void MenuNaoLogado(ref bool sair){
        Console.WriteLine("1. Fazer Login");
        Console.WriteLine("2. Cadastrar-se");
        Console.WriteLine("3. Sair do Sistema");
        Console.Write("\nEscolha uma opção: ");
        
        string opcao = Console.ReadLine();
        
        switch (opcao){
            case "1":
                usuarioLogado = sistemaAutenticacao.FazerLogin();
                if (usuarioLogado != null){
                    Console.WriteLine($"\nBem-vindo, {usuarioLogado.Nome}!");
                    Console.ReadKey();
                }
                break;
                
            case "2":
                sistemaAutenticacao.CadastrarNovoUsuario();
                break;
                
            case "3":
                Console.WriteLine("\nSaindo do sistema...");
                sair = true;
                break;
                
            default:
                Console.WriteLine("\nOpção inválida!");
                Console.ReadKey();
                break;
        }
    }
    
    static void MenuLogado(){
        Console.WriteLine($"Usuário logado: {usuarioLogado.Nome} ({usuarioLogado.GetType().Name})");
        Console.WriteLine("====================================\n");
        
        if (usuarioLogado is Cliente){
            MenuCliente();
        }
        else if (usuarioLogado is Tecnico){
            MenuTecnico();
        }
        else{
            Console.WriteLine("Tipo de usuário não reconhecido!");
            Console.ReadKey();
            usuarioLogado = null;
        }
    }
    
    static void MenuCliente(){
        Cliente cliente = (Cliente)usuarioLogado;
        
        Console.WriteLine("MENU CLIENTE:");
        Console.WriteLine("1. Abrir novo chamado");
        Console.WriteLine("2. Listar meus chamados");
        Console.WriteLine("3. Acompanhar chamado");
        Console.WriteLine("4. Avaliar atendimento");
        Console.WriteLine("5. Ver minhas informações");
        Console.WriteLine("6. Alterar meus dados");
        Console.WriteLine("7. Logout");
        Console.Write("\nEscolha uma opção: ");
        
        string opcao = Console.ReadLine();
        
        switch (opcao){
            case "1":
                AbrirNovoChamado(cliente);
                break;
                
            case "2":
                ListarChamadosCliente(cliente);
                break;
                
            case "3":
                AcompanharChamado(cliente);
                break;
                
            case "4":
                AvaliarAtendimento(cliente);
                break;
                
            case "5":
                Console.Clear();
                cliente.ExibirInformacoes();
                Console.WriteLine("\nPressione qualquer tecla para voltar...");
                Console.ReadKey();
                break;
                
            case "6":
                AlterarDadosUsuario(cliente);
                break;
                
            case "7":
                cliente.Logout();
                usuarioLogado = null;
                Console.WriteLine("\nDeslogado com sucesso!");
                Console.ReadKey();
                break;
                
            default:
                Console.WriteLine("\nOpção inválida!");
                Console.ReadKey();
                break;
        }
    }
    
    static void MenuTecnico(){
        Tecnico tecnico = (Tecnico)usuarioLogado;
        
        Console.WriteLine("MENU TÉCNICO:");
        Console.WriteLine("1. Listar chamados disponíveis");
        Console.WriteLine("2. Listar chamados atribuídos a mim");
        Console.WriteLine("3. Assumir chamado");
        Console.WriteLine("4. Adicionar observação ao chamado");
        Console.WriteLine("5. Finalizar chamado");
        Console.WriteLine("6. Ver minhas informações");
        Console.WriteLine("7. Logout");
        Console.Write("\nEscolha uma opção: ");
        
        string opcao = Console.ReadLine();
        
        switch (opcao){
            case "1":
            ListarChamadosDisponiveis(tecnico);
            break;
            
            case "2":
            ListarChamadosTecnico(tecnico);
            break;
            
            case "3":
            AssumirChamado(tecnico);
            break;
            
            case "4":
            AdicionarObservacaoChamado(tecnico);
            break;
            
            case "5":
            ResolverChamado(tecnico);
            break;
            
            case "6":
            Console.Clear();
            tecnico.ExibirInformacoes();
            Console.WriteLine("\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
            break;
            
            case "7":
            tecnico.Logout();
            usuarioLogado = null;
            Console.WriteLine("\nDeslogado com sucesso!");
            Console.ReadKey();
            break;
            
            default:
            Console.WriteLine("\nOpção inválida!");
            Console.ReadKey();
            break;
        }
    }
    
    static void AbrirNovoChamado(Cliente cliente){
        Console.Clear();
        Console.WriteLine("=== ABRIR NOVO CHAMADO ===\n");
        
        try{
            var todosChamados = chamadoService.ListarTodosChamados();
            int novoId = todosChamados.Count > 0 ? todosChamados[todosChamados.Count - 1].IdChamado + 1 : 1001;
            
            Console.Write("Título do problema: ");
            string titulo = Console.ReadLine();
            
            Console.Write("Descrição detalhada: ");
            string descricao = Console.ReadLine();
            
            Console.WriteLine("\nCategorias disponíveis:");
            Console.WriteLine("1. Hardware");
            Console.WriteLine("2. Software");
            Console.WriteLine("3. Rede");
            Console.Write("Escolha uma categoria: ");
            
            Categoria categoria;
            switch (Console.ReadLine()){
                case "1":
                    categoria = new Categoria(1, "Hardware", "Problemas com equipamentos físicos", "TI");
                    break;
                case "2":
                    categoria = new Categoria(2, "Software", "Problemas com programas e aplicativos", "Desenvolvimento");
                    break;
                case "3":
                    categoria = new Categoria(3, "Rede", "Problemas de conexão e infraestrutura", "Infraestrutura");
                    break;
                default:
                    Console.WriteLine("Categoria inválida! Usando Hardware como padrão.");
                    categoria = new Categoria(1, "Hardware", "Problemas com equipamentos físicos", "TI");
                    break;
            }
            
            Console.Write("Prioridade (Baixa/Média/Alta): ");
            string prioridade = Console.ReadLine();
            
            if (string.IsNullOrEmpty(prioridade))
                prioridade = "Média";
            
            Chamado novoChamado = new Chamado(
                novoId, titulo, descricao, cliente, categoria, prioridade
            );
            
            chamadoService.AbrirChamado(novoChamado);
            
            Console.WriteLine($"\nChamado #{novoId} aberto com sucesso!");
            Console.WriteLine($"Protocolo: {novoChamado.GerarProtocolo()}");
        }
        catch (Exception ex){
            Console.WriteLine($"\nErro ao abrir chamado: {ex.Message}");
        }
        
        Console.WriteLine("\nPressione qualquer tecla para voltar...");
        Console.ReadKey();
    }
    
    static void ListarChamadosCliente(Cliente cliente){
        Console.Clear();
        Console.WriteLine("=== MEUS CHAMADOS ===\n");
        
        var todosChamados = chamadoService.ListarTodosChamados();
        var chamadosCliente = new List<Chamado>();
        
        foreach (var chamado in todosChamados){
            if (chamado.Cliente.IdUsuario == cliente.IdUsuario){
                chamadosCliente.Add(chamado);
            }
        }
        
        if (chamadosCliente.Count == 0){
            Console.WriteLine("Nenhum chamado encontrado.");
        }
        else{
            foreach (var chamado in chamadosCliente){
                Console.WriteLine($"ID: #{chamado.IdChamado}");
                Console.WriteLine($"Título: {chamado.Titulo}");
                Console.WriteLine($"Status: {chamado.Status}");
                Console.WriteLine($"Prioridade: {chamado.Prioridade}");
                Console.WriteLine($"Data Abertura: {chamado.DataAbertura:dd/MM/yyyy HH:mm}");
                
                if (chamado.Tecnico != null)
                    Console.WriteLine($"Técnico: {chamado.Tecnico.Nome}");
                
                Console.WriteLine($"Protocolo: {chamado.GerarProtocolo()}");
                Console.WriteLine("--------------------------------");
            }
        }
        
        Console.WriteLine("\nPressione qualquer tecla para voltar...");
        Console.ReadKey();
    }
    
    static void AcompanharChamado(Cliente cliente){
        Console.Clear();
        Console.WriteLine("=== ACOMPANHAR CHAMADO ===\n");
        
        Console.Write("Digite o ID do chamado: ");
        if (int.TryParse(Console.ReadLine(), out int idChamado)){
            cliente.AcompanharChamado(idChamado);
            
            var chamado = chamadoService.BuscarPorId(idChamado);
            if (chamado != null && chamado.Cliente.IdUsuario == cliente.IdUsuario){
                Console.WriteLine($"\nDetalhes do chamado #{idChamado}:");
                Console.WriteLine($"Status atual: {chamado.Status}");
                Console.WriteLine($"Técnico: {(chamado.Tecnico != null ? chamado.Tecnico.Nome : "Aguardando atribuição")}");
                Console.WriteLine($"Data de abertura: {chamado.DataAbertura:dd/MM/yyyy HH:mm}");
                
                if (chamado.DataFechamento.HasValue){
                    Console.WriteLine($"Data de fechamento: {chamado.DataFechamento.Value:dd/MM/yyyy HH:mm}");
                }
            }
            else{
                Console.WriteLine("\nChamado não encontrado ou não pertence a você.");
            }
        }
        else{
            Console.WriteLine("ID inválido!");
        }
        
        Console.WriteLine("\nPressione qualquer tecla para voltar...");
        Console.ReadKey();
    }
    
    static void AvaliarAtendimento(Cliente cliente){
        Console.Clear();
        Console.WriteLine("=== AVALIAR ATENDIMENTO ===\n");
        
        Console.Write("Digite o ID do chamado: ");
        if (int.TryParse(Console.ReadLine(), out int idChamado)){
            Console.Write("Nota (0-10): ");
            if (int.TryParse(Console.ReadLine(), out int nota) && nota >= 0 && nota <= 10){
                Console.Write("Comentário: ");
                string comentario = Console.ReadLine();
                
                cliente.AvaliarAtendimento(idChamado, nota, comentario);
                
                Console.WriteLine($"\nAvaliação registrada com sucesso!");
            }
            else{
                Console.WriteLine("Nota inválida!");
            }
        }
        else{
            Console.WriteLine("ID inválido!");
        }
        
        Console.WriteLine("\nPressione qualquer tecla para voltar...");
        Console.ReadKey();
    }
    
    static void AlterarDadosUsuario(Usuario usuario){
        Console.Clear();
        Console.WriteLine("=== ALTERAR MEUS DADOS ===\n");
        
        Console.Write("Novo nome (deixe em branco para manter atual): ");
        string novoNome = Console.ReadLine();
        
        Console.Write("Novo email (deixe em branco para manter atual): ");
        string novoEmail = Console.ReadLine();
        
        Console.Write("Para alterar senha, digite senha atual: ");
        string senhaAtual = Console.ReadLine();
        
        string novaSenha = "";
        if (!string.IsNullOrEmpty(senhaAtual)){
            Console.Write("Nova senha: ");
            novaSenha = Console.ReadLine();
        }
        
        bool sucesso = usuario.AlterarDados(
            string.IsNullOrWhiteSpace(novoNome) ? null : novoNome,
            string.IsNullOrWhiteSpace(novoEmail) ? null : novoEmail,
            string.IsNullOrWhiteSpace(senhaAtual) ? null : senhaAtual,
            string.IsNullOrWhiteSpace(novaSenha) ? null : novaSenha
        );
        
        if (sucesso){
            Console.WriteLine("\nDados alterados com sucesso!");
        }
        
        Console.WriteLine("\nPressione qualquer tecla para voltar...");
        Console.ReadKey();
    }
    
    static void ListarChamadosTecnico(Tecnico tecnico){
        Console.Clear();
        Console.WriteLine("=== CHAMADOS ATRIBUÍDOS A MIM ===\n");
        
        var chamadosTecnico = chamadoService.ListarPorTecnico(tecnico);
        
        if (chamadosTecnico.Count == 0){
            Console.WriteLine("Nenhum chamado atribuído a você.");
        }
        else{
            foreach (var chamado in chamadosTecnico)
            {
                Console.WriteLine($"ID: #{chamado.IdChamado}");
                Console.WriteLine($"Título: {chamado.Titulo}");
                Console.WriteLine($"Cliente: {chamado.Cliente.Nome}");
                Console.WriteLine($"Status: {chamado.Status}");
                Console.WriteLine($"Prioridade: {chamado.Prioridade}");
                Console.WriteLine($"Descrição: {chamado.Descricao}");
                Console.WriteLine("--------------------------------");
            }
        }
        
        Console.WriteLine("\nPressione qualquer tecla para voltar...");
        Console.ReadKey();
    }
    
    static void AssumirChamado(Tecnico tecnico){
        Console.Clear();
        Console.WriteLine("=== ASSUMIR CHAMADO ===\n");
        
        Console.Write("Digite o ID do chamado: ");
        if (int.TryParse(Console.ReadLine(), out int idChamado)){
            var chamado = chamadoService.BuscarPorId(idChamado);
            if (chamado != null){
                tecnico.AssumirChamado(chamado);
                chamadoService.AtribuirTecnico(idChamado, tecnico);
                Console.WriteLine($"\nChamado #{idChamado} assumido com sucesso!");
            }
            else{
                Console.WriteLine("\nChamado não encontrado!");
            }
        }
        else{
            Console.WriteLine("ID inválido!");
        }
        
        Console.WriteLine("\nPressione qualquer tecla para voltar...");
        Console.ReadKey();
    }
    
    static void AdicionarObservacaoChamado(Tecnico tecnico){
        Console.Clear();
        Console.WriteLine("=== ADICIONAR OBSERVAÇÃO AO CHAMADO ===\n");
        
        Console.Write("Digite o ID do chamado: ");
        if (int.TryParse(Console.ReadLine(), out int idChamado)){
            var chamado = chamadoService.BuscarPorId(idChamado);
            if (chamado != null && chamado.Tecnico?.IdUsuario == tecnico.IdUsuario){
                Console.Write("Observação: ");
                string observacao = Console.ReadLine();
                
                tecnico.AdicionarObservacao(observacao);
                Console.WriteLine($"\n✅ Observação adicionada ao chamado #{idChamado}!");
            }
            else{
                Console.WriteLine("\nChamado não encontrado ou não está atribuído a você!");
            }
        }
        else{
            Console.WriteLine("ID inválido!");
        }
        
        Console.WriteLine("\nPressione qualquer tecla para voltar...");
        Console.ReadKey();
    }
    
    static void ResolverChamado(Tecnico tecnico){
        Console.Clear();
        Console.WriteLine("=== FINALIZAR CHAMADO ===\n");
        
        Console.Write("Digite o ID do chamado: ");
        if (int.TryParse(Console.ReadLine(), out int idChamado)){
            var chamado = chamadoService.BuscarPorId(idChamado);
            if (chamado != null && chamado.Tecnico?.IdUsuario == tecnico.IdUsuario)
            {
                Console.Write("Digite o motivo do encerramento: ");
                string motivo = Console.ReadLine();
                
                chamadoService.FecharChamado(idChamado, motivo);
                tecnico.ResolverChamado();
                Console.WriteLine($"\n✅ Chamado #{idChamado} finalizado com sucesso!");
            }
            else{
                Console.WriteLine("\nChamado não encontrado ou não está atribuído a você!");
            }
        }
        else{
            Console.WriteLine("ID inválido!");
        }
        
        Console.WriteLine("\nPressione qualquer tecla para voltar...");
        Console.ReadKey();
    }

    static void ListarChamadosDisponiveis(Tecnico tecnico){
    Console.Clear();
    Console.WriteLine("=== CHAMADOS DISPONÍVEIS PARA ASSUMIR ===\n");
    
    if (chamadoService == null){
        Console.WriteLine("Erro: Serviço de chamados não inicializado!");
        Console.ReadKey();
        return;
    }
    
    try{
        var method = chamadoService.GetType().GetMethod("ListarChamadosDisponiveis");
        List<Chamado> chamadosDisponiveis;
        
        if (method != null){
            chamadosDisponiveis = (List<Chamado>)method.Invoke(chamadoService, null);
        }
        else{
            var todosChamados = chamadoService.ListarTodosChamados();
            chamadosDisponiveis = todosChamados
                .Where(c => c.Tecnico == null && c.Status != "Fechado" && c.Status != "Resolvido").ToList();
        }
        
        if (chamadosDisponiveis.Count == 0){
            Console.WriteLine("Nenhum chamado disponível no momento!");
            Console.WriteLine("Todos os chamados já foram atribuídos ou estão fechados.");
        }
        else{
            Console.WriteLine($"📋 Total de chamados disponíveis: {chamadosDisponiveis.Count}\n");
            
            foreach (var chamado in chamadosDisponiveis){
                Console.WriteLine("════════════════════════════════════════════");
                Console.WriteLine($"ID: #{chamado.IdChamado}");
                Console.WriteLine($"Título: {chamado.Titulo}");
                Console.WriteLine($"Status: {chamado.Status}");
                Console.WriteLine($"Prioridade: {chamado.Prioridade}");
                Console.WriteLine($"Cliente: {chamado.Cliente.Nome}");
                Console.WriteLine($"Empresa: {((Cliente)chamado.Cliente).Empresa}");
                Console.WriteLine($"Data Abertura: {chamado.DataAbertura:dd/MM/yyyy HH:mm}");
                Console.WriteLine($"Categoria: {chamado.Categoria?.nome ?? "Sem categoria"}");
                Console.WriteLine("\nDESCRIÇÃO DETALHADA:");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine(chamado.Descricao);
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine($"Protocolo: {chamado.GerarProtocolo()}");
                Console.WriteLine();
            }
            
            Console.WriteLine("════════════════════════════════════════════");
            Console.WriteLine("\n💡 Dica: Anote o ID do chamado que deseja assumir");
            Console.WriteLine("e selecione a opção '3. Assumir chamado' no menu.");
        }
    }
    catch (Exception ex){
        Console.WriteLine($"\nErro ao listar chamados disponíveis: {ex.Message}");
    }
    
    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
    Console.ReadKey();
}
}