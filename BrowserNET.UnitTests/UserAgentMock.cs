namespace BrowserNET.UnitTests
{
    public class UserAgentMock : UserAgentParser
    {
        public UserAgentMock(string agent)
            : base(agent)
        {
        }

        public bool CheckUC()
        {
            return this.CheckBrowserUC();
        }

        public bool CheckEdge()
        {
            return this.CheckBrowserEdge();
        }

        public bool CheckIE()
        {
            return this.CheckBrowserInternetExplore();
        }

        public bool CheckFF()
        {
            return this.CheckBrowserFireFox();
        }

        public bool CheckSafari()
        {
            return this.CheckBrowserSafari();
        }

        public bool CheckOpera()
        {
            return this.CheckBrowserOpera();
        }

        public bool CheckChrome()
        {
            return this.CheckBrowserChrome();
        }

        public void CheckPlatforms()
        {
            base.CheckPlatform();
        }
    }
}
