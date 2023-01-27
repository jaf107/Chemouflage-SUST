using NUnit.Framework;
using Altom.AltDriver;

public class ExploratoryTest
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
    public void LoadMenu()
    {
        //Here you can write the test
        altDriver.LoadScene("Menu");
//        altDriver.FindObject(By.NAME, "Guest").Click();
//        altDriver.WaitForCurrentSceneToBe("2nd\rPage");
    }

    [Test]
    public void GuestButton()
    {
        //Here you can write the test
        altDriver.LoadScene("Menu");
        altDriver.FindObject(By.NAME, "Guest").Click();
        //        altDriver.WaitForCurrentSceneToBe("2nd\rPage");
    }

    



}