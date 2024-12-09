using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Repozitorijumi.RacunariRepozitorijum
{
    public class RacunarRepozitorijum : IRacunarRepozitorijum
    {
        private static List<Racunar> racunari;
        private static Dictionary<string, List<MrezniPaket>> paketiRacunara;

        static RacunarRepozitorijum()
        {
            racunari =
                [
                    new("123A", 16, 256, TipSkladisneMemorije.SSD, "192.168.10.0"),
                    new("234B", 64, 1024, TipSkladisneMemorije.HDD, "192.168.1.9"),
                    new("345C", 64, 512, TipSkladisneMemorije.SSD, "192.168.12.7"),
                ];

            paketiRacunara = new Dictionary<string, List<MrezniPaket>>();

            foreach (var racunar in racunari)
            {
                paketiRacunara[racunar.LokalnaIPAdresa] = new List<MrezniPaket>();
            }
        }
        public IEnumerable<Racunar> DobaviRacunare()
        {
            return racunari;
        }

        public bool DodajRacunar(Racunar racunar)
        {
            foreach(Racunar r in racunari)
            {
                if (r.SerijskiBrojProizvodjaca.Equals(racunar.SerijskiBrojProizvodjaca))
                    return false;
            }
            racunari.Add(racunar);
            paketiRacunara[racunar.LokalnaIPAdresa] = new List<MrezniPaket>();
            return true;
        }

        public bool ObrisiRacunar(string SerijskiBroj)
        {
            foreach (Racunar r in racunari)
            {
                if (r.SerijskiBrojProizvodjaca.Equals(SerijskiBroj))
                    racunari.Remove(r);
                return true;
            }
            return false;
        }

        public Dictionary<string, List<MrezniPaket>> DobaviPaketeRacunara()
        {
            return paketiRacunara;
        }
    }
}
