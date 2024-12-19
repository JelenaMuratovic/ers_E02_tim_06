using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IMrezaServis
    {
        public (bool, Korisnik) Prijava(string KorisnickoIme, string Lozinka);
        public bool PosaljiPakete();
        public string PregledPaketa(IEnumerable<MrezniPaket> listaPaketa);
        public bool DodajRacunar(Racunar racunar);
        public bool ObrisiRacunar(string serijskiBroj);
        public bool DodajRuter(Ruter ruter);
        public string PregledRacunara();
        public string PregledRutera();
    }
}
