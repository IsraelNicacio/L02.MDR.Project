using MDR.Core.DomainObjects;

namespace MDR.Cadastro.Domain.Entities;

public class Pessoa : Entity, IAggregateRoot
{
    public Guid DepartamentoId { get; private set; }
    public string Nome { get; private set; }
    public string Sobrenome { get; private set; }
    public int Idade { get; private set; }
    public Departamento Departamento { get; private set; }

    public Pessoa()
    { }

    public Pessoa(string nome, string sobrenome, int idade, Guid departamentoId)
    {
        Nome = nome;
        Sobrenome = sobrenome;
        Idade = idade;
        DepartamentoId = departamentoId;
    }

    public void AlterarNome(string nome)
    {
        ValidationDomain.ValidarSeVazioNulo(nome, "O Nome deve ser preenchido");
        ValidationDomain.ValidarCaracteres(nome, 60, "O Nome deve ter no maximo 120 caracteres");

        Nome = nome;
    }

    public void AlterarSobrenome(string sobrenome)
    {
        ValidationDomain.ValidarSeVazioNulo(sobrenome, "O Sobrenome deve ser preenchido");
        ValidationDomain.ValidarCaracteres(sobrenome, 60, "O Sobrenome deve ter no maximo 120 caracteres");

        Sobrenome = sobrenome;
    }

    public void AlterarIdade(int idade)
    {
        ValidationDomain.ValidarMinimoMaximo(idade, 1, 120, "A Idade deve ser informada entre 1 e 120 anos.");

        Idade = idade;
    }

    public void AlterarDepartamento(Departamento departamento)
    {
        if(departamento is not null)
        {
            DepartamentoId = departamento.Id;
            Departamento = departamento;
        }
    }

    public void Validar()
    {
        ValidationDomain.ValidarSeVazioNulo(Nome, "O Nome deve ser preenchido");
        ValidationDomain.ValidarCaracteres(Nome, 60, "O Nome deve ter no maximo 120 caracteres");
        ValidationDomain.ValidarSeVazioNulo(Sobrenome, "O Sobrenome deve ser preenchido");
        ValidationDomain.ValidarCaracteres(Sobrenome, 60, "O Sobrenome deve ter no maximo 120 caracteres");
        ValidationDomain.ValidarMinimoMaximo(Idade, 1, 120, "A Idade deve ser informada entre 1 e 120 anos.");
    }
}
