using Projeto.Models;

namespace Projeto.Services
{
    public interface IPessoaService
    {

        Task<List<Pessoa>> GetAllAsync();

        Task<Pessoa> CreateAsync(Pessoa pessoa);

        Task<Pessoa> UpdateAsync(int id, Pessoa pessoa);

        Task<int> DeleteAsync(int id);

        Task<Pessoa> GetByIdAsync(int id);
    }
}
