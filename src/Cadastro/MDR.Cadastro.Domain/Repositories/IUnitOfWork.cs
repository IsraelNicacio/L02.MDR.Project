namespace MDR.Cadastro.Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    public IPessoaRepository Pessoa { get; }
    Task<bool> Commit();
}