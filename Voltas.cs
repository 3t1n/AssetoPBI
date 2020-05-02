using System;
using System.Collections.Generic;
using System.Text;

namespace Asseto
{
    class Voltas
    {
            public float VoltasCompletadas { get; set; }
            public float Posicao { get; set; }
            public string VoltaCorrente { get; set; }
            public string UltimaVolta { get; set; }
            public string MelhorVolta { get; set; }
            public int Setor { get; set; }
            public string TempoSetor { get; set; }
            public int UltimoTempoSetor { get; set; }
            public float DistanciaPercorrida { get; set; }
            public DateTime TimeVolta { get; set; }
    }
}
