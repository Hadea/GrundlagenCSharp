using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;

namespace BusinessTest
{
    [TestClass]
    public class ErsteTests
    {
        [TestMethod]
        public void Initialisierung()
        {
            Auto meinAuto = new Auto();

            Assert.IsTrue(meinAuto.MethodPublic());
        }
    }
}
