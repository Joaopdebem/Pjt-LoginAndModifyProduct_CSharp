public class ProductPage
{
    private readonly BrowserInteraction _browser;
    
    public ProductPage(BrowserInteraction browser)
    {
        _browser = browser;
    }

    public void EditProduct()
    {
        _browser.FindElementAndClickCssSelector(".btn.btn-primary.btn-edicao-item");
        _browser.WaitForSeconds(2);

		_browser.FindElementAndClickId("link-ecommerce");
		_browser.WaitForSeconds(2);

        _browser.FindElementAndClickCssSelector("button[onclick='excluirMapeamentoProdutosEcommerce(1);']");
        _browser.WaitForSeconds(2);

        _browser.FindElementAndClickCssSelector(Constants.ButtonConfirm);
        _browser.WaitForSeconds(2);

        _browser.FindElementAndClickId("botaoSalvar");
        _browser.WaitForSeconds(2);

        _browser.FindElementAndClickCssSelector("button[onclick='regrasAtualizacaoVariacoes.salvarRegras()']");
        _browser.WaitForSeconds(2);

    }
}