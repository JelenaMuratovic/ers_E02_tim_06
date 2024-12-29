using Domain.Models;
using Domain.Services;
using System.Text;

namespace Services.PregledEvidencijeServisi
{
    public class PregledEvidencijeKonzolaServis : IPregledEvidencijeServis
    {
        public string Pregled(IEnumerable<MrezniPaket> listaPaketa)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (MrezniPaket paket in listaPaketa)
            {
                stringBuilder.Append(paket.ToString() + '\n');
            }
            return stringBuilder.ToString();
        }
    }
}
