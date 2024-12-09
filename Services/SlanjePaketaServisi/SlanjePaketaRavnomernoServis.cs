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
            var paketi_racunara = racunari.DobaviPaketeRacunara();
            foreach(Racunar r in racunari.DobaviRacunare())
            {
                RavnomernoSlanje(paketi_racunara[r.LokalnaIPAdresa]);
            }
            return true;
            
        }

        public bool RavnomernoSlanje(IEnumerable<MrezniPaket> paketi)
        {
            List<MrezniPaket> paketiPomocni = paketi.ToList();
            int svakome = paketi.Count() / racunari.DobaviRacunare().Count();
            Dictionary<string, List<MrezniPaket>> paketiRutera = ruteri.DobaviPaketeRutera();

            // Početni indeks za dodelu paketa
            int index = 0;

            // Iteracija kroz računare i dodela paketa
            foreach (var ruter in ruteri.DobaviRutere())
            {

                // Dodela paketa trenutnom računaru
                for (int i = 0; i < svakome; i++)
                {
                    if (index < paketiPomocni.Count())
                    {
                        paketiRutera[ruter.SerijskiBrojProizvodjaca].Add(paketiPomocni[index]);
                        index++;
                    }
                }
            }
            return true;
        }

        public bool RasporediPakete(IEnumerable<MrezniPaket> paketi)
        {
           // List<Racunar> racunari_pomocno = racunari.DobaviRacunare()?.ToList();
            //if (racunari_pomocno == null || racunari_pomocno.Count == 0)
            //{
            //    throw new InvalidOperationException("Nema dostupnih računara za raspodelu paketa.");
            //}
            //if (paketi == null || !paketi.Any())
            //{
            //    throw new ArgumentException("Nema paketa za raspodelu.", nameof(paketi));
            //}
            List<MrezniPaket> paketiPomocni = paketi.ToList();
            int svakome = paketi.Count() / racunari.DobaviRacunare().Count();
            Dictionary<string, List<MrezniPaket>> paketiRacunara = racunari.DobaviPaketeRacunara();
            if (svakome == 0)
            {
                throw new InvalidOperationException("Broj paketa je manji od broja računara.");
            }

            // Početni indeks za dodelu paketa
            int index = 0;

            // Iteracija kroz računare i dodela paketa
            foreach (var racunar in racunari.DobaviRacunare())
            {

                // Dodela paketa trenutnom računaru
                for (int i = 0; i < svakome; i++)
                {
                    if (index < paketiPomocni.Count())
                    {
                        paketiRacunara[racunar.LokalnaIPAdresa].Add(paketiPomocni[index]);
                        index++;
                    }
                }
            }
            return true;
        }
    }

}
