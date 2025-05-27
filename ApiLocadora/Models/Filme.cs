using System.ComponentModel.DataAnnotations.Schema;

namespace ApiLocadora.Models
{
    [Table("filmes")]
    public class Filme
    {
        [Column("id_filme")]
        public int Id { get; set; }
     
        [Column("nome_filme")]
        public string Nome { get; set; }
       [Column("genero_filme")]
        public string Genero { get; set; }
        [Column("ano_filme")]
        public DateOnly AnoLancamento { get; set; }
        [Column("estudio_filme")]
        public string estudio { get; set; }
        
    }
}

