namespace CN.Taverna.Domain.Dto.Batalha
{
    public class BatalhaDto : DtoBase
    {
        public HeroiBatalhaDto Ganhador { get; set; }
        public HeroiBatalhaDto Perdedor { get; set; }
    }
}
