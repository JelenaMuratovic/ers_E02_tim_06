using Domain.Models;
using Domain.Services;
using Prezentacija.Autentifikacija;
using Prezentacija.Meni;
using Services.AutentifikacioniServisi;
using Services.EvidencijaServisi;
using Prezentacija.KreiranjePaketa;
using Services.MrezaServisi;
using Services.SlanjePaketaServisi;
using Services.PregledEvidencijeServisi;

namespace Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IAutentifikacijaServis autentifikacijaServis = new AutentifikacioniServis();
            IEvidencijaServis evidencijaServis = new FileEvidencijaServis();
            ISlanjePaketaServis slanjePaketaServis = new SlanjePaketaRavnomernoServis();
            IPregledEvidencijeServis pregledServis = new PregledEvidencijeKonzolaServis();
            IMrezaServis mrezaServis = new MrezaServis(autentifikacijaServis, evidencijaServis, slanjePaketaServis, pregledServis);

            var auth = new AutentifikacijaKorisnika(autentifikacijaServis, mrezaServis);
            if (!auth.UlogujSe(out Korisnik korisnik)) return;

            var meni = new IspisMenija(mrezaServis);
            meni.PrikaziMeni();
        }
    }
}
