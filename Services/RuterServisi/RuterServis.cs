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
        public IRuterRepozitorijum ruteri = new RuterRepozitorijum();
        public IDNServis dns;
        public RuterServis(IDNServis dns)
        {
            this.dns = dns;
        }

        public bool PrimiPaket(string serijskiBroj, MrezniPaket? paket)
        {
            var ruteri_lista = ruteri.DobaviRutere().ToList();
            foreach(Ruter r in ruteri_lista)
            {
                if (r.SerijskiBrojProizvodjaca == serijskiBroj)
                {                
                    return dns.PrimiPaket(paket);
                }
            }

            return false;
        }
    }
}
