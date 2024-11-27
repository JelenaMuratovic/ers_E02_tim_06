using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Ruter
    {
        public string SerijskiBrojProizvodjaca { get; set; } = "";
        public int MaxBrzinaPrenosaPodataka { get; set; }
        public int BrojLANPrikljucka { get; set; }
        public VrstaRutera VrstaRutera { get; set; }
    }
}
