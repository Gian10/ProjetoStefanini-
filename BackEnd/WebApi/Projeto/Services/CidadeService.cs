using Microsoft.EntityFrameworkCore;
using Projeto.Models;

namespace Projeto.Services
{
    public class CidadeService : ICidadeService
    {

        private readonly DatabaseContext _context;

        public CidadeService(DatabaseContext context)
        {
            _context = context;
        }



        public async Task<Cidade> CreateAsync(Cidade cidade)
        {
            if (cidade == null)
                throw new ArgumentException("Erro!");

            _context.cidade.Add(cidade);
            var result = await  _context.SaveChangesAsync();
            return cidade;
        }



        public async Task<int> DeleteAsync(int id)
        {
            var result = await _context.cidade.FirstOrDefaultAsync(item => item.CidadeId == id);
            if (result == null) throw new ArgumentException("Sem resultados!");

            _context.Remove(result);
            await _context.SaveChangesAsync();
            return result.CidadeId;
        }



        public async Task<List<Cidade>> GetAllAsync()
        {
            var result = await _context.cidade.ToListAsync();
            return result;
        }


        public async Task<Cidade> GetByIdAsync(int id)
        {
            var result = await _context.cidade.FirstOrDefaultAsync(item => item.CidadeId == id);
            if (result == null) throw new ArgumentException("Sem resultados!");

            return result;
        }



        public async Task<Cidade> UpdateAsync(int id, Cidade cidade)
        {
            if (cidade == null)
                throw new ArgumentException("Sem resultados!");

            var result = await _context.cidade.FirstOrDefaultAsync(item => item.CidadeId == id);
            if (result != null)
            {
                result.Nome = cidade.Nome;
                result.Uf = cidade.Uf;
                await _context.SaveChangesAsync();
            }
            return cidade;
        }
    }
}
