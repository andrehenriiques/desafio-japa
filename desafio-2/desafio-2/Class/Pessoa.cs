namespace desafio_2.Class;

public class Pessoa
{
    public string nome;
    public string cpf;
    public int idade;
    public string logradouro;
    public string cidade;
    public string estado;
    public string cep;

    public Pessoa(string nome, string cpf, int idade, string logradouro, string cidade, string estado, string cep)
    {
        this.nome = nome;
        this.cpf = cpf;
        this.idade = idade;
        this.logradouro = logradouro;
        this.cidade = cidade;
        this.estado = estado;
        this.cep = cep;
    }

}