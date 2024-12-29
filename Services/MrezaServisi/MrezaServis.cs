using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Repozitorijumi.RacunariRepozitorijum;
using Domain.Repozitorijumi.RuteriRepozitorijum;
using Domain.Services;
using Services.EvidencijaServisi;

namespace Services.MrezaServisi
{
    public class MrezaServis : IMrezaServis
    {
        private IAutentifikacijaServis auth;
        private ISlanjePaketaServis slanjePaketaServis;
        private IDNServis dnsServis;
        public IRacunarRepozitorijum Racunari { get; set; } = new RacunarRepozitorijum();
        public IRuterRepozitorijum Ruteri { get; set; } = new RuterRepozitorijum();

        public MrezaServis(IAutentifikacijaServis auth, ISlanjePaketaServis slanjePaketaServis, IDNServis dnsServis)
        {
            this.auth = auth;
            this.slanjePaketaServis = slanjePaketaServis;
            this.dnsServis = dnsServis;
        }
       
        public bool DodajRacunar(Racunar racunar)
        {
            return Racunari.DodajRacunar(racunar);
        }

        public bool DodajRuter(Ruter ruter)
        {
            return Ruteri.DodajRuter(ruter);
        }

        public bool ObrisiRacunar(string serijskiBroj)
        {
            return Racunari.ObrisiRacunar(serijskiBroj);
        }

        public bool PosaljiPakete()
        {
            return slanjePaketaServis.PosaljiPakete();
        }

        public string PregledPaketa(IEnumerable<MrezniPaket> listaPaketa)
        {
            return dnsServis.Evidentiraj(listaPaketa);
        }

        public (bool, Korisnik) Prijava(string KorisnickoIme, string Lozinka)
        {
            return auth.Prijava(KorisnickoIme, Lozinka);
        }
        public string? PregledRacunara()
        {
            return "Racunari:\n" + Racunari.ToString();
        }
        public string? PregledRutera()
        {
            return "Ruteri:\n" + Ruteri.ToString();
        }
    }
}
