using System.ComponentModel.DataAnnotations;

namespace CRUDPessoasTeste.DTOS
{
    public class PessoaDeleteDTO
    {
        [Required]
        public int Cpf { get; set; }

        public string? Nome { get; set; }
    }
}
