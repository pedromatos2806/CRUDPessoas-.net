using System.ComponentModel.DataAnnotations;

namespace CRUDPessoasTeste.DTOS
{
    public class PessoaUpdateDTO
    {
        [Required(ErrorMessage = "Informe o CPF")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter exatamente 11 caracteres")]
        public string Cpf { get; set; }
        public string? Rg { get; set; }

        [StringLength(100, MinimumLength = 1, ErrorMessage = " O nome deve ter entre 1 e 100 caracteres")]
        public string? Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Nascimento { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
    }
}
