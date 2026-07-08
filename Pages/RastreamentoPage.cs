using OpenQA.Selenium;


namespace CorreiosAutomation.Pages;


public class RastreamentoPage
{

    private readonly IWebDriver driver;


    public RastreamentoPage(IWebDriver driver)
    {
        this.driver = driver;
    }



    private By CampoObjeto =>
        By.Id("objetos");



    private By BotaoPesquisar =>
        By.Id("btnPesquisar");



    private By ResultadoRastreamento =>
        By.ClassName("resultado");



    public void InformarCodigoObjeto(string codigo)
    {

        var campo = driver.FindElement(CampoObjeto);

        campo.Clear();

        campo.SendKeys(codigo);

    }



    public void Pesquisar()
    {
        driver.FindElement(BotaoPesquisar)
              .Click();
    }



    public string ObterStatusObjeto()
    {

        var elementos = driver.FindElements(ResultadoRastreamento);
        return elementos.Count > 0 ? elementos[0].Text : string.Empty;

    }



    public bool ObjetoLocalizado()
    {

        var elementos = driver.FindElements(ResultadoRastreamento);
        return elementos.Count > 0 && elementos[0].Displayed;

    }

}