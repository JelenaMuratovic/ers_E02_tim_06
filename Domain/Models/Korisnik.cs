namespace Domain.Models
{
    public class Korisnik
    {
        public string KorisnickoIme { get; set; } = "";
        public string Lozinka { get; set; } = "";

        public string ImePrezime { get; set; } = "";

        public Korisnik() { }

        public Korisnik(string korisnickoIme, string lozinka, string imePrezime)
        {
            KorisnickoIme = korisnickoIme;
            Lozinka = lozinka;
            ImePrezime = imePrezime;
        }
    }
}
