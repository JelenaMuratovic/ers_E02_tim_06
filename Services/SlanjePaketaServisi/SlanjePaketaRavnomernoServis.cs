using Domain.Models;
using Domain.Repozitorijumi.PaketiRepozitorijum;
using Domain.Repozitorijumi.RacunariRepozitorijum;
using Domain.Repozitorijumi.RuteriRepozitorijum;
using Domain.Services;
using Services.DNSServisi;
using Services.RuterServisi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Services.SlanjePaketaServisi
{
    public class SlanjePaketaRavnomernoServis : ISlanjePaketaServis
    {
        IRuterRepozitorijum ruteri = new RuterRepozitorijum();
        IPaketRepozitorijum paketi = new PaketRepozitorijum();
        IRuterServis ruterServis;

        public SlanjePaketaRavnomernoServis(IRuterServis ruterServis)
        {
            this.ruterServis = ruterServis;
        }

        public bool PosaljiPakete()
        {
            var ruteri_lista = ruteri.DobaviRutere().ToList();
            var paketi_lista = paketi.DobaviPakete().ToList();
            if(ruteri_lista.Count == 0 || paketi_lista.Count == 0 || ruteri_lista == null || paketi_lista == null)
                return false;
            for (int i = 0; i < paketi_lista.Count(); i++)
            {
                if (!paketi_lista[i].Poslat)
                {
                    paketi_lista[i].Poslat = true;
                    string serijskiBroj = ruteri_lista[i % ruteri_lista.Count()].SerijskiBrojProizvodjaca;
                    ruterServis.PrimiPaket(serijskiBroj, paketi_lista[i]);
                }
            }
            return true;
        }
    }

}
