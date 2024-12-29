using Domain.Models;
using Domain.Services;
using Prezentacija.Autentifikacija;
using Prezentacija.Meni;
using Services.AutentifikacioniServisi;
using Services.DNSServisi;
using Services.EvidencijaServisi;
using Services.MrezaServisi;
using Services.PregledEvidencijeServisi;
using Services.RuterServisi;
using Services.SlanjePaketaServisi;

namespace Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IAutentifikacijaServis autentifikacijaServis = new AutentifikacioniServis();
            IEvidencijaServis evidencijaServis = new FileEvidencijaServis();
            IPregledEvidencijeServis pregledEvidencijeServis = new PregledEvidencijeKonzolaServis();
            IDNServis dnsServis = new DNSServis(pregledEvidencijeServis, evidencijaServis);
            IRuterServis ruterServis = new RuterServis(dnsServis);
            ISlanjePaketaServis slanjePaketaServis = new SlanjePaketaRavnomernoServis(ruterServis);
            IMrezaServis mrezaServis = new MrezaServis(autentifikacijaServis, slanjePaketaServis, dnsServis);

            var auth = new AutentifikacijaKorisnika(mrezaServis);
            if (!auth.UlogujSe(out Korisnik korisnik)) return;

            var meni = new IspisMenija(autentifikacijaServis, mrezaServis, ruterServis, dnsServis, pregledEvidencijeServis, evidencijaServis, slanjePaketaServis);
            meni.PrikaziMeni();
        }
    }
}
