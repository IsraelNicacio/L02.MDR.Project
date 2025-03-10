using System.ComponentModel.DataAnnotations;

namespace MDR.Cadastro.Application.DTO;

public class DepartamentoDTO
{
    private const string messageErroRequired = "O campo {0} é obrigatório";
    private const string messageErroStringLength = "O campo {0} deve ter no máximo {1} caracteres";

    [Key]
    public Guid Id { get; set; }

    [Display(Name = "Nome")]
    [Required(ErrorMessage = messageErroRequired)]
    [StringLength(60, ErrorMessage = messageErroStringLength)]
    public string Nome { get; set; }
}