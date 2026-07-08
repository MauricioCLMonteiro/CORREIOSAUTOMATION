using OpenQA.Selenium;
using TechTalk.SpecFlow;
using CorreiosAutomation.Drivers;

namespace CorreiosAutomation.Hooks;

[Binding]
public class Hooks
{
    private IWebDriver? driver;

    [BeforeScenario]
    public void BeforeScenario(ScenarioContext context)
    {
        driver = DriverFactory.CreateDriver();
        context["driver"] = driver;
    }

    [AfterScenario]
    public void AfterScenario()
    {
        driver?.Quit();
    }
}