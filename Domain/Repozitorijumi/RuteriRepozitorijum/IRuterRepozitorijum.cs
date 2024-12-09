using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repozitorijumi.RuteriRepozitorijum
{
    public interface IRuterRepozitorijum
    {
        public IEnumerable<Ruter> DobaviRutere();
        public bool DodajRuter(Ruter ruter);
        public Dictionary<string, List<MrezniPaket>> DobaviPaketeRutera();
    }
}
