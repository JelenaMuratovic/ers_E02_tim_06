using Domain.Models;
using Domain.PomocneMetode;
using Domain.Repozitorijumi.PaketiRepozitorijum;
using Domain.Services;
using Services.DNSServisi;
using Services.MrezaServisi;
using Services.PregledEvidencijeServisi;
using Services.ServisiRaspodelePaketa;
using Services.SlanjePaketaServisi;

namespace Prezentacija.Meni
{
    public class IspisMenija
    {
        private IMrezaServis mrezaServis;
        //private readonly Korisnik korisnik;
        private IPaketRepozitorijum paketi = new PaketRepozitorijum();
        private IAutentifikacijaServis autentifikacijaServis;
        private IRasporediPakete rasporediPaketeServis = new RasporediPaketeServis();
        private KreirajPakete kreiranjePaketa = new KreirajPakete();
        private KreirajRacunar kreiranjeRacunara = new KreirajRacunar();
        private KreirajRuter kreiranjeRutera = new KreirajRuter();
        private IRuterServis ruterServis;
        private IDNServis dnsServis;
        private IPregledEvidencijeServis pregledEvidencijeServis;
        private IEvidencijaServis evidencijaServis;
        private ISlanjePaketaServis slanjePaketaServis;

        public IspisMenija(IAutentifikacijaServis autentifikacijaServis, IMrezaServis mrezaServis, IRuterServis ruterServis, IDNServis dnsServis, IPregledEvidencijeServis pregledEvidencijeServis, IEvidencijaServis evidencijaServis, ISlanjePaketaServis slanjePaketaServis)
        {
            this.autentifikacijaServis = autentifikacijaServis;
            this.mrezaServis = mrezaServis;
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

                if (string.IsNullOrWhiteSpace(opcija) || !int.TryParse(opcija, out int opcijaBroj))
                    continue;
                if (opcijaBroj < 0 || opcijaBroj > 7)
                    continue;

                switch (opcijaBroj)
                {
                    case 1:
                        int brojPaketa;
                        int tipSlanja;
                        do
                        {
                            Console.WriteLine("\nKoliko paketa zelite da posaljete?");
                            Console.Write("Broj paketa: ");
                        } while (!int.TryParse(Console.ReadLine(), out brojPaketa));
                        
                        Console.WriteLine("1. Salji nasumicno\n2. Salji ravnomerno");
                        Console.Write("Nacin slanja: ");
                        tipSlanja = Int32.Parse(Console.ReadLine() ?? "");

                        if (tipSlanja == 2)
                        {
                            slanjePaketaServis = new SlanjePaketaRavnomernoServis(ruterServis);
                        }
                        else if(tipSlanja == 1)
                        {
                            slanjePaketaServis = new SlanjePaketaNasumicnoServis(ruterServis);
                        }
                        else
                        {
                            Console.WriteLine("Ne postoji taj tip slanja\n");
                            break;
                        }
                        mrezaServis = new MrezaServis(autentifikacijaServis, slanjePaketaServis, dnsServis);
                        List<MrezniPaket> kreiraniPaketi = kreiranjePaketa.KreiranjePaketa(brojPaketa) as List<MrezniPaket>;
                        foreach (MrezniPaket mp in kreiraniPaketi)
                        {
                            paketi.DodajPaket(mp);
                        }
                        rasporediPaketeServis.RasporediPaketeRacunarima();
                        mrezaServis.PosaljiPakete();
                        break;
                    case 2:
                        pregledEvidencijeServis = new PregledEvidencijeKonzolaServis();
                        dnsServis = new DNSServis(pregledEvidencijeServis, evidencijaServis);
                        mrezaServis = new MrezaServis(autentifikacijaServis, slanjePaketaServis, dnsServis);
                        string paketiZaIspis = mrezaServis.PregledPaketa(paketi.DobaviPakete());
                        if (paketiZaIspis == "")
                            Console.WriteLine("lista je prazna");
                        Console.WriteLine(paketiZaIspis);
                        break;
                    case 3:
                        pregledEvidencijeServis = new PregledEvidencijeXMLServis();
                        dnsServis = new DNSServis(pregledEvidencijeServis, evidencijaServis);
                        mrezaServis = new MrezaServis(autentifikacijaServis, slanjePaketaServis, dnsServis);
                        Console.WriteLine(mrezaServis.PregledPaketa(paketi.DobaviPakete()));
                        break;
                    case 4:
                        bool uspesnoDodavanje = mrezaServis.DodajRacunar(kreiranjeRacunara.KreiranjeRacunara());
                        if (uspesnoDodavanje)
                            Console.WriteLine("\nUspesno ste dodali racunar!");
                        else
                            Console.WriteLine("\nRacunar nije dodat!");
                        break;
                    case 5:
                        var racunari = mrezaServis.PregledRacunara();
                        foreach(Racunar r in racunari)
                            Console.WriteLine(r);
                        Console.Write("Unesite serijski broj racunara kojeg zelite da obrisete: ");
                        string serijskiBroj = Console.ReadLine() ?? "";
                        bool uspesnoBrisanje = mrezaServis.ObrisiRacunar(serijskiBroj);
                        if (uspesnoBrisanje)
                            Console.WriteLine("Uspesno ste obrisali racunar sa serijskim brojem: " + serijskiBroj);
                        else
                            Console.WriteLine("Ne postoji racunar sa tim serijskim brojem!");
                        break;
                    case 6:
                        bool uspesnoDodavanjeRuter = mrezaServis.DodajRuter(kreiranjeRutera.KreiranjeRutera());
                        if (uspesnoDodavanjeRuter)
                            Console.WriteLine("\nUspesno ste dodali ruter!");
                        else
                            Console.WriteLine("\nRuter nije dodat!");
                        var ruteri = mrezaServis.PregledRutera();
                        foreach(Ruter r in ruteri)
                            Console.WriteLine(r);
                        break;
                    case 7:
                        kraj = true;
                        break;
                    default:
                        continue;
                }
            }
        }
    }
}
