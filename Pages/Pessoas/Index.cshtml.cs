using System.Collections.Generic;
using System.Threading.Tasks;
using CRUDPessoasTeste.DTOS.Responses;
using CRUDPessoasTeste.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUDPessoasTeste.Pages.Pessoas
{
    public class IndexModel : PageModel
    {
        private readonly IPessoaService _pessoaService;

        public IndexModel(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        public List<PessoaResponse> Pessoas { get; private set; } = new List<PessoaResponse>();

        [TempData]
        public string? Mensagem { get; set; }

        public async Task OnGetAsync()
        {
            Pessoas = await _pessoaService.getPessoasAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(string cpf)
        {
            var sucesso = await _pessoaService.deletePessoaAsync(cpf);

            Mensagem = sucesso
                ? "Pessoa removida com sucesso."
                : "Pessoa não encontrada para remoção.";

            return RedirectToPage();
        }
    }
}