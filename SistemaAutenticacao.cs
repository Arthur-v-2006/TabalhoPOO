using System;
using System.Collections.Generic;

namespace TrabalhoPoo;

public class SistemaAutenticacao{
    private List<Usuario> _usuarios = new List<Usuario>();
    
    public Usuario FazerLogin(){
        Console.Clear();
        Console.WriteLine("=== LOGIN ===");
        Console.WriteLine();
        
        Console.Write("Email: ");
        string email = Console.ReadLine();
        
        Console.Write("Senha: ");
        string senha = LerSenhaComMascara();
        
        foreach (var usuario in _usuarios){
            if (usuario.Login(email, senha)){
                return usuario;
            }
        }
        
        Console.WriteLine("\nEmail ou senha incorretos!");
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
        return null;
    }
    
    public void CadastrarNovoUsuario(){
        Console.Clear();
        Console.WriteLine("=== CADASTRO DE NOVO USUÁRIO ===");
        Console.WriteLine();
        Console.WriteLine("1. Cadastrar Cliente");
        Console.WriteLine("2. Cadastrar Técnico");
        Console.WriteLine("0. Voltar");
        
        Console.Write("\nEscolha uma opção: ");
        string opcao = Console.ReadLine();
        
        switch (opcao){
            case "1":
                CadastrarCliente();
                break;
            case "2":
                CadastrarTecnico();
                break;
            case "0":
                return;
            default:
                Console.WriteLine("Opção inválida!");
                Console.ReadKey();
                break;
        }
    }
    
    private void CadastrarCliente(){
        Console.Clear();
        Console.WriteLine("=== CADASTRO DE CLIENTE ===\n");
        
        try{
            int novoId = _usuarios.Count > 0 ? _usuarios[_usuarios.Count - 1].IdUsuario + 1 : 1;
            
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            
            Console.Write("Email: ");
            string email = Console.ReadLine();
            
            Console.Write("Senha: ");
            string senha = Console.ReadLine();
            
            Console.Write("Empresa: ");
            string empresa = Console.ReadLine();
            
            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();
            
            Console.Write("CPF/CNPJ: ");
            string cpfCnpj = Console.ReadLine();
            
            Console.Write("Endereço: ");
            string endereco = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha)){
                Console.WriteLine("\nNome, email e senha são obrigatórios!");
                Console.ReadKey();
                return;
            }
            
            Cliente novoCliente = new Cliente(novoId, nome, email, senha, empresa, telefone, cpfCnpj, endereco);
            
            _usuarios.Add(novoCliente);
            
            Console.WriteLine($"\nCliente '{nome}' cadastrado com sucesso!");
            Console.WriteLine($"ID do usuário: {novoId}");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
        catch (Exception ex){
            Console.WriteLine($"\nErro ao cadastrar cliente: {ex.Message}");
            Console.ReadKey();
        }
    }
    
    private void CadastrarTecnico(){
    Console.Clear();
    Console.WriteLine("=== CADASTRO DE TÉCNICO ===\n");
    
    try{
        int novoId = _usuarios.Count > 0 ? _usuarios[_usuarios.Count - 1].IdUsuario + 1 : 1;
        
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        
        Console.Write("Email: ");
        string email = Console.ReadLine();
        
        Console.Write("Senha: ");
        string senha = Console.ReadLine();
        
        Console.Write("Telefone: ");
        string telefone = Console.ReadLine();
        
        Console.Write("CPF: ");
        string cpf = Console.ReadLine();
        
        Console.Write("Especialidade (Rede/Software/Hardware): ");
        string especialidade = Console.ReadLine();
        
        Console.Write("Nível (Júnior/Pleno/Sênior): ");
        string nivel = Console.ReadLine();
        
        Console.Write("Carga Horária (horas por dia): ");
        if (!double.TryParse(Console.ReadLine(), out double horas)){
            horas = 8;
        }

        if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha)){
            Console.WriteLine("\nNome, email e senha são obrigatórios!");
            Console.ReadKey();
            return;
        }
        
        Tecnico novoTecnico = new Tecnico(novoId, nome, email, senha, especialidade, nivel, TimeSpan.FromHours(horas), telefone, cpf);
        
        _usuarios.Add(novoTecnico);
        
        Console.WriteLine($"\nTécnico '{nome}' cadastrado com sucesso!");
        Console.WriteLine($"ID do usuário: {novoId}");
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
    catch (Exception ex){
        Console.WriteLine($"\nErro ao cadastrar técnico: {ex.Message}");
        Console.ReadKey();
    }
}
    
    private string LerSenhaComMascara(){
        string senha = "";
        ConsoleKeyInfo key;
        
        do{
            key = Console.ReadKey(true);
            
            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter){
                senha += key.KeyChar;
                Console.Write("*");
            }
            else if (key.Key == ConsoleKey.Backspace && senha.Length > 0){
                senha = senha.Substring(0, (senha.Length - 1));
                Console.Write("\b \b");
            }
        }
        while (key.Key != ConsoleKey.Enter);
        
        Console.WriteLine();
        return senha;
    }
}