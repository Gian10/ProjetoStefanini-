using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto.Models
{
    public class Pessoa
    {
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PessoaId { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public int Idade { get; set; }


        public int CidadeId { get; set; }
      
    }
}
