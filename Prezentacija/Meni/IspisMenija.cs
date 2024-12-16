using Domain.Models;
using Domain.Repozitorijumi.PaketiRepozitorijum;
using Domain.Repozitorijumi.RacunariRepozitorijum;
using Domain.Services;
using Prezentacija.KreiranjePaketa;
using Prezentacija.KreiranjeRacunara;
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
        private ISlanjePaketaServis slanjePaketaServis;
        private IAutentifikacijaServis autentifikacija;
        private IEvidencijaServis fileUpis;
        private IRasporediPakete rasporediPaketeServis = new RasporediPakete();
        private IKreiranjePaketaServis kreiranjePaketa;
        private IKreirajRacunar kreiranjeRacunara = new KreirajRacunar();
        private IDNServis dnsServis;

        public IspisMenija(IMrezaServis mrezaServis)
        {
            this.mrezaServis = mrezaServis;
            kreiranjePaketa = new KreirajPakete(paketi);
        }

        public void PrikaziMeni()
        {
            bool kraj = false;
            while (!kraj)
            {
                Console.WriteLine("\n1. Salji pakete\n2. Pregled paketa\n3. Sacuvaj pakete (u .xml fajl)\n4. Dodaj racunar\n5. Obrisi racunar\n6. Dodaj ruter\n7.Izadji iz programa");
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
                        //mrezaServis.KreirajPakete(brojPaketa);
                       
                        if (tipSlanja == 2)
                        {
                            slanjePaketaServis = new SlanjePaketaRavnomernoServis();
                        }
                        else
                        {
                            slanjePaketaServis = new SlanjePaketaNasumicnoServis();
                        }
                        mrezaServis = new MrezaServis(autentifikacija, fileUpis, slanjePaketaServis, dnsServis);
                        //if (kreiranjePaketa.KreiranjePaketa(brojPaketa) == null)
                        //    Console.WriteLine("nemas pakete");
                        //else
                        //    Console.WriteLine("kreirani su paketi");
                        List<MrezniPaket> kreiraniPaketi = kreiranjePaketa.KreiranjePaketa(brojPaketa) as List<MrezniPaket>;
                        rasporediPaketeServis.RasporediPaketeRacunarima();
                        mrezaServis.PosaljiPakete();
                        //kreiraniPaketi.Clear();
                        break;
                    case '2':
                        //PregledZapisaNaSajtu;
                        dnsServis = new DNSServis(new PregledEvidencijeKonzolaServis());
                        mrezaServis = new MrezaServis(autentifikacija, fileUpis, slanjePaketaServis, dnsServis);
                        if(mrezaServis.PregledPaketa(paketi.DobaviPakete()) == "")
                            Console.WriteLine("lista je prazna");
                        Console.WriteLine(mrezaServis.PregledPaketa(paketi.DobaviPakete()));
                        break;
                    case '3':
                        dnsServis = new DNSServis(new PregledEvidencijeXMLServis());
                        mrezaServis = new MrezaServis(autentifikacija, fileUpis, slanjePaketaServis, dnsServis);
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
                        //ne radi
                        Console.WriteLine("Unesite serijski broj racunara kojeg zelite da obrisete: ");
                        string serijskiBroj = Console.ReadLine();
                        bool uspesnoBrisanje = mrezaServis.ObrisiRacunar(serijskiBroj);
                        if(uspesnoBrisanje)
                            Console.WriteLine("Uspesno ste obrisali racunar sa serijskim brojem: " + serijskiBroj);
                        else
                            Console.WriteLine("Ne postoji racunar sa tim serijskim brojem");
                        break;
                    case '6':
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
