using System.ComponentModel.DataAnnotations;

namespace CRUDPessoasTeste.DTOS.Responses
{
    public class PessoaResponse
    {
        public PessoaResponse(Models.Pessoa pessoa)
        {
            this.Cpf = pessoa.Cpf;
            this.Rg = pessoa.Rg;
            this.Nome = pessoa.Nome;
            this.Nascimento = pessoa.Nascimento;
            this.Email = pessoa.Email;
        }

        [Required(ErrorMessage = "Informe o CPF")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter exatamente 11 caracteres")]
        public string Cpf { get; set; }
        public string? Rg { get; set; }

        [Required(ErrorMessage = "Informe o Nome")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = " O nome deve ter entre 1 e 100 caracteres")]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Nascimento { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Informe o Email")]
        public string Email { get; set; }
    }

}
