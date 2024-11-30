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
        public void Upisi(string paket);
        IEnumerable<MrezniPaket> KreirajPakete(int brojPaketa);
        public bool PosaljiPakete(IEnumerable<MrezniPaket> paketi);
    }
}
