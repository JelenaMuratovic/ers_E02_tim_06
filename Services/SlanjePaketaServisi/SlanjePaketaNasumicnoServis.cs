using Domain.Models;
using Domain.Repozitorijumi.PaketiRepozitorijum;
using Domain.Repozitorijumi.RuteriRepozitorijum;
using Domain.Services;
using Services.RuterServisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SlanjePaketaServisi
{
    public class SlanjePaketaNasumicnoServis : ISlanjePaketaServis
    {

        IRuterServis ruterServis = new RuterServis();
        IRuterRepozitorijum ruteri = new RuterRepozitorijum();
        IPaketRepozitorijum paketi = new PaketRepozitorijum();
        public SlanjePaketaNasumicnoServis()
        {
        }
        public bool PosaljiPakete()
        {
            var ruteri_lista = ruteri.DobaviRutere().ToList();
            foreach (MrezniPaket paket in paketi.DobaviPakete())
            {
                paket.Poslat = true;
                string serijskiBroj = ruteri_lista[new Random().Next(0, ruteri_lista.Count() - 1)].SerijskiBrojProizvodjaca;
                ruterServis.PrimiPaket(serijskiBroj, paket);
            }
            return true;
        }
    }
}
