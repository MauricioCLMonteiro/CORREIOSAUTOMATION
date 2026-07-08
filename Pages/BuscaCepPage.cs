using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CorreiosAutomation.Pages;

public class BuscaCepPage
{
    private readonly IWebDriver driver;

    public BuscaCepPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    private By CampoCep => By.Id("endereco");
    private By BotaoBuscar => By.Id("btn_pesquisar");
    private By ResultadoEndereco => By.Id("resultado");
    private By MensagemErro => By.Id("mensagem-resultado");
    private By CampoCaptcha => By.Id("captcha");

    public void InformarCep(string cep)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        var campo = wait.Until(d => d.FindElement(CampoCep));
        campo.Clear();
        campo.SendKeys(cep);
        wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.getElementById('endereco').value")?.ToString() == cep);
    }

    public void ClicarBuscar()
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        var botao = wait.Until(d => d.FindElement(BotaoBuscar));
        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", botao);
        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", botao);
    }

    public bool ValidarResultado()
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));

        try
        {
            var resultado = wait.Until(d =>
            {
                var elementos = d.FindElements(ResultadoEndereco);
                return elementos.Count > 0 && elementos[0].Displayed ? elementos[0] : null;
            });

            var texto = resultado.Text;
            return texto.Contains("Resultado", StringComparison.OrdinalIgnoreCase)
                || texto.Contains("CEP", StringComparison.OrdinalIgnoreCase)
                || texto.Contains("logradouro", StringComparison.OrdinalIgnoreCase)
                || texto.Contains("bairro", StringComparison.OrdinalIgnoreCase)
                || driver.FindElements(MensagemErro).Any(e => e.Displayed);
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    public string ObterResultadoTexto()
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        try
        {
            var resultado = wait.Until(d =>
            {
                var elementos = d.FindElements(ResultadoEndereco);
                if (elementos.Count > 0 && elementos[0].Displayed)
                    return (IWebElement)elementos[0];

                var mensagens = d.FindElements(MensagemErro);
                if (mensagens.Count > 0 && mensagens[0].Displayed)
                    return (IWebElement)mensagens[0];

                return null;
            });

            return resultado?.Text ?? string.Empty;
        }
        catch (WebDriverTimeoutException)
        {
            return string.Empty;
        }
    }

    public void VoltarInicio()
    {
        driver.Navigate().GoToUrl("https://buscacepinter.correios.com.br/app/endereco/index.php");
    }

    public bool ExisteCaptcha()
    {
        return driver.FindElements(CampoCaptcha).Any(e => e.Displayed);
    }
}