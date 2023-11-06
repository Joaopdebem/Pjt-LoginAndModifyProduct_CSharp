using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

class Program
{
    static void Main()
    {
        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArgument("--disable-gpu");
        chromeOptions.AddArgument("--start-maximized");

        using (var driver = new ChromeDriver(chromeOptions))
        {
            var browserInteraction = new BrowserInteraction(driver);
            var loginPage = new LoginPage(browserInteraction);
            var variationsPage = new VariationsPage(browserInteraction);
            var productPage = new ProductPage(browserInteraction);


			loginPage.Login("input[name='username']", 
                            "input[name='password']", 
                            "div button.sc-ispOId.fPZXsr", 
                                Constants.LoginUsername, 
                                Constants.LoginPassword);
            
            variationsPage.GoToVariations();

			bool continueLoop = true;

            while (continueLoop)
            {
				var tableElement = driver.FindElement(By.TagName("tbody"));
				var firstRow = tableElement.FindElement(By.TagName("tr"));

				var ulElementMenu = driver.FindElement(By.CssSelector("ul.dropdown-menu.dropdown-menu-right.menu-acoes-item"));
				var openMenu = "arguments[0].setAttribute('style', 'display: block;');";
				var closeMenu = "arguments[0].setAttribute('style', 'display:;');";

				var clickToTornarSimples = @"var maisAcoesButton = document.querySelector('button.btn-menu-acoes.dropdown-toggle');
                                                 maisAcoesButton.click();
                                                 setTimeout(function() {
                                             var tornarSimplesOption = document.querySelector('#im_11 a');
                                                 tornarSimplesOption.click();
                                              }, 2000);";

				firstRow.Click();
				browserInteraction.WaitForSeconds(4);
				
                // Garantir que o menu esteja fechado para edição do produto.
				((IJavaScriptExecutor)driver).ExecuteScript(closeMenu, ulElementMenu);
				browserInteraction.WaitForSeconds(2);

                // Realiza edição do produto
				productPage.EditProduct(); 
				browserInteraction.WaitForSeconds(3);

                // Abrir menu de ações após edição.
				((IJavaScriptExecutor)driver).ExecuteScript(openMenu, ulElementMenu);
				browserInteraction.WaitForSeconds(2);

                // Tornar o produto em simples invés de variação.
				((IJavaScriptExecutor)driver).ExecuteScript(clickToTornarSimples);
				browserInteraction.WaitForSeconds(3);

                // Confirmar ação
				browserInteraction.FindElementAndClickCssSelector(Constants.ButtonConfirm);
				browserInteraction.WaitForSeconds(5);

				variationsPage.GoToVariations();

				if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Escape)
                    {
                        continueLoop = false;
                    }
                }
            }
            browserInteraction.CloseBrowser();
        }

    }
}
