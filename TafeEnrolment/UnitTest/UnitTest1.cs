using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer;
namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private Logic logicLayer;

        [TestInitialize]
        public void Init()
        {
            Logic logicLayer = new Logic();
            this.logicLayer = logicLayer;
        }

        [TestMethod]
        public void TestOne()
        {
            //first test goes here
        }

        [TestMethod]
        public void TestTwo()
        {
            //second test goes here
        }
    }
}
