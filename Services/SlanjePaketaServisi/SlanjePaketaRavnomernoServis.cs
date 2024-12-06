using Domain.Models;
using Domain.Repozitorijumi.RacunariRepozitorijum;
using Domain.Repozitorijumi.RuteriRepozitorijum;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Services.SlanjePaketaServisi
{
    public class SlanjePaketaRavnomernoServis : ISlanjePaketaServis
    {
        IRuterRepozitorijum ruteri = new RuterRepozitorijum();
        IRacunarRepozitorijum racunari = new RacunarRepozitorijum();
        public SlanjePaketaRavnomernoServis()
        {
        }

        public bool PosaljiPakete(IEnumerable<MrezniPaket> paketi)
        {
            RasporediPakete(paketi);
            List<Racunar> pomocna_racunari = racunari.DobaviRacunare() as List<Racunar>;
            foreach(Racunar r in pomocna_racunari)
            {
                RavnomernoSlanje(r.paketi_racunara.DobaviPakete());
            }
            return true;
            
        }

        public bool RavnomernoSlanje(IEnumerable<MrezniPaket> paketi)
        {
            List<Ruter> ruteri_pomocna = ruteri.DobaviRutere() as List<Ruter>;
            List<MrezniPaket> paketi_pomocni = paketi.ToList();
            int svakome = paketi.Count() / ruteri_pomocna.Count();
            int pomeraj = -1;
            for (int i = 0; i < ruteri_pomocna.Count; i++)
            {
                pomeraj++;
                for (int j = 0; j < svakome; j++)
                {
                    ruteri_pomocna[i].paketi_rutera.DodajPaket(paketi_pomocni[j + pomeraj * svakome]);
                }
            }
            return true;
        }

        public bool RasporediPakete(IEnumerable<MrezniPaket> paketi)
        {
            List<Racunar> racunari_pomocno = racunari.DobaviRacunare()?.ToList();
            if (racunari_pomocno == null || racunari_pomocno.Count == 0)
            {
                throw new InvalidOperationException("Nema dostupnih računara za raspodelu paketa.");
            }
            if (paketi == null || !paketi.Any())
            {
                throw new ArgumentException("Nema paketa za raspodelu.", nameof(paketi));
            }
            int index = 0;
            List<MrezniPaket> paketi_pomocni = paketi.ToList();
            int svakome = paketi.Count() / racunari_pomocno.Count();
            int pomeraj = -1;
            for (int i=0; i< racunari_pomocno.Count; i++)
            {
                pomeraj++;
                for (int j=0; j< svakome;j++)
                {
                    racunari_pomocno[i].paketi_racunara.DodajPaket(paketi_pomocni[j+pomeraj*svakome]);
                }
            }
            return true;
        }
    }

}
