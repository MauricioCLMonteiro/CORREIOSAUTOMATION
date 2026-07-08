using OpenQA.Selenium;

namespace CorreiosAutomation.Pages;

public class HomePage
{
    private readonly IWebDriver driver;


    public HomePage(IWebDriver driver)
    {
        this.driver = driver;
    }


    private By MenuBuscaCep =>
        By.XPath("//a[contains(text(),'Busca CEP')]");


    private By MenuRastreamento =>
        By.XPath("//a[contains(text(),'Rastreamento')]");



    public BuscaCepPage AcessarBuscaCep()
    {
        driver.FindElement(MenuBuscaCep).Click();

        return new BuscaCepPage(driver);
    }



    public RastreamentoPage AcessarRastreamento()
    {
        driver.FindElement(MenuRastreamento).Click();

        return new RastreamentoPage(driver);
    }



    public string ObterTituloPagina()
    {
        return driver.Title;
    }

}