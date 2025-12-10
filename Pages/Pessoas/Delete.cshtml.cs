using System.Threading.Tasks;
using CRUDPessoasTeste.DTOS.Responses;
using CRUDPessoasTeste.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUDPessoasTeste.Pages.Pessoas
{
    public class DeleteModel : PageModel
    {
        private readonly IPessoaService _pessoaService;

        public DeleteModel(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        public PessoaResponse? Pessoa { get; private set; }

        [TempData]
        public string? Mensagem { get; set; }

        public async Task<IActionResult> OnGetAsync(string cpf)
        {
            Pessoa = await _pessoaService.getPessoaByCpfAsync(cpf);

            if (Pessoa == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string cpf)
        {
            var sucesso = await _pessoaService.deletePessoaAsync(cpf);

            Mensagem = sucesso
                ? "Pessoa excluída com sucesso."
                : "Pessoa não encontrada para exclusão.";

            return RedirectToPage("Index");
        }
    }
}