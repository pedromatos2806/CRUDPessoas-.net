using CRUDPessoasTeste.Data;
using CRUDPessoasTeste.DTOS;
using CRUDPessoasTeste.DTOS.Responses;
using CRUDPessoasTeste.Models;
using CRUDPessoasTeste.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRUDPessoasTeste.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly ApplicationDbContext _context;

        public PessoaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PessoaResponse> createPessoaAsync(PessoaCreateDTO pessoaCreateDTO)
        {
            var pessoaExistente = await _context.Pessoas
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Cpf == pessoaCreateDTO.Cpf);

            if (pessoaExistente != null)
            {
                throw new InvalidOperationException("Já existe uma pessoa cadastrada com este CPF.");
            }

            var pessoa = new Pessoa
            {
                Cpf = pessoaCreateDTO.Cpf,
                Rg = pessoaCreateDTO.Rg,
                Nome = pessoaCreateDTO.Nome,
                Nascimento = pessoaCreateDTO.Nascimento,
                Email = pessoaCreateDTO.Email
            };

            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();

            return new PessoaResponse(pessoa);   
        }

        public async Task<bool> deletePessoaAsync(string cpf)
        {
            var pessoa = await _context.Pessoas
                .FirstOrDefaultAsync(p => p.Cpf == cpf);

            if (pessoa == null)
            {
                return false;
            }

            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<PessoaResponse?> getPessoaByCpfAsync(string cpf)
        {
            var pessoa = await _context.Pessoas
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Cpf == cpf);

            if (pessoa == null)
            {
                return null;
            }

            return new PessoaResponse(pessoa);
        }

        public async Task<List<PessoaResponse>> getPessoasAsync()
        {
            var pessoas = await _context.Pessoas
                .AsNoTracking()
                .ToListAsync();

            return pessoas
                .Select(p => new PessoaResponse(p))
                .ToList();
        }

        public async Task<PessoaResponse?> updatePessoaAsync(string cpf, PessoaCreateDTO pessoaUpdateDTO)
        {
            var pessoa = await _context.Pessoas
                .FirstOrDefaultAsync(p => p.Cpf == cpf);

            if (pessoa == null)
            {
                return null;
            }

            pessoa.Rg = pessoaUpdateDTO.Rg;
            pessoa.Nome = pessoaUpdateDTO.Nome;
            pessoa.Nascimento = pessoaUpdateDTO.Nascimento;
            pessoa.Email = pessoaUpdateDTO.Email;

            await _context.SaveChangesAsync();

            return new PessoaResponse(pessoa);
        }

    }
}
