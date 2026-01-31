using System;
using System.Collections.Generic;

namespace TrabalhoPoo;

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

    public bool Login(string email, string senha){
        if (this.email == email && this.senha == senha && ativo){
            Console.WriteLine($"Usuário {nome} logado com sucesso");
            return true;
        }
        
        Console.WriteLine("Email ou senha incorretos ou usuário inativo");
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