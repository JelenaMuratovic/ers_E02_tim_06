using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Racunar
    {
        public string SerijskiBrojProizvodjaca { get; set; } = "";
        public int KapacitetRadneMemorije { get; set; }
        public int KapacitetSkladisneMemorije { get; set; }
        public TipSkladisneMemorije TipSkladisneMemorije { get; set; }
        public string LokalnaIPAdresa { get; set; } = "";
    }
}
