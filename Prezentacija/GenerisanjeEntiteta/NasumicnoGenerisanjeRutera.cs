using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prezentacija.GenerisanjeEntiteta
{
    public class NasumicnoGenerisanjeRutera
    {
        private static Random random = new Random();
        private static int poslednjiSerijskiBroj = 227;
        public static string GenerisiSerijskiBrojProizvodjaca()
        {
            return poslednjiSerijskiBroj++.ToString();
        }
        public static int GenerisiNasumicnuMaxBrzinaPrenosaPodataka()
        {
            return random.Next(200, 401);
        }
        public static int GenerisiNasumicanBrojLANPrikljucka()
        {
            return random.Next(10, 81);
        }
        public static VrstaRutera GenerisiNasumicnuVrstuRutera()
        {
            return (VrstaRutera)random.Next(Enum.GetValues(typeof(VrstaRutera)).Length - 1);
        }
    }
}
