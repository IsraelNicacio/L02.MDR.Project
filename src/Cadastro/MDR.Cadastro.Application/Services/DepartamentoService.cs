using AutoMapper;
using MDR.Cadastro.Application.DTO;
using MDR.Cadastro.Domain.Entities;
using MDR.Cadastro.Domain.Repositories;

namespace MDR.Cadastro.Application.Services;

public class DepartamentoService : IDepartamentoService
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public DepartamentoService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async void AdicionarDepartamento(DepartamentoDTO departamento)
    {
        Departamento _departamento = _mapper.Map<Departamento>(departamento);
        _unitOfWork.Pessoa.AdicionarDepartamento(_departamento);
        await _unitOfWork.Commit();
    }

    public async void EditarDepartamento(DepartamentoDTO departamento)
    {
        Departamento _departamento = _mapper.Map<Departamento>(departamento);
        _unitOfWork.Pessoa.EditarDepartamento(_departamento);
        await _unitOfWork.Commit();
    }

    public async Task<IEnumerable<DepartamentoDTO>> RecuperarDepartamentos()
        => _mapper.Map<IEnumerable<DepartamentoDTO>>(await _unitOfWork.Pessoa.RecuperarDepartamentos());

    public async Task<DepartamentoDTO> RecuperarDepartamentoPorId(Guid id)
        => _mapper.Map<DepartamentoDTO>(await _unitOfWork.Pessoa.RecuperarDepartamentoPorId(id));
}
