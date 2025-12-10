using CRUDPessoasTeste.DTOS.Responses;

namespace CRUDPessoasTeste.Services.Interfaces
{
    public interface IPessoaService
    {
        Task<List<PessoaResponse>> getPessoasAsync();
        Task<PessoaResponse?> getPessoaByCpfAsync(string cpf);
        Task<PessoaResponse> createPessoaAsync(DTOS.PessoaCreateDTO pessoaCreateDTO);
        Task<PessoaResponse?> updatePessoaAsync(string cpf, DTOS.PessoaCreateDTO pessoaUpdateDTO);
        Task<bool> deletePessoaAsync(string cpf);
    }
}
