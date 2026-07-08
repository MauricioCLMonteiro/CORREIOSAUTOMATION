using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace CorreiosAutomation.Drivers;

public static class DriverFactory
{
    public static IWebDriver CreateDriver()
    {
        var options = new EdgeOptions();
        var headlessEnv = Environment.GetEnvironmentVariable("CORREIOS_HEADLESS");
        var useHeadless = string.IsNullOrWhiteSpace(headlessEnv) || !headlessEnv.Equals("false", StringComparison.OrdinalIgnoreCase);
        if (useHeadless)
        {
            options.AddArgument("--headless=new");
            options.AddArgument("--disable-gpu");
        }
        options.AddArgument("--window-size=1920,1080");
        options.AddArgument("--no-sandbox");

        var edgeBinaryPath = @"C:\Program Files\Microsoft\Edge\Application\msedge.exe";
        if (File.Exists(edgeBinaryPath))
        {
            options.BinaryLocation = edgeBinaryPath;
        }

        var driverPath = Path.Combine(AppContext.BaseDirectory, "msedgedriver.exe");
        if (File.Exists(driverPath))
        {
            Environment.SetEnvironmentVariable("webdriver.edge.driver", driverPath);
        }

        var driverService = EdgeDriverService.CreateDefaultService(AppContext.BaseDirectory);
        driverService.HideCommandPromptWindow = true;

        return new EdgeDriver(driverService, options);
    }
}