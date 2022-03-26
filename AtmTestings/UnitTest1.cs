using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AtmTestings;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        string result = Cajero.Program.Deposit(001);
        Assert.AreEqual("Deposit completed", result);
    }
}