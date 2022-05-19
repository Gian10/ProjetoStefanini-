using Projeto.Models;

namespace Projeto.Services
{
    public interface ICidadeService
    {

        Task<List<Cidade>> GetAllAsync();

        Task<Cidade> CreateAsync(Cidade cidade);

        Task<Cidade> UpdateAsync(int id, Cidade cidade);

        Task<int> DeleteAsync(int id);

        Task<Cidade> GetByIdAsync(int id);


    }
}
