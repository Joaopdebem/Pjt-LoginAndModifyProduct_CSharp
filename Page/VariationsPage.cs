public class VariationsPage
{
    private readonly BrowserInteraction _browser;

    public VariationsPage (BrowserInteraction browser)
    {
        _browser =  browser;
    }

    public void GoToVariations()
    {
        _browser.OpenBrowser(Constants.ProductsUrl);
        _browser.WaitForSeconds(2);
        _browser.WaitForElement(Constants.VariationsPage);
        _browser.FindElementAndClickCssSelector(Constants.VariationsPage);
        _browser.WaitForSeconds(2);
    }
}