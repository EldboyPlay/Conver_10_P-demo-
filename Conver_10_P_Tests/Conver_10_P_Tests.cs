using NUnit.Framework;
using Конвертор;

namespace Conver_10_P_Tests
{
    [TestFixture]
    public class Conver_10_P_Tests
    {
        [Test]
        public void int_to_Char_ConvertsNumbersToChars()
        {
            Assert.That(Conver_10_P.int_to_Char(0), Is.EqualTo('0'));
            Assert.That(Conver_10_P.int_to_Char(9), Is.EqualTo('9'));
            Assert.That(Conver_10_P.int_to_Char(10), Is.EqualTo('A'));
            Assert.That(Conver_10_P.int_to_Char(15), Is.EqualTo('F'));
        }

        [Test]
        public void int_to_Char_ThrowsExceptionForInvalidNumbers()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Conver_10_P.int_to_Char(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => Conver_10_P.int_to_Char(16));
        }


        [Test]
        public void int_to_P_ConvertsIntegersToBaseStrings()
        {
            Assert.That(Conver_10_P.int_to_P(255, 2), Is.EqualTo("11111111"));
            Assert.That(Conver_10_P.int_to_P(-255, 16), Is.EqualTo("-FF"));
            Assert.That(Conver_10_P.int_to_P(0, 2), Is.EqualTo("0"));
        }

        [Test]
        public void flt_to_P_ConvertsFractionsToBaseStrings()
        {
            Assert.That(Conver_10_P.flt_to_P(0.5, 2, 3), Is.EqualTo("100"));
            Assert.That(Conver_10_P.flt_to_P(0.1, 10, 2), Is.EqualTo("10"));
        }

        [Test]
        public void Do_ConvertsNumbersToBaseStrings()
        {
            Assert.That(Conver_10_P.Do(-17.875, 16, 3), Is.EqualTo("-11.E"));
            Assert.That(Conver_10_P.Do(0.1, 2, 5), Is.EqualTo("0.00011"));
        }

        [Test]
        public void Do_ThrowsExceptionForInvalidBases()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Conver_10_P.Do(1, 1, 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => Conver_10_P.Do(1, 17, 1));
        }
    }
}
