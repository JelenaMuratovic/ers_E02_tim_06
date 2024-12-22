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

        IRuterServis ruterServis;
        IRuterRepozitorijum ruteri = new RuterRepozitorijum();
        IPaketRepozitorijum paketi = new PaketRepozitorijum();

        public SlanjePaketaNasumicnoServis(IRuterServis ruterServis)
        {
            this.ruterServis = ruterServis;
        }

        public bool PosaljiPakete()
        {
            var ruteri_lista = ruteri.DobaviRutere().ToList();
            if (ruteri_lista.Count() == 0 || ruteri_lista == null)
            {
                return false;
            }

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
