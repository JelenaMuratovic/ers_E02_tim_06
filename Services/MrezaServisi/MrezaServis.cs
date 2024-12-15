using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Services;
using Services.EvidencijaServisi;

namespace Services.MrezaServisi
{
    public class MrezaServis : IMrezaServis
    {
        private IAutentifikacijaServis auth;
        private ISlanjePaketaServis slanjePaketaServis;
        private IPregledEvidencijeServis pregledServis;

        public MrezaServis(IAutentifikacijaServis auth, IEvidencijaServis fileUpis, ISlanjePaketaServis slanjePaketaServis, IPregledEvidencijeServis pregledServis)
        {
            this.auth = auth;
            this.slanjePaketaServis = slanjePaketaServis;
            this.pregledServis = pregledServis;
        }

        public bool PosaljiPakete()
        {
            return slanjePaketaServis.PosaljiPakete();
        }

        public string PregledPaketa(IEnumerable<MrezniPaket> listaPaketa)
        {
            return pregledServis.Pregled(listaPaketa);
        }

        public (bool, Korisnik) Prijava(string KorisnickoIme, string Lozinka)
        {
            return auth.Prijava(KorisnickoIme, Lozinka);
        }
    }
}
