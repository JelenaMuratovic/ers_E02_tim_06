using Domain.Enums;
using Domain.Models;
using Domain.Repozitorijumi.RuteriRepozitorijum;
using Domain.Services;
using Moq;
using NUnit.Framework;
using Services.RuterServisi;


namespace Testovi.Servisi.RuterServisi
{
    [TestFixture]
    public class RuterServisiTestovi
    {
        Mock<IRuterRepozitorijum> _ruteriRepozitorijum;
        Mock<IDNServis> _dnsServis;

        IRuterServis _ruterServis;

        public RuterServisiTestovi()
        {
            _ruteriRepozitorijum = new Mock<IRuterRepozitorijum>();
            _dnsServis = new Mock<IDNServis>();
        }

        [SetUp]
        public void Setup()
        {
            _ruteriRepozitorijum = new Mock<IRuterRepozitorijum>();
            _dnsServis = new Mock<IDNServis>();
            _ruterServis = new RuterServis(_dnsServis.Object)
            {
                ruteri = _ruteriRepozitorijum.Object
            };
        }

        [Test]
        [TestCase("123", MrezniProtokol.HTTP, 20, 35, "www.example.com", "192.168.150.45")]
        public void PrimiPaket_PovecavaBrojPoslatihPaketaZaOdgovarajuciRuter(string serijskiBroj, MrezniProtokol mp, int velicinaZaglavlja, int velicinaDelaPodataka, string sadrzaj, string IPAdresaPrimaoca)
        {
            var ruter = new Ruter(serijskiBroj, 0, 0, 0);
            var listaRutera = new List<Ruter> { ruter };
            var paket = new MrezniPaket(mp, velicinaZaglavlja, velicinaDelaPodataka, sadrzaj, IPAdresaPrimaoca);

            _ruteriRepozitorijum.Setup(x => x.DobaviRutere()).Returns(listaRutera);
            _dnsServis.Setup(d => d.PrimiPaket(paket)).Returns(true);

            bool uspesnoPrimio = _ruterServis.PrimiPaket(serijskiBroj, paket);

            Assert.That(uspesnoPrimio, Is.True);
            Assert.That(ruter.BrojPaketa, Is.EqualTo(1));
        }

        [Test]
        public void ObjekatJeNull()
        {
            bool uspesno = _ruterServis.PrimiPaket("123", null);

            Assert.That(uspesno, Is.False);
        }
    }
}
