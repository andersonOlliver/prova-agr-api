using System;
using System.Collections.Generic;
using System.Text;

namespace CN.Taverna.Domain.Entities.Batalha
{
    public class Batalha : ModelBase
    {
        public Heroi Ganhador { get; set; }
        public Heroi Perdedor { get; set; }
    }
}
