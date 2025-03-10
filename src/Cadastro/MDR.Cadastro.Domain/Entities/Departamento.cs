using MDR.Core.DomainObjects;

namespace MDR.Cadastro.Domain.Entities;

public class Departamento : Entity
{
    public string Nome { get; private set; }
    public ICollection<Pessoa> Pessoas { get; private set; }

    public Departamento()
    { }

    public Departamento(string nome) 
    {
        ValidationDomain.ValidarSeVazioNulo(nome, "O Nome deve ser preenchido");
        ValidationDomain.ValidarCaracteres(nome, 60, "O Nome deve ter no maximo 120 caracteres");

        Nome = nome; 
    }

    public void AlterarNome(string nome)
    {
        ValidationDomain.ValidarSeVazioNulo(nome, "O Nome deve ser preenchido");
        ValidationDomain.ValidarCaracteres(nome, 60, "O Nome deve ter no maximo 120 caracteres");

        Nome = nome;
    }
}
