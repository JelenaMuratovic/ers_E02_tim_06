using Domain.Models;
using Domain.Repozitorijumi.RacunariRepozitorijum;
using Domain.Repozitorijumi.RuteriRepozitorijum;
using Domain.Services;
using Services.DNSServisi;
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
        IRacunarRepozitorijum racunari = new RacunarRepozitorijum();
        IDNS dns = new DNSServis();
        public SlanjePaketaRavnomernoServis()
        {
        }

        public bool PosaljiPakete(IEnumerable<MrezniPaket> paketi)
        {
            Console.WriteLine("broj paketa za slanje: "+paketi.Count());
            RasporediPakete(paketi);
            List<Racunar> pomocna_racunari = racunari.DobaviRacunare() as List<Racunar>;
            var paketi_racunara = racunari.DobaviPaketeRacunara();

            RavnomernoSlanjeRuter();
            SlanjeDNSu();
            return true;
            
        }
        public bool SlanjeDNSu()
        {
            foreach (var ruter in ruteri.DobaviPaketeRutera())
            {
                foreach (var paket in ruter.Value)
                {
                    dns.PrimiPaket(paket);
                }
            }
            return true;
        }

        public bool RavnomernoSlanjeRuter()
        {
            // Dohvatanje paketa svih računara
            Dictionary<string, List<MrezniPaket>> paketiRacunara = racunari.DobaviPaketeRacunara();
            Dictionary<string, List<MrezniPaket>> paketiRutera = ruteri.DobaviPaketeRutera();

            // Dohvatanje svih rutera
            List<Ruter> ruteriLista = ruteri.DobaviRutere() as List<Ruter>;
            int brojRutera = ruteriLista.Count();

            if (brojRutera == 0)
            {
                throw new InvalidOperationException("Nema dostupnih rutera za raspodelu.");
            }

            //int index = 0;
            // Iteracija kroz računare
            foreach (var racunarEntry in paketiRacunara)
            {
                string racunarIP = racunarEntry.Key; // IP adresa računara
                List<MrezniPaket> paketiRacunaraLista = racunarEntry.Value; // Paketi ovog računara

                // Početni indeks za dodelu paketa
                int index = 0;

                // Iteracija kroz pakete računara i raspodela na rutere
                foreach (var paket in paketiRacunaraLista)
                {
                    // Određivanje rutera po kružnom principu
                    var ruter = ruteriLista[index % brojRutera];
                    paketiRutera[ruter.SerijskiBrojProizvodjaca].Add(paket);

                    // Prelazak na sledeći ruter
                    index++;
                }
            }

            return true;
        }

        //public bool RavnomernoSlanjeRuter(IEnumerable<MrezniPaket> paketi)
        //{
        //    List<MrezniPaket> paketiPomocni = paketi.ToList();
        //    int svakome = paketi.Count() / racunari.DobaviRacunare().Count();
        //    Dictionary<string, List<MrezniPaket>> paketiRutera = ruteri.DobaviPaketeRutera();

        //    // Početni indeks za dodelu paketa
        //    int index = 0;

        //    // Iteracija kroz računare i dodela paketa
        //    foreach (var ruter in ruteri.DobaviRutere())
        //    {

        //        // Dodela paketa trenutnom računaru
        //        for (int i = 0; i < svakome; i++)
        //        {
        //            if (index < paketiPomocni.Count())
        //            {
        //                paketiRutera[ruter.SerijskiBrojProizvodjaca].Add(paketiPomocni[index]);
        //                index++;
        //            }
        //        }
        //    }
        //    return true;
        //}

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
            var ostatak = paketi.Count() % racunari.DobaviRacunare().Count();
            Console.WriteLine("ostatak "+ostatak);
            List<Racunar> racunariLista = racunari.DobaviRacunare() as List<Racunar>;   
            if (ostatak != 0)
            {
                for (int i=0; i<ostatak; i++)
                {
                    Console.WriteLine("PAKET");
                    var racunar = racunariLista[index % racunariLista.Count()];
                    paketiRacunara[racunar.LokalnaIPAdresa].Add(paketiPomocni[index]);
                    index++;
                }
            }
            return true;
        }
    }

}
