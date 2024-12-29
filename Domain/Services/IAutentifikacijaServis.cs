using Domain.Models;

namespace Domain.Services
{
    public interface IAutentifikacijaServis
    {
        public (bool, Korisnik) Prijava(string KorisnickoIme, string Lozinka);
    }
}
