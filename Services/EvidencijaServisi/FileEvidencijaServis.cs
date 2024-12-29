using Domain.Services;
using System.Globalization;

namespace Services.EvidencijaServisi
{
    public class FileEvidencijaServis(string putanja = "paketi.txt") : IEvidencijaServis
    {
        private string putanja = putanja;
        public void Upisi(string paket)
        {
            using StreamWriter sw = new(putanja, append: true);
            sw.Write($"[{DateTime.Now.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture)}]: {paket}\n");
        }
    }
}
