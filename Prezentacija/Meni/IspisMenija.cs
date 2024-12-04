using Domain.Models;
using Domain.Services;
using Services.SlanjePaketaServisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Prezentacija.Meni
{
    public class IspisMenija
    {
        private readonly IMrezaServis mrezaServis;
        //private readonly Korisnik korisnik;
        private ISlanjePaketaServis slanjePaketaServis;

        public IspisMenija(IMrezaServis mrezaServis)
        {
            this.mrezaServis = mrezaServis;
        }

        public void PrikaziMeni()
        {
            bool kraj = false;
            while (!kraj)
            {
                Console.WriteLine("\n1. Salji pakete\n2. Pregled paketa\n3. Sacuvaj pakete (u .xml fajl)\n4. Obrisi racunar");
                Console.Write("Opcija: ");
                string? opcija = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(opcija))
                    continue;

                switch (opcija[0])
                {
                    case '1':
                        int brojPaketa;
                        int tipSlanja;
                        Console.WriteLine("Koliko paketa zelite da posaljete?");
                        brojPaketa = Int32.Parse(Console.ReadLine() ?? "");
                        Console.WriteLine("1. Salji nasumicno\n2. Salji ravnomerno\n");
                        tipSlanja = Int32.Parse(Console.ReadLine() ?? "");
                        if (tipSlanja == 1)
                        {
                            slanjePaketaServis = new SlanjePaketaRavnomernoServis();
                        }
                        else
                        {
                            slanjePaketaServis = new SlanjePaketaNasumicnoServis();
                        }
                        break;
                    case '2':
                        //PregledZapisaNaSajtu();
                        break;
                    case '3':
                        kraj = true;
                        break;
                    default:
                        continue;
                }
            }
        }
    }
}
