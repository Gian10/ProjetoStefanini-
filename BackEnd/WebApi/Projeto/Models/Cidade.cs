using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto.Models
{
    public class Cidade
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CidadeId { get; set; }

        public string Nome { get; set; }

        public string Uf { get; set; }
    }
}
