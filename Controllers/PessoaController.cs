using CRUDPessoasTeste.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace CRUDPessoasTeste.Controllers
{

    public class PessoaController : Controller
    {
        private readonly IPessoaService _service;

        public PessoaController(IPessoaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePessoa([FromBody] DTOS.PessoaCreateDTO pessoaCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdPessoa = await _service.createPessoaAsync(pessoaCreateDTO);
            return CreatedAtAction(nameof(GetPessoas), new { cpf = createdPessoa.Cpf }, createdPessoa);
        }

        [HttpGet]
        public async Task<IActionResult> GetPessoas()
        {
            var pessoas = await _service.getPessoasAsync();
            return Ok(pessoas);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePessoa([FromQuery] string cpf, [FromBody] DTOS.PessoaCreateDTO pessoaUpdateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedPessoa = await _service.updatePessoaAsync(cpf, pessoaUpdateDTO);
            if (updatedPessoa == null)
            {
                return NotFound();
            }
            return Ok(updatedPessoa);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePessoa([FromQuery] string cpf)
        {
            var deleted = await _service.deletePessoaAsync(cpf);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
