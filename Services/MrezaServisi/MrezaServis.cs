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
        private IEvidencijaServis fileUpis;
        private IKreiranjePaketaServis kreiranjePaketaServis;
        private ISlanjePaketaServis slanjePaketaServis;

        public MrezaServis(IAutentifikacijaServis auth, IEvidencijaServis fileUpis, IKreiranjePaketaServis kreiranjePaketaServis, ISlanjePaketaServis slanjePaketaServis)
        {
            this.auth = auth;
            this.fileUpis = fileUpis;
            this.kreiranjePaketaServis = kreiranjePaketaServis;
            this.slanjePaketaServis = slanjePaketaServis;
        }

        public IEnumerable<MrezniPaket> KreirajPakete(int brojPaketa)
        {
            return kreiranjePaketaServis.KreirajPakete(brojPaketa);
        }

        public bool PosaljiPakete(IEnumerable<MrezniPaket> paketi)
        {
            return slanjePaketaServis.PosaljiPakete(paketi);
        }

        public (bool, Korisnik) Prijava(string KorisnickoIme, string Lozinka)
        {
            return auth.Prijava(KorisnickoIme, Lozinka);
        }

        public void Upisi(string paket)
        {
            fileUpis.Upisi(paket);
        }


    }
}
