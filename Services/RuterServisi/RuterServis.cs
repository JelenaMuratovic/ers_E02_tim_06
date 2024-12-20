using Domain.Models;
using Domain.Repozitorijumi.RuteriRepozitorijum;
using Domain.Services;
using Services.DNSServisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RuterServisi
{
    public class RuterServis : IRuterServis
    {
        public IRuterRepozitorijum ruteri;
        public IDNServis dns;

        public RuterServis()
        {
        }

        public RuterServis(IRuterRepozitorijum ruteri, IDNServis dns)
        {
            this.ruteri = ruteri;
            this.dns = dns; ;
        }

        public bool PrimiPaket(string serijskiBroj, MrezniPaket? paket)
        {
            var ruteri_lista = ruteri.DobaviRutere().ToList();
            foreach(Ruter r in ruteri_lista)
            {
                if (r.SerijskiBrojProizvodjaca == serijskiBroj)
                {
                    r.BrojPoslatihPaketa++;                   
                    return dns.PrimiPaket(paket);
                }
            }

            return false;
        }
    }
}
