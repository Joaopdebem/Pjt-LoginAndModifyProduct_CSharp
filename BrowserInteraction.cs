using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class BrowserInteraction
{
    private IWebDriver _driver;
    private WebDriverWait _wait;


    public BrowserInteraction(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }

    public void OpenBrowser(string url)
    {
        _driver.Navigate().GoToUrl(url);
    }
	public void CloseBrowser()
	{
		_driver.Quit();
	}


	public void WaitForSeconds(int seconds)
	{
		Thread.Sleep(seconds * 1000);
	}
	public void WaitForElement(string cssSelector)
	{
		_wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(cssSelector)));
	}


	public IWebElement FindElementByCssSelector(string cssSelector)
	{
		return _driver.FindElement(By.CssSelector(cssSelector));
	}
	public void FindElementAndClickCssSelector(string cssSelector)
	{
		var element = FindElementByCssSelector(cssSelector);
		element.Click();
	}


	public IWebElement FindElementById(string id)
	{
		return _driver.FindElement(By.Id(id));
	}
	public void FindElementAndClickId(string id)
	{
		var element = FindElementById(id);
		element.Click();
	}


	public void FillElementAndSendKeys(string cssSelector, string text)
	{
		var element = FindElementByCssSelector(cssSelector);
		element.SendKeys(text);
	}

}