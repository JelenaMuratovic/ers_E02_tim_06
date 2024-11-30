using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Prezentacija.GenerisanjePaketa
{
    public class NasumicanSadrzaj
    {
        private static Random  random = new Random();
        private static readonly string[] sadrzaj =
            [
                "www.example1.com",
                "www.example2.com",
                "www.example3.com",
                "www.example4.com",
            ];
        private static readonly string[] IPadresePrimaoca =
            [
                "192.168.150.45",
                "192.168.150.46",
                "192.168.150.47",
                "192.168.150.48",
                "192.168.150.49",
            ];

        public static MrezniProtokol GenerisiNasumicanProtokol()
        {
            //random.Next(Enum.GetValues(typeof(MrezniProtokol)).Length) je random broj od 0-4
            return (MrezniProtokol)random.Next(Enum.GetValues(typeof(MrezniProtokol)).Length);
        }
        public static int GenerisiNasumicnuVelZaglavlja()
        {
            return random.Next(20);
        }
        public static int GenerisiNasumicnuVelPodataka()
        {
            return random.Next(50);
        }
        public static string GenerisiNasumicanSadrzaj()
        {
            return sadrzaj[random.Next(sadrzaj.Length)];
        }
        public static string GenerisiNasumicnuIPAdresu()
        {
            return sadrzaj[random.Next(IPadresePrimaoca.Length)];
        }
    }
}
