using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prezentacija.GenerisanjePaketa
{
    public class NasumicnoGenerisanjeRacunara
    {
        private static Random random = new Random();
        private static readonly int[] KapacitetRadneMemorije = [16,32,64,128];
        private static readonly int[] KapacitetSkladisneMemorije = [256,128,512,1024];
        private static int brojacLokalneIPAdrese = 4;
        private static int brojacSerijskogBroja = 126;
        public static string GenerisiSerijskiBroj()
        {
            return brojacSerijskogBroja++.ToString();
        }
        public static int GenerisiNasumicanKapacitetRadneMemorije()
        {
            return KapacitetRadneMemorije[random.Next(KapacitetRadneMemorije.Length - 1)];
        }
        public static int GenerisiNasumicanKapacitetSkladisneMemorije()
        {
            return KapacitetSkladisneMemorije[random.Next(KapacitetSkladisneMemorije.Length - 1)];
        }
        public static TipSkladisneMemorije GenerisiNasumicanTipSkladisneMemorije()
        {
            return (TipSkladisneMemorije)random.Next(Enum.GetValues(typeof(TipSkladisneMemorije)).Length - 1);
        }
        public static string GenerisiLokalnuIPAdresu()
        {
            return "192.168.10." + brojacLokalneIPAdrese.ToString();
        }
    }
}
