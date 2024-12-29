using Domain.Models;
using Domain.Repozitorijumi.PaketiRepozitorijum;
using Domain.Repozitorijumi.RuteriRepozitorijum;
using Domain.Services;
using Moq;
using NUnit.Framework;
using Services.SlanjePaketaServisi;

namespace Testovi.Servisi.SlanjePaketaServisi
{
    [TestFixture]
    public class ServisRavnomernogSlanjaPaketaTestovi
    {
        Mock<IRuterServis> _ruterServis;
        Mock<IRuterRepozitorijum> _ruteriRepozitorijum;
        Mock<IPaketRepozitorijum> _paketiRepozitorijum;

        ISlanjePaketaServis _slanjePaketaServis;

        public ServisRavnomernogSlanjaPaketaTestovi()
        {
            _ruterServis = new Mock<IRuterServis>();
            _ruteriRepozitorijum = new Mock<IRuterRepozitorijum>();
            _paketiRepozitorijum = new Mock<IPaketRepozitorijum>();

            _slanjePaketaServis = new SlanjePaketaNasumicnoServis(_ruterServis.Object);
        }
        [SetUp]
        public void Setup()
        {
            _ruterServis = new Mock<IRuterServis>();
            _ruteriRepozitorijum = new Mock<IRuterRepozitorijum>();
            _paketiRepozitorijum = new Mock<IPaketRepozitorijum>();

            _ruterServis.Setup(x => x.PrimiPaket("", new MrezniPaket())).Verifiable();
            _slanjePaketaServis = new SlanjePaketaNasumicnoServis(_ruterServis.Object)
            {
                ruteri = _ruteriRepozitorijum.Object,
                paketi = _paketiRepozitorijum.Object
            };
        }

        [Test]
        [TestCase("123", "124", "125")]
        public void PaketRasporedjenNaRuter_vracaTrue(string serijskiBr1, string serijskiBr2, string serijskiBr3)
        {
            var ruteriLista = new List<Ruter>()
            {
                new Ruter(serijskiBr1,0,0,0),
                new Ruter(serijskiBr2,0,0,0),
                new Ruter(serijskiBr3,0,0,0)
            };
            ruteriLista[0].BrojPaketa = 1;
            ruteriLista[0].BrojPaketa = 3;
            ruteriLista[0].BrojPaketa = 3;

            var paketiLista = new List<MrezniPaket>()
            {
                new MrezniPaket(0,0,0,"",""),
                new MrezniPaket(0,0,0,"",""),
                new MrezniPaket(0,0,0,"","")
            };

            _ruteriRepozitorijum.Setup(r => r.DobaviRutere()).Returns(ruteriLista);
            _paketiRepozitorijum.Setup(p => p.DobaviPakete()).Returns(paketiLista);

            var rezultat = _slanjePaketaServis.PosaljiPakete();


            Assert.That(rezultat, Is.True);
            Assert.That(paketiLista.All(p => p.Poslat), Is.True);
            Assert.That(ruteriLista[0].BrojPaketa, Is.EqualTo(3));

        }

        [Test]
        public void RasporediPaketeNaRutere_NemaRutera_vracaFalse()
        {
            var ruteriLista = new List<Ruter>();

            var paketiLista = new List<MrezniPaket>()
            {
                new MrezniPaket(0,0,0,"",""),
                new MrezniPaket(0,0,0,"",""),
                new MrezniPaket(0,0,0,"","")
            };

            _ruteriRepozitorijum.Setup(r => r.DobaviRutere()).Returns(ruteriLista);
            _paketiRepozitorijum.Setup(p => p.DobaviPakete()).Returns(paketiLista);

            var rezultat = _slanjePaketaServis.PosaljiPakete();

            Assert.That(rezultat, Is.False);
        }
    }
}
