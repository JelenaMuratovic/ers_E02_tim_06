using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Serializable]
    public class MrezniPaket
    {
        public MrezniProtokol Protokol { get; set; }
        public int VelicinaZaglavlja { get; set; }
        public int VelicinaDelaSaPodacima { get; set; }
        public string Sadrzaj { get; set; } = "";
        public string IPAdresaPrimaoca { get; set; } = "";
        public string IPAdresaPosiljaoca { get; set; } = "";
        public bool Poslat { get; set; }
        public MrezniPaket()
        {
        }
        public override string? ToString()
        {
            return "Protokol: " + Protokol + " " + "Header len: " + VelicinaZaglavlja + " App len: " + VelicinaDelaSaPodacima + " Data: " + Sadrzaj + " Destination IP addr: " + IPAdresaPrimaoca;
        }

        public MrezniPaket(MrezniProtokol protokol, int velicinaZaglavlja, int velicinaDelaSaPodacima, string sadrzaj, string iPAdresaPrimaoca)
        {
            Protokol = protokol;
            VelicinaZaglavlja = velicinaZaglavlja;
            VelicinaDelaSaPodacima = velicinaDelaSaPodacima;
            Sadrzaj = sadrzaj;
            IPAdresaPrimaoca = iPAdresaPrimaoca;
            Poslat = false;
        }
    }
}
