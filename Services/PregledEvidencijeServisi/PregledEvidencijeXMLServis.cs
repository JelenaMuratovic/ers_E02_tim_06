using Domain.Models;
using Domain.Services;
using System.Xml.Serialization;

namespace Services.PregledEvidencijeServisi
{
    public class PregledEvidencijeXMLServis : IPregledEvidencijeServis
    {
        public string Pregled(IEnumerable<MrezniPaket> listaPaketa)
        {
            string imeFajla = "evidencija.xml";
            StreamWriter writer = new StreamWriter(imeFajla);
            try
            {
                XmlSerializer serialiser = new XmlSerializer(typeof(MrezniPaket));
                if (listaPaketa.Count() == 0)
                    return "Nema paketa za upis u xml datoteku";
                foreach (MrezniPaket mp in listaPaketa)
                {
                    serialiser.Serialize(writer, mp);
                }
                return "Paketi sacuvani u: " + imeFajla;
            }
            catch (Exception ex)
            {
                return "Greska pri upisivanju u xml fajl: " + ex.Message;
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }
    }
}
