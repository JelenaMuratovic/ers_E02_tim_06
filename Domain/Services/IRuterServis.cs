using Domain.Models;

namespace Domain.Services
{
    public interface IRuterServis
    {
        public bool PrimiPaket(string serijskiBroj, MrezniPaket paket);
    }
}
