using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using CRUDPessoasTeste.DTOS;
using CRUDPessoasTeste.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUDPessoasTeste.Pages.Pessoas
{
    public class CreateModel : PageModel
    {
        private readonly IPessoaService _pessoaService;

        public CreateModel(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [BindProperty]
        public PessoaInputModel Pessoa { get; set; } = new PessoaInputModel();

        [TempData]
        public string? Mensagem { get; set; }

        public void OnGet()
        {
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

            try
            {
                await _pessoaService.createPessoaAsync(dto);
                Mensagem = "Pessoa criada com sucesso.";
                return RedirectToPage("Index");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
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