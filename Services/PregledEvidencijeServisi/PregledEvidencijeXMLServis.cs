using Domain.Models;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                foreach (MrezniPaket mp in listaPaketa)
                {
                    serialiser.Serialize(writer, mp);
                }
                return "Paketi sacuvani u: " + imeFajla;
            }
            catch(Exception ex)
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
