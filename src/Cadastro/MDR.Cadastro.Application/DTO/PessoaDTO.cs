using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDR.Cadastro.Application.DTO;

public class PessoaDTO
{
    private const string messageErroRequired = "O campo {0} é obrigatório";
    private const string messageErroStringLength = "O campo {0} deve ter no máximo {1} caracteres";
    private const string messageErroRange = "O campo {0} deve ter entre {1} e {2}";

    [Key]
    public Guid Id { get; set; }

    [ForeignKey("DepartamentoId")]
    public Guid DepartamentoId { get; set; }

    [Display(Name = "Nome")]
    [Required(ErrorMessage = messageErroRequired)]
    [StringLength(60, ErrorMessage = messageErroStringLength)]
    public string Nome { get; set; }

    [Display(Name = "SobreNome")]
    [Required(ErrorMessage = messageErroRequired)]
    [StringLength(60, ErrorMessage = messageErroStringLength)]
    public string Sobrenome { get; set; }

    [Required(ErrorMessage = messageErroRequired)]
    [Range(18, 120, ErrorMessage = messageErroRange)]
    public int Idade { get; set; }
}
