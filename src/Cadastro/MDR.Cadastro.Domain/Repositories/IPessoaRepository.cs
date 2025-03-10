using MDR.Cadastro.Domain.Entities;
using MDR.Core.Data;

namespace MDR.Cadastro.Domain.Repositories;

public interface IPessoaRepository : IRepository<Pessoa>
{
    Task<IEnumerable<Pessoa>> RecuperarPessoas();
    Task<Pessoa> RecuperarPessoaPorId(Guid id);
    Task<IEnumerable<Pessoa>> RecuperarPessoaPorDepartamento(Guid id);
    void AdicionarPessoa(Pessoa pessoa);
    void EditarPessoa(Pessoa pessoa);

    Task<IEnumerable<Departamento>> RecuperarDepartamentos();
    Task<Departamento> RecuperarDepartamentoPorId(Guid id);
    void AdicionarDepartamento(Departamento departamento);
    void EditarDepartamento(Departamento departamento);
}
