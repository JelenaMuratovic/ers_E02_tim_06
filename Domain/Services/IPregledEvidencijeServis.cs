using Domain.Models;

namespace Domain.Services
{
    public interface IPregledEvidencijeServis
    {
        public string Pregled(IEnumerable<MrezniPaket> listaPaketa);
    }
}
