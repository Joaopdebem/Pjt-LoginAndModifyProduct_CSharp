using OpenQA.Selenium;

public class LoginPage
{
    private readonly BrowserInteraction _browser;

    public LoginPage(BrowserInteraction browser)
    {
        _browser = browser;
    }

    public void Login(string usernameCssSelector, string passwordCssSelector, string loginButtonCssSelector, string username, string password)
    {
        _browser.OpenBrowser(Constants.LoginUrl);
		_browser.WaitForSeconds(1);
		_browser.FillElementAndSendKeys(usernameCssSelector, username);
		_browser.WaitForSeconds(1);
		_browser.FillElementAndSendKeys(passwordCssSelector, password);
        _browser.FindElementAndClickCssSelector(loginButtonCssSelector);
        _browser.WaitForSeconds(2);

        try
        {
            _browser.WaitForElement(Constants.ButtonConfirm);
            _browser.FindElementAndClickCssSelector(Constants.ButtonConfirm);
        }
        catch (NoSuchElementException) { }

        _browser.WaitForSeconds(5);
    }
}
