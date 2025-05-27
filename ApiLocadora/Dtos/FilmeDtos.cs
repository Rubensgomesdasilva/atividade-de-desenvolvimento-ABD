
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiLocadora.Dtos
{
    public class FilmeDtos
    {
        [Required]
        public required string Nome { get; set; }

        [Required]
        public required string Genero { get; set; }

        [Required]
        public required DateTime AnoLancamento { get; set; }
        [Required]
        public string estudio { get; set; }
    }
}
