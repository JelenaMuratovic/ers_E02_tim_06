using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repozitorijumi.RacunariRepozitorijum
{
    public interface IRacunarRepozitorijum
    {
        public bool DodajRacunar(Racunar racunar);
        public bool ObrisiRacunar(string SerijskiBroj);
        public IEnumerable<Racunar> DobaviRacunare();
        public Dictionary<string, List<MrezniPaket>> DobaviPaketeRacunara();
    }
}
