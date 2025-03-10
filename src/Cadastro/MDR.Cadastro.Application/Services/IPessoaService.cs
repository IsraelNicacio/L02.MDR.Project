using AutoMapper;
using MDR.Cadastro.Application.DTO;
using MDR.Cadastro.Domain.Entities;
using MDR.Cadastro.Domain.Repositories;

namespace MDR.Cadastro.Application.Services;

public interface IPessoaService
{
    Task<IEnumerable<PessoaDTO>> RecuperarPessoas();
    Task<PessoaDTO> RecuperarPessoaPorId(Guid id);
    Task<IEnumerable<PessoaDTO>> RecuperarPessoaPorDepartamento(Guid id);
    void AdicionarPessoa(PessoaDTO pessoa);
    void EditarPessoa(PessoaDTO pessoa);
}

public interface IDepartamentoService
{
    Task<IEnumerable<DepartamentoDTO>> RecuperarDepartamentos();
    Task<DepartamentoDTO> RecuperarDepartamentoPorId(Guid id);
    void AdicionarDepartamento(DepartamentoDTO departamento);
    void EditarDepartamento(DepartamentoDTO departamento);
}

public class PessoaService : IPessoaService
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public PessoaService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async void AdicionarPessoa(PessoaDTO pessoa)
    {
        Pessoa _pessoa = _mapper.Map<Pessoa>(pessoa);
        _unitOfWork.Pessoa.AdicionarPessoa(_pessoa);
        await _unitOfWork.Commit();
    }

    public async void EditarPessoa(PessoaDTO pessoa)
    {
        Pessoa _pessoa = _mapper.Map<Pessoa>(pessoa);
        _unitOfWork.Pessoa.EditarPessoa(_pessoa);
        await  _unitOfWork.Commit();
    }

    public async Task<IEnumerable<PessoaDTO>> RecuperarPessoaPorDepartamento(Guid id)
        => _mapper.Map<IEnumerable<PessoaDTO>>(await _unitOfWork.Pessoa.RecuperarPessoaPorDepartamento(id));
    public async Task<PessoaDTO> RecuperarPessoaPorId(Guid id)
        => _mapper.Map<PessoaDTO>(await _unitOfWork.Pessoa.RecuperarPessoaPorId(id));
    public async Task<IEnumerable<PessoaDTO>> RecuperarPessoas()
        => _mapper.Map<IEnumerable<PessoaDTO>>(await _unitOfWork.Pessoa.RecuperarPessoas());
}
