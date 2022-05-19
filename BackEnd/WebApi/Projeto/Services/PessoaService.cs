using Microsoft.EntityFrameworkCore;
using Projeto.Models;

namespace Projeto.Services
{
    public class PessoaService : IPessoaService
    {

        private readonly DatabaseContext _context;

        public PessoaService(DatabaseContext context)
        {
            _context = context;
        }



        public async Task<Pessoa> CreateAsync(Pessoa pessoa)
        {
            if (pessoa == null)
                throw new ArgumentException("Erro!");

            _context.pessoas.Add(pessoa);
            var result = await _context.SaveChangesAsync();
            return pessoa;
        }



        public async Task<int> DeleteAsync(int id)
        {
            var result = await _context.pessoas.FirstOrDefaultAsync(item => item.PessoaId == id);
            if (result == null) throw new ArgumentException("Sem resultados!");

            _context.Remove(result);
            await _context.SaveChangesAsync();
            return result.PessoaId;
        }



        public async Task<List<Pessoa>> GetAllAsync()
        {
            var result = await _context.pessoas.ToListAsync();
            return result;
        }



        public async Task<Pessoa> GetByIdAsync(int id)
        {
            var result = await _context.pessoas.FirstOrDefaultAsync(item => item.PessoaId == id);
            if (result == null) throw new ArgumentException("Sem resultados!");

            return result;
        }



        public async Task<Pessoa> UpdateAsync(int id, Pessoa pessoa)
        {
            if (pessoa == null)
                throw new ArgumentException("Sem resultados!");

            var result = await _context.pessoas.FirstOrDefaultAsync(item => item.PessoaId == id);
            if (result != null)
            {
                result.Nome = pessoa.Nome;
                result.Cpf = pessoa.Cpf;
                result.Idade = pessoa.Idade;
                result.CidadeId = pessoa.CidadeId;

                await _context.SaveChangesAsync();
            }
            return pessoa;
        }
    }
}
