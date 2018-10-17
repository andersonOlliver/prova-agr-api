using System.ComponentModel.DataAnnotations;

namespace CN.Taverna.Domain.Dto.Batalha
{
    public class PedidoBatalhaDto
    {
        [Required]
        public string IdPrimeiroJogador { get; set; }

        [Required]
        public string IdSegundoJogador { get; set; }
    }
}
