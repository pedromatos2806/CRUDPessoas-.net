using System.ComponentModel.DataAnnotations;

namespace CRUDPessoasTeste.Models
{
    public class Funcionario
    {
        [Key]
        public int Id { get; set; }
        public string? Cargo { get; set; }
        public decimal? Salario { get; set; }

    }
}
