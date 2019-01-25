using NUnit.Framework;
using Moq;
namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MoveGameTest()
        {
           /* BLL.YearChecker bll = new BLL.YearChecker();
            var mock0 = new Mock<BLL.YearChecker>();
            var mock = new Mock<NationalGames.Game>();
            var mock2 = new Mock<NationalGames.Game>();
            NationalGames.Game g = new NationalGames.Game();
            g.CountryId = 2;
            NationalGames.Game result = bll.moveGame(g, 3);
            mock.Setup(a => a.CountryId).Returns(3);
            if (result.CountryId == mock.Object.CountryId)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }*/
        }
        [Test]
        public void OldestGameTest()
        {
            var mock = new Mock<BLL.IYearChecker>();
            
        }
    }
}