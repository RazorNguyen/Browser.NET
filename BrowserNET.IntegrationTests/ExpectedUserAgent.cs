namespace BrowserNET.IntegrationTests
{
    public class ExpectedUserAgent
    {
        public string Browser { get; set; }

        public string Platform { get; set; }

        public string Version { get; set; }

        public string AolVersion { get; set; }

        public bool IsAol { get; set; }

        public bool IsMobile { get; set; }

        public bool IsTablet { get; set; }

        public bool IsRobot { get; set; }

        public bool IsFacebook { get; set; }

        public bool IsChromeFrame { get; set; }

        public string RawUserAgent { get; set; }

        public string ShortUserAgent { get; set; }
    }
}
