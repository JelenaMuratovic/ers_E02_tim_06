using Domain.Enums;

namespace Domain.Models
{
    public class DNS
    {
        public string IPAdresa { get; set; } = "";
        public int MaxBrojPovezanihUredjaja { get; set; }
        public string SimbolickaAdresa { get; set; } = "";
        public OperativnoStanje OperativnoStanje { get; set; }

        public DNS(string iPAdresa, int maxBrojPovezanihUredjaja, string simbolickaAdresa, OperativnoStanje operativnoStanje)
        {
            IPAdresa = iPAdresa;
            MaxBrojPovezanihUredjaja = maxBrojPovezanihUredjaja;
            SimbolickaAdresa = simbolickaAdresa;
            OperativnoStanje = operativnoStanje;
        }
    }
}
