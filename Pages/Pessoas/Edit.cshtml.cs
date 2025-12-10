using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using CRUDPessoasTeste.DTOS;
using CRUDPessoasTeste.DTOS.Responses;
using CRUDPessoasTeste.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUDPessoasTeste.Pages.Pessoas
{
    public class EditModel : PageModel
    {
        private readonly IPessoaService _pessoaService;

        public EditModel(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [BindProperty]
        public PessoaInputModel Pessoa { get; set; } = new PessoaInputModel();

        [TempData]
        public string? Mensagem { get; set; }

        public async Task<IActionResult> OnGetAsync(string cpf)
        {
            var pessoa = await _pessoaService.getPessoaByCpfAsync(cpf);

            if (pessoa == null)
            {
                return NotFound();
            }

            Pessoa = new PessoaInputModel
            {
                Cpf = pessoa.Cpf,
                Rg = pessoa.Rg,
                Nome = pessoa.Nome,
                Nascimento = (DateTime) pessoa.Nascimento,
                Email = pessoa.Email
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var dto = new PessoaCreateDTO
            {
                Cpf = Pessoa.Cpf,
                Rg = Pessoa.Rg,
                Nome = Pessoa.Nome,
                Nascimento = Pessoa.Nascimento,
                Email = Pessoa.Email
            };

            var result = await _pessoaService.updatePessoaAsync(Pessoa.Cpf, dto);

            if (result == null)
            {
                return NotFound();
            }

            Mensagem = "Pessoa atualizada com sucesso.";
            return RedirectToPage("Index");
        }

        public class PessoaInputModel
        {
            [Required]
            public string Cpf { get; set; } = string.Empty;

            [Required]
            public string Rg { get; set; } = string.Empty;

            [Required]
            public string Nome { get; set; } = string.Empty;

            [Required]
            [DataType(DataType.Date)]
            public DateTime Nascimento { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; } = string.Empty;
        }
    }
}