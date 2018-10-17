namespace CN.Taverna.Domain.Entities
{
    public class Especialidade : ModelBase
    {
        public string Titulo { get; set; }
        public string Especificacao { get; set; }
        public int NivelRequerido { get; set; }
    }
}
