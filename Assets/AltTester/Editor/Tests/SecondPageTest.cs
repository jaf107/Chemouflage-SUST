using NUnit.Framework;
using Altom.AltDriver;

public class SecondPageTest
{   //Important! If your test file is inside a folder that contains an .asmdef file, please make sure that the assembly definition references NUnit.
    public AltDriver altDriver;
    //Before any test it connects with the socket
    [OneTimeSetUp]
    public void SetUp()
    {
        altDriver =new AltDriver();
    }

    //At the end of the test closes the connection with the socket
    [OneTimeTearDown]
    public void TearDown()
    {
        altDriver.Stop();
    }

    [Test]
    public void SecondPageTesting()
    {
        altDriver.LoadScene("2nd Page");
        //Here you can write the test
    }

    [Test]
    public void AR_Button()
    {
        altDriver.LoadScene("2nd Page");
        altDriver.FindObject(By.NAME, "build").Click();

    }

    [Test]
    public void ChemicalBondButton()
    {
        altDriver.LoadScene("2nd Page");
        altDriver.FindObject(By.NAME, "chemBond").Click();
    }

    [Test]
    public void BuildButton()
    {
        altDriver.LoadScene("2nd Page");
        altDriver.FindObject(By.NAME, "build").Click();
    }
}