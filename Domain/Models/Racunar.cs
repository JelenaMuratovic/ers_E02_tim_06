using Domain.Enums;
using Domain.Repozitorijumi.PaketiRepozitorijum;
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

        public IPaketRepozitorijum paketi_racunara = new PaketRepozitorijum();

        public Racunar(string serijskiBrojProizvodjaca, int kapacitetRadneMemorije, int kapacitetSkladisneMemorije, TipSkladisneMemorije tipSkladisneMemorije, string lokalnaIPAdresa)
        {
            SerijskiBrojProizvodjaca = serijskiBrojProizvodjaca;
            KapacitetRadneMemorije = kapacitetRadneMemorije;
            KapacitetSkladisneMemorije = kapacitetSkladisneMemorije;
            TipSkladisneMemorije = tipSkladisneMemorije;
            LokalnaIPAdresa = lokalnaIPAdresa;
        }

    }
}
