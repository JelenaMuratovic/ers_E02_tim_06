using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repozitorijumi.PaketiRepozitorijum
{
    public class PaketRepozitorijum : IPaketRepozitorijum
    {
        private static List<MrezniPaket> paketi = new List<MrezniPaket>();

        public IEnumerable<MrezniPaket> DobaviPakete()
        {
            return paketi;
        }

        public void DodajPaket(MrezniPaket paket)
        {
            paketi.Add(paket);
        }
    }
}
