namespace Browser.NET.UnitTests
{
    using NUnit.Framework;

    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestFixture]
    public class UserAgentTests
    {
        [Test]
        public void CheckBrowserChrome_ChromeVersion41OnPC_ExpectedChrome()
        {
            // Arrange
            var agent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36";
            var browser = new UserAgentMock(agent);

            // Act
            browser.CheckChrome();

            // Assert
            Assert.AreEqual(Browser.Chrome, browser.BrowserName);
        }

        [Test]
        public void CheckBrowserChrome_ChromeVersion41OnMacOS_ExpectedChrome()
        {
            // Arrange
            var agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_10_1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2227.1 Safari/537.36";
            var browser = new UserAgentMock(agent);

            // Act
            browser.CheckChrome();

            // Assert
            Assert.AreEqual(Browser.Chrome, browser.BrowserName);
        }

        [Test]
        public void CheckBrowserChrome_ChromeVersion37OnPC_ExpectedChrome()
        {
            // Arrange
            var agent = "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/37.0.2049.0 Safari/537.36";
            var browser = new UserAgentMock(agent);

            // Act
            browser.CheckChrome();

            // Assert
            Assert.AreEqual(Browser.Chrome, browser.BrowserName);
        }

        [Test]
        public void CheckBrowserChrome_ChromeVersion37OnMacOS_ExpectedChrome()
        {
            // Arrange
            var agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_10_1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/37.0.2062.124 Safari/537.36";
            var browser = new UserAgentMock(agent);

            // Act
            browser.CheckChrome();

            // Assert
            Assert.AreEqual(Browser.Chrome, browser.BrowserName);
        }

        [Test]
        public void CheckBrowserChrome_ChromeOnMobile_ExpectedChrome()
        {
            // Arrange
            var agent = "Mozilla/5.0 (Linux; Android 4.4.2; GT-N7100 Build/KOT49H) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/44.0.2403.133 Mobile Safari/537.36 ";
            var browser = new UserAgentMock(agent);

            // Action
            browser.CheckChrome();

            // Assert
            Assert.AreEqual(Browser.Chrome, browser.BrowserName);
        }

        [Test]
        public void CheckBrowserChrome_ChromeOnTablet_ExpectedChrome()
        {
            // Arrange
            var agent = "Mozilla/5.0 (Linux; Android 4.3; Nexus 7 Build/JWR66Y) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/29.0.1547.72 Safari/537.36";
            var browser = new UserAgentMock(agent);

            // Action
            browser.CheckChrome();

            // Assert
            Assert.AreEqual(Browser.Chrome, browser.BrowserName);
        }

        [Test]
        public void CheckBrowserFireFox_FFVersion36OnPC_ExpectedFireFox()
        {
            // Arrange
            var agent = "Mozilla/5.0 (Windows NT 6.3; rv:36.0) Gecko/20100101 Firefox/36.0";
            var browser = new UserAgentMock(agent);

            // Action
            browser.CheckFF();

            // Assert
            Assert.AreEqual(Browser.Firefox, browser.BrowserName);
        }

        [Test]
        public void CheckBrowserFireFox_FFVersion33OnMacOS_ExpectedFireFox()
        {
            // Arrange
            var agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_10; rv:33.0) Gecko/20100101 Firefox/33.0";
            var browser = new UserAgentMock(agent);

            // Action
            browser.CheckFF();

            // Assert
            Assert.AreEqual(Browser.Firefox, browser.BrowserName);
        }

        [Test]
        public void CheckBrowserFireFox_FFVersion41OnMobile_ExpectedFireFox()
        {
            // Arrange
            var agent = "Mozilla/5.0 (Android 4.4; Mobile; rv:41.0) Gecko/41.0 Firefox/41.0";
            var browser = new UserAgentMock(agent);

            // Action
            browser.CheckFF();

            // Assert
            Assert.AreEqual(Browser.Firefox, browser.BrowserName);
        }

        [Test]
        public void CheckBrowserFireFox_FFVersion41OnTablet_ExpectedFireFox()
        {
            // Arrange
            var agent = "Mozilla/5.0 (Android 4.4; Tablet; rv:41.0) Gecko/41.0 Firefox/41.0";
            var browser = new UserAgentMock(agent);

            // Action
            browser.CheckFF();

            // Assert
            Assert.AreEqual(Browser.Firefox, browser.BrowserName);
        }

        [Test]
        public void CheckBrowserFireFox_FFNoVersion_ExpectedFireFox()
        {
            // Arrange
            var agent = "Mozilla/5.0 (Windows NT 6.3; rv:36.0) Gecko/20100101 Firefox/";
            var browser = new UserAgentMock(agent);

            // Action
            browser.CheckFF();

            // Assert
            Assert.AreEqual(Browser.Firefox, browser.BrowserName);
        }

        [Test]
        public void CheckBrowserOpera_ContainOperaMini_ExpectedOperaMin()
        {
            // Arrange
            var agent = "Opera/9.80 (J2ME/MIDP; Opera Mini/9.80 (S60; SymbOS; Opera Mobi/23.348; U; en) Presto/2.5.25 Version/10.54";
            var browser = new UserAgentMock(agent);

            // Action
            browser.CheckOpera();

            // Assert
            Assert.AreEqual(Browser.OperaMini, browser.BrowserName);
        }

        [Test]
        public void CheckBrowserOpera_ContainOpera_ExpectedOpera()
        {
            // Arrange
            var agent = "Opera/9.80 (X11; Linux i686; Ubuntu/14.10) Presto/2.12.388 Version/12.16";
            var browser = new UserAgentMock(agent);

            // Action
            browser.CheckOpera();

            // Assert
            Assert.AreEqual(Browser.Opera, browser.BrowserName);
        }

        [Test]
        public void CheckBrowserOpera_ContainOPR_ExpectedOpera()
        {
            // Arrange
            var agent = "Mozilla/5.0 (Linux; Android 4.0.3; GT-I9100G Build/IML74K) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/40.0.2214.89 Mobile Safari/537.36 OPR/27.0.1698.89115";
            var browser = new UserAgentMock(agent);

            // Action
            browser.CheckOpera();

            // Assert
            Assert.AreEqual(Browser.Opera, browser.BrowserName);
        }

        [Test]
        public void CheckBrowserSafari_ContainSafariAndNotContainIPhoneAndIPod_ExpectedSafari()
        {
            // Arrange
            var agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_9_3) AppleWebKit/537.75.14 (KHTML, like Gecko) Version/7.0.3 Safari/7046A194A";
            var browser = new UserAgentMock(agent);

            // Action
            browser.CheckSafari();

            // Assert
            Assert.AreEqual(Browser.Safari, browser.BrowserName);
        }

        [Test]
        public void CheckBrowserIE_ContainTridentAndRV_ExpectedIE()
        {
            // Arrange
            var agent = "Mozilla/5.0 (compatible, MSIE 11, Windows NT 6.3; Trident/7.0; rv:11.0) like Gecko";
            var browser = new UserAgentMock(agent);

            // Action
            browser.CheckIE();

            // Assert
            Assert.AreEqual(Browser.IE, browser.BrowserName);
        }

        [Test]
        public void CheckBrowserIE_ContainMSIEAndNotContainOpera_ExpectedIE()
        {
            // Arrange
            var agent = "Mozilla/2.0 (compatible; MSIE 3.03; Windows 3.1)";
            var browser = new UserAgentMock(agent);

            // Action
            browser.CheckIE();

            // Assert
            Assert.AreEqual(Browser.IE, browser.BrowserName);
        }

        [Test]
        public void CheckBrowserIE_ContainMSIEAndIEMobileAndNotContainOpera_ExpectedPocketIE()
        {
            // Arrange
            var agent = "HD_mini_T5555 Mozilla/4.0 (compatible; MSIE 6.0; Windows CE; IEMobile 8.12; MSIEMobile 6.5)";
            var browser = new UserAgentMock(agent);

            // Action
            browser.CheckIE();

            // Assert
            Assert.AreEqual(Browser.PocketIE, browser.BrowserName);
        }

        [Test]
        public void CheckBrowserIE_ContainTrident_ExpectedIE()
        {
            // Arrange
            var agent = "Mozilla/5.0 (compatible, MSIE 11, Windows NT 6.3; Trident/7.0; rv:11.0) like Gecko";
            var browser = new UserAgentMock(agent);

            // Action
            browser.CheckIE();

            // Assert
            Assert.AreEqual(Browser.IE, browser.BrowserName);
        }

        [Test]
        public void CheckBrowserEdge_ContainEdgeOnPC_ExpectedEdge()
        {
            // Arrage
            var agent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2311.135 Safari/537.36 Edge/12.00";
            var browser = new UserAgentMock(agent);

            // Action
            browser.CheckEdge();

            // Assert
            Assert.AreEqual(Browser.Edge, browser.BrowserName);
        }

        [Test]
        public void CheckBrowserEdge_ContainEdgeOnMobile_ExpectedEdge()
        {
            // Arrage
            var agent = "Mozilla/5.0 (Windows Phone 10.0; Android 4.2.1; DEVICE INFO) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2311.135 Mobile Safari/537.36 Edge/12.00124";
            var browser = new UserAgentMock(agent);

            // Action
            browser.CheckEdge();

            // Assert
            Assert.AreEqual(Browser.Edge, browser.BrowserName);
        }        

        [Test]
        public void CheckPlatform_ContainWindows_ExpectedWindows()
        {
            // Arrange
            var agent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:40.0) Gecko/20100101 Firefox/40.0 ";
            var browser = new UserAgent(agent);

            // Action
            browser.Determine();

            // Assert
            Assert.AreEqual(Platforms.Windows, browser.Platform);
        }

        [Test]
        public void CheckPlatform_ContainIpad_ExpectedIpad()
        {
            // Arrange
            var agent = "Mozilla/5.0 (iPad; CPU OS 8_1_2 like Mac OS X) AppleWebKit/600.1.4 (KHTML, like Gecko) Version/8.0 Mobile/12B440 Safari/600.1.4 ";
            var browser = new UserAgent(agent);

            // Action
            browser.Determine();

            // Assert
            Assert.AreEqual(Platforms.Ipad, browser.Platform);
        }

        [Test]
        public void CheckPlatform_ContainIphone_ExpectedIPhone()
        {
            // Arrange
            var agent = "Mozilla/5.0 (iPhone; CPU iPhone OS 8_4_1 like Mac OS X) AppleWebKit/600.1.4 (KHTML, like Gecko) Version/8.0 Mobile/12H321 Safari/600.1.4 ";
            var browser = new UserAgent(agent);

            // Action
            browser.Determine();

            // Assert
            Assert.AreEqual(Platforms.Iphone, browser.Platform);
        }

        [Test]
        public void CheckPlatform_ContainMac_ExpectedMac()
        {
            // Arrange
            var agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_8) AppleWebKit/536.25 (KHTML, like Gecko) Version/6.0 Safari/536.25";
            var browser = new UserAgent(agent);

            // Action
            browser.Determine();

            // Assert
            Assert.AreEqual(Platforms.Apple, browser.Platform);
        }

        [Test]
        public void CheckPlatform_ContainAndroid_ExpectedAndroid()
        {
            // Arrange
            var agent = "Mozilla/5.0 (Linux; U; Android 2.2.1; fr-fr; Desire HD Build/FRG83D) AppleWebKit/533.1 (KHTML, like Gecko) Version/4.0 Mobile Safari/533.1";
            var browser = new UserAgent(agent);

            // Action
            browser.Determine();

            // Assert
            Assert.AreEqual(Platforms.Android, browser.Platform);
        }

        [Test]
        public void CheckPlatform_ContainLinux_ExpectedLinux()
        {
            // Arrange
            var agent = "Mozilla/5.0 (X11; Linux i686; rv:10.0) Gecko/20100101 Firefox/10.0";
            var browser = new UserAgent(agent);

            // Action
            browser.Determine();

            // Assert
            Assert.AreEqual(Platforms.Linux, browser.Platform);
        }
    }
}
