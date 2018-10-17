using System;
using System.Collections.Generic;
using System.Text;

namespace CN.Taverna.Domain.Dto.Especialidade
{
    public class EspecialidadeDto : DtoBase
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Especificacao { get; set; }
        public int NivelRequerido { get; set; }
    }
}
