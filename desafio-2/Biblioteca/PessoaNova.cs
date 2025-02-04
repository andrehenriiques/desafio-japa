using desafio_2.Class;

namespace Biblioteca;

public class PessoaNova: Pessoa
{
    public string telefone;
    
    public PessoaNova(string nome, string cpf, int idade, string logradouro, string cidade, string estado, string telefone) : 
        base(nome, cpf, idade, logradouro, cidade, estado)
    {
        this.telefone = telefone;
        Console.WriteLine("Pessoa nova pessoa: " + nome);
    }
}
