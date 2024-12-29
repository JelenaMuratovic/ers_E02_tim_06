using Domain.Models;

namespace Domain.Services
{
    public interface IDNServis
    {
        public bool PrimiPaket(MrezniPaket paket);
        public string Evidentiraj(IEnumerable<MrezniPaket> listaPaketa);
    }
}
