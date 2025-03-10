using MDR.Cadastro.Domain.Repositories;
using MDR.Cadastro.Infrastructure.Data.Context;

namespace MDR.Cadastro.Infrastructure.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly CadastroContext _context;

    public UnitOfWork(CadastroContext context) => _context = context;

    private IPessoaRepository _pessoa;
    public IPessoaRepository Pessoa 
    { get => _pessoa ?? (_pessoa = new PessoaRepository(_context)); }

    public async Task<bool> Commit() => await _context.SaveChangesAsync() > 0;
    public async void Dispose() => await _context.DisposeAsync();
}
