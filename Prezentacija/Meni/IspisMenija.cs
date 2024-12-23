using Domain.Models;
using Domain.Repozitorijumi.PaketiRepozitorijum;
using Domain.Repozitorijumi.RacunariRepozitorijum;
using Domain.Services;
using Prezentacija.KreiranjePaketa;
using Prezentacija.KreiranjeRacunara;
using Prezentacija.KreiranjeRutera;
using Services;
using Services.DNSServisi;
using Services.MrezaServisi;
using Services.PregledEvidencijeServisi;
using Services.SlanjePaketaServisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Prezentacija.Meni
{
    public class IspisMenija
    {
        private IMrezaServis mrezaServis;
        //private readonly Korisnik korisnik;
        private IPaketRepozitorijum paketi = new PaketRepozitorijum();
        private IAutentifikacijaServis autentifikacija;
        private IRasporediPakete rasporediPaketeServis = new RasporediPaketeServis();
        private IKreiranjePaketaServis kreiranjePaketa;
        private IKreiranjeRacunaraServis kreiranjeRacunara = new KreirajRacunar();
        private IKreiranjeRuteraServis kreiranjeRutera = new KreirajRuter();
        private IRuterServis ruterServis;
        private IDNServis dnsServis;
        private IPregledEvidencijeServis pregledEvidencijeServis;
        private IEvidencijaServis evidencijaServis;
        private ISlanjePaketaServis slanjePaketaServis;

        public IspisMenija(IMrezaServis mrezaServis, IRuterServis ruterServis, IDNServis dnsServis, IPregledEvidencijeServis pregledEvidencijeServis, IEvidencijaServis evidencijaServis, ISlanjePaketaServis slanjePaketaServis)
        {
            this.mrezaServis = mrezaServis;
            kreiranjePaketa = new KreirajPakete();
            this.ruterServis = ruterServis;
            this.dnsServis = dnsServis;
            this.pregledEvidencijeServis = pregledEvidencijeServis;
            this.evidencijaServis = evidencijaServis;
            this.slanjePaketaServis = slanjePaketaServis;
            
        }

        public void PrikaziMeni()
        {
            bool kraj = false;
            while (!kraj)
            {
                Console.WriteLine("\n1. Salji pakete\n2. Pregled paketa\n3. Sacuvaj pakete (u .xml fajl)\n4. Dodaj racunar\n5. Obrisi racunar\n6. Dodaj ruter\n7. Izadji iz programa");
                Console.Write("Opcija: ");
                string? opcija = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(opcija))
                    continue;

                switch (opcija[0])
                {
                    case '1':
                        int brojPaketa;
                        int tipSlanja;
                        Console.WriteLine("Koliko paketa zelite da posaljete?");
                        brojPaketa = Int32.Parse(Console.ReadLine() ?? "");
                        Console.WriteLine("1. Salji nasumicno\n2. Salji ravnomerno\n");
                        tipSlanja = Int32.Parse(Console.ReadLine() ?? "");
                       
                        if (tipSlanja == 2)
                        {
                            slanjePaketaServis = new SlanjePaketaRavnomernoServis(ruterServis);
                        }
                        else
                        {
                            slanjePaketaServis = new SlanjePaketaNasumicnoServis(ruterServis);
                        }
                        mrezaServis = new MrezaServis(autentifikacija, slanjePaketaServis, dnsServis);
                        List<MrezniPaket> kreiraniPaketi = kreiranjePaketa.KreiranjePaketa(brojPaketa) as List<MrezniPaket>;
                        foreach(MrezniPaket mp in kreiraniPaketi)
                        {
                            paketi.DodajPaket(mp);
                        }
                        rasporediPaketeServis.RasporediPaketeRacunarima();
                        mrezaServis.PosaljiPakete();
                        break;
                    case '2':
                        pregledEvidencijeServis = new PregledEvidencijeKonzolaServis();
                        dnsServis = new DNSServis(pregledEvidencijeServis, evidencijaServis);
                        mrezaServis = new MrezaServis(autentifikacija, slanjePaketaServis, dnsServis);
                        if(mrezaServis.PregledPaketa(paketi.DobaviPakete()) == "")
                            Console.WriteLine("lista je prazna");
                        Console.WriteLine(mrezaServis.PregledPaketa(paketi.DobaviPakete()));
                        break;
                    case '3':
                        pregledEvidencijeServis = new PregledEvidencijeXMLServis();
                        dnsServis = new DNSServis(pregledEvidencijeServis, evidencijaServis);
                        mrezaServis = new MrezaServis(autentifikacija, slanjePaketaServis, dnsServis);
                        Console.WriteLine(mrezaServis.PregledPaketa(paketi.DobaviPakete()));
                        break;
                    case '4':
                        bool uspesnoDodavanje = mrezaServis.DodajRacunar(kreiranjeRacunara.KreirajRacunar());
                        if(uspesnoDodavanje)
                            Console.WriteLine("\nUspesno ste dodali racunar");
                        else
                            Console.WriteLine("\nRacunar nije dodat");
                        break;
                    case '5':
                        Console.WriteLine("Unesite serijski broj racunara kojeg zelite da obrisete: ");
                        Console.WriteLine(mrezaServis.PregledRacunara());
                        string serijskiBroj = Console.ReadLine();
                        bool uspesnoBrisanje = mrezaServis.ObrisiRacunar(serijskiBroj);
                        if(uspesnoBrisanje)
                            Console.WriteLine("Uspesno ste obrisali racunar sa serijskim brojem: " + serijskiBroj);
                        else
                            Console.WriteLine("Ne postoji racunar sa tim serijskim brojem");
                        break;
                    case '6':
                        bool uspesnoDodavanjeRuter = mrezaServis.DodajRuter(kreiranjeRutera.KreirajRuter());
                        if (uspesnoDodavanjeRuter)
                            Console.WriteLine("\nUspesno ste dodali ruter");
                        else
                            Console.WriteLine("\nRuter nije dodat");
                        Console.WriteLine(mrezaServis.PregledRutera());
                        break;
                    case '7':
                        kraj = true;
                        break;
                    default:
                        continue;
                }
            }
        }
    }
}
