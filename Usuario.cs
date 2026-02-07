using System;
using System.Collections.Generic;

namespace TrabalhoPoo;

// SRP: Responsabilidade única - gerenciar dados básicos de usuário
// OCP: Aberta para extensão (Cliente, Tecnico) mas fechada para modificação
// LSP: Pode ser substituída por qualquer classe derivada sem quebrar o sistema
public abstract class Usuario{
    protected int idUsuario;
    protected string nome;
    protected string email;
    private string senha;
    protected bool ativo;

    public Usuario(int idUsuario, string nome, string email, string senha){
        this.idUsuario = idUsuario;
        this.nome = nome;
        this.email = email;
        this.senha = senha;
        this.ativo = true;
    }

    public string Email{
        get { return email; }
        protected set { email = value; }
    }

    public string Nome{
        get { return nome; }
        set { nome = value; }
    }

    public int IdUsuario{
        get { return idUsuario; }
    }

    public bool Ativo{
        get { return ativo; }
        set { ativo = value; }
    }

public bool Login(string email, string senha)
{
    // 1. Limpa os dados de entrada
    email = email?.Trim() ?? "";
    senha = senha?.Trim() ?? "";
    
    // 2. Compara de forma segura (tratando nulls)
    bool emailCorreto = string.Equals(this.email?.Trim(), email, StringComparison.OrdinalIgnoreCase);
    bool senhaCorreta = string.Equals(this.senha?.Trim(), senha, StringComparison.Ordinal);
    
    // 3. Se ambos estiverem corretos E o usuário estiver ativo
    if (emailCorreto && senhaCorreta && ativo)
    {
        return true; // Login bem-sucedido
    }
    
    // 4. Caso contrário, retorna false
    return false;
}

    public void Logout(){
        Console.WriteLine($"Usuário {nome} realizou logout.");
    }

    public void RecuperarSenha(){
        Console.WriteLine($"Instruções de recuperação enviadas para {email}");
    }

    public bool AlterarDados(string novoNome = null, string novoEmail = null, string senhaAtual = null, string novaSenha = null){
        bool dadosAlterados = false;

        if (!string.IsNullOrEmpty(novoNome) && novoNome != nome){
            nome = novoNome;
            Console.WriteLine($"Nome alterado para: {novoNome}");
            dadosAlterados = true;
        }

        if (!string.IsNullOrEmpty(novoEmail) && novoEmail != email){
            email = novoEmail;
            Console.WriteLine($"Email alterado para: {novoEmail}");
            dadosAlterados = true;
        }

        if (!string.IsNullOrEmpty(novaSenha)){
            if (string.IsNullOrEmpty(senhaAtual)){
                Console.WriteLine("Para alterar a senha, informe a senha atual.");
                return dadosAlterados;
            }

            if (this.senha != senhaAtual){
                Console.WriteLine("Senha atual incorreta.");
                return dadosAlterados;
            }
            
            if (novaSenha.Length >= 6){
                senha = novaSenha;
                Console.WriteLine("Senha alterada com sucesso.");
                dadosAlterados = true;
            }
            else{
                Console.WriteLine("A nova senha deve ter pelo menos 6 caracteres.");
            }
        }
        return dadosAlterados;
    }

    public virtual void ExibirInformacoes(){
        Console.WriteLine($"ID: {idUsuario}");
        Console.WriteLine($"Nome: {nome}");
        Console.WriteLine($"Email: {email}");
        Console.WriteLine($"Status: {(ativo ? "Ativo" : "Inativo")}");
    }

}