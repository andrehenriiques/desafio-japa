namespace desafio_2.Class;

public class Pessoa
{
    public string nome;
    public string cpf;
    public int idade;
    public string logradouro;
    public string cidade;
    public string estado;

    public Pessoa(string nome, string cpf, int idade, string logradouro, string cidade, string estado)
    {
        this.nome = nome;
        this.cpf = cpf;
        this.logradouro = logradouro;
        this.cidade = cidade;
        this.estado = estado;
    }

}