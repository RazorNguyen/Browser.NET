namespace BrowserNET
{
    using System.Linq;
    using System.Text.RegularExpressions;

    public class UserAgentParser
    {
        private const string Unknown = "unknown";
        private string _userAgent;
        private string _userAgentToLower;
        private string _browserName;
        private string _version;
        private bool _isFacebook;
        private bool _isRobot;
        private bool _isTablet;
        private bool _isMobile;
        private bool _isAol;
        private bool _isChromeFrame;
        private string _aolVersion;
        private string _platform;

        public UserAgentParser(string userAgent)
        {
            _userAgent = userAgent;
            _userAgentToLower = userAgent.ToLower();
            BrowserName = Browser.Unknown;
            Version = Unknown;
            Platform = Platforms.Unknown;
            AolVersion = Unknown;
            IsMobile = false;
            IsRobot = false;
            IsTablet = false;
            IsFacebook = false;
            IsAol = false;
        }

        public string AolVersion
        {
            get
            {
                return _aolVersion;
            }

            set
            {
                var regex = new Regex(@"([^0-9,.,a-z,A-Z])");
                _aolVersion = regex.Replace(value, string.Empty);
            }
        }

        public bool IsAol
        {
            get
            {
                return _isAol;
            }

            set
            {
                _isAol = value;
            }
        }

        public string BrowserName
        {
            get
            {
                return _browserName;
            }

            set
            {
                _browserName = value;
            }
        }

        public string Version
        {
            get
            {
                return _version;
            }

            set
            {
                var regex = new Regex(@"([^0-9,.,a-z,A-Z\-])");
                _version = regex.Replace(value, string.Empty);
            }
        }

        public string Platform
        {
            get
            {
                return _platform;
            }

            set
            {
                _platform = value;
            }
        }

        public bool IsMobile
        {
            get
            {
                return _isMobile;
            }

            set
            {
                _isMobile = value;
            }
        }

        public bool IsTablet
        {
            get
            {
                return _isTablet;
            }

            set
            {
                _isTablet = value;
            }
        }

        public bool IsRobot
        {
            get
            {
                return _isRobot;
            }

            set
            {
                _isRobot = value;
            }
        }

        public bool IsFacebook
        {
            get
            {
                return _isFacebook;
            }

            set
            {
                _isFacebook = value;
            }
        }

        public bool IsChromeFrame
        {
            get
            {
                return _isChromeFrame;
            }

            set
            {
                _isChromeFrame = value;
            }
        }

        public void Determine()
        {
            CheckBrowsers();

            CheckPlatform();

            CheckForAol();
        }

        protected void CheckPlatform()
        {
            if (_userAgentToLower.Contains("windows"))
            {
                Platform = Platforms.Windows;
            }
            else if (_userAgentToLower.Contains("ipad"))
            {
                Platform = Platforms.Ipad;
            }
            else if (_userAgentToLower.Contains("ipod"))
            {
                Platform = Platforms.Ipod;
            }
            else if (_userAgentToLower.Contains("iphone"))
            {
                Platform = Platforms.Iphone;
            }
            else if (_userAgentToLower.Contains("mac"))
            {
                Platform = Platforms.Apple;
            }
            else if (_userAgentToLower.Contains("android"))
            {
                Platform = Platforms.Android;
            }
            else if (_userAgentToLower.Contains("linux"))
            {
                Platform = Platforms.Linux;
            }
            else if (_userAgentToLower.Contains("nokia"))
            {
                Platform = Platforms.Nokia;
            }
            else if (_userAgentToLower.Contains("blackberry"))
            {
                Platform = Platforms.BlackBerry;
            }
            else if (_userAgentToLower.Contains("Freebsd"))
            {
                Platform = Platforms.FreeBSD;
            }
            else if (_userAgentToLower.Contains("openbsd"))
            {
                Platform = Platforms.OpenBSD;
            }
            else if (_userAgentToLower.Contains("netbsd"))
            {
                Platform = Platforms.NetBSD;
            }
            else if (_userAgentToLower.Contains("opensolaris"))
            {
                Platform = Platforms.OpenSolaris;
            }
            else if (_userAgentToLower.Contains("sunos"))
            {
                Platform = Platforms.SunOS;
            }
            else if (_userAgentToLower.Contains("os\\//2"))
            {
                Platform = Platforms.OS2;
            }
            else if (_userAgentToLower.Contains("beos"))
            {
                Platform = Platforms.BeOS;
            }
            else if (_userAgentToLower.Contains("win"))
            {
                Platform = Platforms.Windows;
            }
        }

        protected bool CheckBrowsers()
        {
            // well-known, well-used
            // Special Notes:
            // (1) Opera must be checked before FireFox due to the odd
            //     user agents used in some older versions of Opera
            // (2) WebTV is strapped onto Internet Explorer so we must
            //     check for WebTV before IE
            // (3) (deprecated) Galeon is based on Firefox and needs to be
            //     tested before Firefox is tested
            // (4) OmniWeb is based on Safari so OmniWeb check must occur
            //     before Safari
            // (5) Netscape 9+ is based on Firefox so Netscape checks
            //     before FireFox are necessary
            return CheckChromeFrame() ||
                CheckBrowserWebTv() ||
                CheckBrowserInternetExplore() ||
                CheckBrowserOpera() ||
                CheckBrowserGaleon() ||
                CheckBrowserNetscapeNavigator9Plus() ||
                CheckBrowserFireFox() ||
                CheckBrowserEdge() ||
                CheckBrowserChrome() ||
                CheckBrowserOmniWeb() ||
                CheckBrowserAndroid() ||
                CheckBrowseriPad() ||
                CheckBrowseriPod() ||
                CheckBrowseriPhone() ||
                CheckBrowserBlackBerry() ||
                CheckBrowserNokia() ||
                CheckBrowserGoogleBot() ||
                CheckBrowserMSNBot() ||
                CheckBrowserBingBot() ||
                CheckBrowserSlurp() ||
                CheckFacebookExternalHit() ||
                CheckBrowserSafari() ||
                CheckBrowserNetPositive() ||
                CheckBrowserFirebird() ||
                CheckBrowserKonqueror() ||
                CheckBrowserIcab() ||
                CheckBrowserPhoenix() ||
                CheckBrowserAmaya() ||
                CheckBrowserLynx() ||
                CheckBrowserShiretoko() ||
                CheckBrowserIceCat() ||
                CheckBrowserIceweasel() ||
                CheckBrowserW3CValidator() ||
                CheckBrowserMozilla();
        }

        protected bool CheckForAol()
        {
            _isAol = false;
            _aolVersion = Unknown;

            if (_userAgentToLower.Contains("aol"))
            {
                var aversion = _userAgent.Substring(_userAgentToLower.IndexOf("aol")).Split(' ');
                if (aversion.Count() >= 2)
                {
                    _isAol = true;
                    _aolVersion = aversion[1].Replace(@"/[^0-9\.a-z]/i", string.Empty);

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserBlackBerry()
        {
            if (_userAgentToLower.Contains("blackberry"))
            {
                var aresult = _userAgent.Substring(_userAgentToLower.IndexOf("blackberry")).Split('/');
                if (aresult.Count() >= 2)
                {
                    var aversion = aresult[1].Split(' ');
                    Version = aversion[0];
                    BrowserName = Browser.BlackBerry;
                    IsMobile = true;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserGoogleBot()
        {
            if (_userAgentToLower.Contains("googlebot"))
            {
                var aresult = _userAgent.Substring(_userAgentToLower.IndexOf("googlebot")).Split('/');
                if (aresult.Count() >= 2)
                {
                    var aversion = aresult[1].Split(' ');
                    Version = aversion[0].Replace(';', ' ');
                    BrowserName = Browser.GoogleBot;
                    IsRobot = true;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserMSNBot()
        {
            if (_userAgentToLower.Contains("msnbot"))
            {
                var aresult = _userAgent.Substring(_userAgentToLower.IndexOf("msnbot")).Split('/');
                if (aresult.Count() >= 2)
                {
                    var aversion = aresult[1].Split(' ');
                    Version = aversion[0].Replace(';', ' ');
                    BrowserName = Browser.MsnBot;
                    IsRobot = true;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserBingBot()
        {
            if (_userAgentToLower.Contains("bingbot"))
            {
                var aresult = _userAgent.Substring(_userAgentToLower.IndexOf("bingbot")).Split('/');
                if (aresult.Count() >= 2)
                {
                    var aversion = aresult[1].Split(' ');
                    Version = aversion[0].Replace(';', ' ');
                    BrowserName = Browser.BingBot;
                    IsRobot = true;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserW3CValidator()
        {
            if (_userAgentToLower.Contains("w3c-checklink"))
            {
                var aresult = _userAgent.Substring(_userAgentToLower.IndexOf("w3c-checklink")).Split('/');
                if (aresult.Count() >= 2)
                {
                    var version = aresult[1].Split(' ');
                    Version = version[0];
                    BrowserName = Browser.W3cValidation;

                    return true;
                }
            }
            else if (_userAgentToLower.Contains("w3c_validator"))
            {
                // Some of the Validator versions do not delineate w/ a slash - add it back in
                var tempUserAgent = _userAgentToLower.Replace("w3c_validator ", "w3c_validator/");
                var index = tempUserAgent.IndexOf("w3c_validator");
                var aresult = tempUserAgent.Split('/');
                if (aresult.Count() >= 2)
                {
                    var aversion = aresult[1].Split(' ');
                    Version = aversion[0];
                    BrowserName = Browser.W3cValidation;

                    return true;
                }
            }
            else if (_userAgentToLower.Contains("w3c-mobileok"))
            {
                BrowserName = Browser.W3cValidation;
                IsMobile = true;

                return true;
            }

            return false;
        }

        protected bool CheckBrowserSlurp()
        {
            if (_userAgentToLower.Contains("slurp"))
            {
                var slurp = _userAgent.Substring(_userAgentToLower.IndexOf("slurp"));
                var aresult = slurp.Split('/');
                if (aresult.Count() >= 2)
                {
                    var aversion = aresult[1].Split(' ');
                    Version = aversion[0];
                    BrowserName = Browser.Slurp;
                    IsMobile = false;
                    IsRobot = true;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserInternetExplore()
        {
            // Test for IE11
            if (_userAgentToLower.Contains("trident/7.0; rv:11.0"))
            {
                BrowserName = Browser.IE;
                Version = "11.0";

                return true;
            }
            else if (_userAgentToLower.Contains("microsoft internet explorer"))
            {
                // Test for v1 - v1.5 IE
                BrowserName = Browser.IE;
                Version = "1.0";
                var aresult = _userAgentToLower.Substring(_userAgentToLower.IndexOf('/'));
                var regex = new Regex(@"308|425|426|474|0b1");
                var match = regex.Match(aresult);
                if (match.Success)
                {
                    Version = "1.5";
                }

                return true;
            }
            else if (_userAgentToLower.Contains("msie") && !_userAgentToLower.Contains("opera"))
            {
                // Test for versions > 1.5
                // See if the browser is the odd MSN Explorer
                if (_userAgentToLower.Contains("msnb"))
                {
                    var index = _userAgentToLower.Replace(";", "; ").IndexOf("msn");
                    var msn = _userAgentToLower.Substring(index);
                    var aresult = msn.Split(' ');
                    if (aresult.Count() >= 2)
                    {
                        BrowserName = Browser.Msn;
                        Version = aresult[1].Replace('(', ' ').Replace(')', ' ').Replace(';', ' ');

                        return true;
                    }
                }

                var temp = _userAgent.Replace(";", "; ");
                var aresult2 = temp.Substring(temp.IndexOf("MSIE")).Split(' ');
                if (aresult2.Count() >= 2)
                {
                    BrowserName = Browser.IE;
                    Version = aresult2[1].Replace("(", string.Empty).Replace(")", string.Empty).Replace(";", string.Empty);
                    if (_userAgentToLower.Contains("iemobile"))
                    {
                        BrowserName = Browser.PocketIE;
                        IsMobile = true;
                    }

                    return true;
                }
            }
            else if (_userAgentToLower.Contains("trident"))
            {
                // Test for versions > IE 10
                BrowserName = Browser.IE;
                var result = _userAgentToLower.Split(new string[] { "rv:" }, System.StringSplitOptions.None);
                if (result.Count() >= 2)
                {
                    var regex = new Regex(@"[^0-9\.]+");
                    Version = regex.Replace(result[1], string.Empty);
                    _userAgentToLower = _userAgentToLower.Replace("mozilla", "msie").Replace("gecko", "msie");
                    _userAgent = _userAgent.Replace("Mozilla", "MSIE").Replace("Gecko", "MSIE");
                }
            }
            else if (_userAgentToLower.Contains("mspie") || _userAgentToLower.Contains("pocket"))
            {
                // Test for Pocket IE
                var index = _userAgentToLower.IndexOf("mspie") == -1 ? _userAgentToLower.IndexOf("pocket") : _userAgentToLower.IndexOf("mspie");
                var aresult = _userAgent.Substring(index).Split(' ');
                if (aresult.Count() >= 2)
                {
                    Platform = Platforms.WindowsCE;
                    BrowserName = Browser.PocketIE;
                    IsMobile = true;

                    if (_userAgentToLower.Contains("mspie"))
                    {
                        Version = aresult[1];
                    }
                    else
                    {
                        var aversion = _userAgentToLower.Split('/');
                        if (aversion.Count() >= 2)
                        {
                            Version = aversion[1];
                        }
                    }
                }
            }

            return false;
        }

        protected bool CheckBrowserOpera()
        {
            if (_userAgentToLower.Contains("opera mini"))
            {
                var resultant = _userAgent.Substring(_userAgentToLower.IndexOf("opera mini"));
                var regex = new Regex(@"/");
                var match = regex.Match(resultant);
                if (match.Success)
                {
                    var aresult = resultant.Split('/');
                    if (aresult.Count() >= 2)
                    {
                        var aversion = aresult[1].Split(' ');
                        Version = aversion[0];
                    }
                }
                else
                {
                    var aversion = resultant.Substring(resultant.IndexOf("Opera Mini")).Split(' ');
                    if (aversion.Count() >= 2)
                    {
                        Version = aversion[1];
                    }
                }

                BrowserName = Browser.OperaMini;
                IsMobile = true;

                return true;
            }
            else if (_userAgentToLower.Contains("opera"))
            {
                var resultant = _userAgent.Substring(_userAgentToLower.IndexOf("opera"));
                var regex = new Regex(@"Version/(1\d.[\d]+)");
                var match = regex.Match(resultant);
                if (match.Success)
                {
                    Version = match.Groups[1].Value;
                }
                else
                {
                    regex = new Regex(@"/");
                    match = regex.Match(resultant);
                    if (match.Success)
                    {
                        var aresult = resultant.Replace("(", string.Empty).Split('/');
                        if (aresult.Count() >= 2)
                        {
                            var aversion = aresult[1].Split(' ');
                            Version = aversion[0];
                        }
                    }
                    else
                    {
                        var aversion = resultant.Substring(resultant.IndexOf("Opera")).Split(' ');
                        Version = aversion.Count() >= 2 ? aversion[1] : string.Empty;
                    }
                }

                if (_userAgentToLower.Contains("opera mobi"))
                {
                    IsMobile = true;
                }

                BrowserName = Browser.Opera;

                return true;
            }
            else if (_userAgentToLower.Contains("opr"))
            {
                var resultant = _userAgent.Substring(_userAgentToLower.IndexOf("opr"));
                var regex = new Regex(@"/");
                var match = regex.Match(resultant);
                if (match.Success)
                {
                    var aresult = resultant.Replace("(", " ").Split('/');
                    if (aresult.Count() >= 2)
                    {
                        var aversion = aresult[1].Split(' ');
                        Version = aversion[0];
                    }
                }

                if (_userAgentToLower.Contains("mobile"))
                {
                    IsMobile = true;
                }

                BrowserName = Browser.Opera;

                return true;
            }

            return false;
        }

        protected bool CheckBrowserChrome()
        {
            if (_userAgentToLower.Contains("chrome"))
            {
                var aresult = _userAgent.Substring(_userAgentToLower.IndexOf("chrome")).Split('/');
                if (aresult.Count() >= 2)
                {
                    var aversion = aresult[1].Split(' ');
                    Version = aversion[0];
                    BrowserName = Browser.Chrome;

                    // Chrome on Android
                    if (_userAgentToLower.Contains("android"))
                    {
                        if (_userAgentToLower.Contains("mobile"))
                        {
                            IsMobile = true;
                        }
                        else
                        {
                            IsTablet = true;
                        }
                    }

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserWebTv()
        {
            if (_userAgentToLower.Contains("webtv"))
            {
                var aresult = _userAgent.Substring(_userAgentToLower.IndexOf("webtv")).Split('/');
                if (aresult.Count() >= 2)
                {
                    var aversion = aresult[1].Split(' ');
                    Version = aversion[0];
                    BrowserName = Browser.WebTv;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserNetPositive()
        {
            if (_userAgentToLower.Contains("netpositive"))
            {
                var aresult = _userAgent.Substring(_userAgentToLower.IndexOf("netpositive")).Split('/');
                if (aresult.Count() >= 2)
                {
                    var aversion = aresult[1].Split(' ');
                    Version = aversion[0].Replace("(", string.Empty).Replace(")", string.Empty).Replace(";", string.Empty);
                    BrowserName = Browser.NetPositive;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserGaleon()
        {
            if (_userAgentToLower.Contains("galeon"))
            {
                var aresult = _userAgent.Substring(_userAgentToLower.IndexOf("galeon")).Split(' ');
                var aversion = aresult[0].Split('/');
                if (aversion.Count() >= 2)
                {
                    Version = aversion[1];
                    BrowserName = Browser.Galeon;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserKonqueror()
        {
            if (_userAgentToLower.Contains("konqueror"))
            {
                var aresult = _userAgent.Substring(_userAgentToLower.IndexOf("konqueror")).Split('/');
                var aversion = aresult[0].Split('/');
                if (aversion.Count() >= 2)
                {
                    Version = aversion[1];
                    BrowserName = Browser.Konqueror;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserIcab()
        {
            if (_userAgentToLower.Contains("icab"))
            {
                var tempUserAgent = _userAgentToLower.Replace('/', ' ');
                var aversion = tempUserAgent.Substring(tempUserAgent.IndexOf("icab")).Split(' ');
                if (aversion.Count() >= 2)
                {
                    Version = aversion[1];
                    BrowserName = Browser.Icab;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserOmniWeb()
        {
            if (_userAgentToLower.Contains("omniweb"))
            {
                var aresult = _userAgent.Substring(_userAgentToLower.IndexOf("omniweb")).Split('/');
                var averion = (aresult.Count() >= 2 ? aresult[1] : string.Empty).Split(' ');
                Version = averion[0];
                BrowserName = Browser.OmniWeb;

                return true;
            }

            return false;
        }

        protected bool CheckBrowserPhoenix()
        {
            if (_userAgentToLower.Contains("phoenix"))
            {
                var aversion = _userAgent.Substring(_userAgentToLower.IndexOf("phoenix")).Split('/');
                if (aversion.Count() >= 2)
                {
                    Version = aversion[1];
                    BrowserName = Browser.Phoenix;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserFirebird()
        {
            if (_userAgentToLower.Contains("firebird"))
            {
                var aversion = _userAgent.Substring(_userAgentToLower.IndexOf("firebird")).Split('/');
                if (aversion.Count() >= 2)
                {
                    Version = aversion[1];
                    BrowserName = Browser.Firebird;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserNetscapeNavigator9Plus()
        {
            if (_userAgentToLower.Contains("firefox"))
            {
                var regex = new Regex(@"navigator/([^\s]+)");
                var match = regex.Match(_userAgentToLower);
                if (match.Success)
                {
                    Version = match.Groups[1].Value;
                    BrowserName = Browser.NetscapeNavigator;

                    return true;
                }
            }
            else
            {
                var regex = new Regex(@"netscape6/([^\s]+)");
                var match = regex.Match(_userAgentToLower);
                if (match.Success)
                {
                    Version = match.Groups[1].Value;
                    BrowserName = Browser.NetscapeNavigator;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserShiretoko()
        {
            if (_userAgentToLower.Contains("mozilla"))
            {
                var regex = new Regex(@"shiretoko/([^\s]+)");
                var match = regex.Match(_userAgentToLower);
                if (match.Success)
                {
                    Version = match.Groups[1].Value;
                    BrowserName = Browser.Shiretoko;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserIceCat()
        {
            if (_userAgentToLower.Contains("mozilla"))
            {
                var regex = new Regex(@"ececat/([^\s]+)");
                var match = regex.Match(_userAgentToLower);
                if (match.Success)
                {
                    Version = match.Groups[1].Value;
                    BrowserName = Browser.IceCat;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserNokia()
        {
            var regex = new Regex(@"nokia([^/]+)/([0-9\.]+)");
            var match = regex.Match(_userAgentToLower);
            if (match.Success)
            {
                Version = match.Groups[2].Value;
                if (_userAgentToLower.Contains("serias60") || _userAgentToLower.Contains("s60"))
                {
                    BrowserName = Browser.NokiaS60;
                }
                else
                {
                    BrowserName = Browser.Nokia;
                }

                IsMobile = true;

                return true;
            }

            return false;
        }

        protected bool CheckBrowserFireFox()
        {
            if (!_userAgentToLower.Contains("safari"))
            {
                var regex = new Regex(@"Firefox/([0-9a-zA-Z\.]+)");
                var match = regex.Match(_userAgent);
                if (match.Success)
                {
                    Version = match.Groups[1].Value;
                    BrowserName = Browser.Firefox;

                    // FF on Android
                    if (_userAgentToLower.Contains("android"))
                    {
                        if (_userAgentToLower.Contains("mobile"))
                        {
                            IsMobile = true;
                        }
                        else
                        {
                            IsTablet = true;
                        }
                    }

                    return true;
                }

                regex = new Regex(@"firefox/");
                match = regex.Match(_userAgentToLower);
                if (match.Success)
                {
                    Version = string.Empty;
                    BrowserName = Browser.Firefox;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserIceweasel()
        {
            if (_userAgentToLower.Contains("iceweasel"))
            {
                var aresult = _userAgent.Substring(_userAgentToLower.IndexOf("iceweasel")).Split('/');
                if (aresult.Count() >= 2)
                {
                    var aversion = aresult[1].Split(' ');
                    Version = aversion[0];
                    BrowserName = Browser.Iceweasel;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserMozilla()
        {
            if (_userAgentToLower.Contains("mozilla") && !_userAgentToLower.Contains("netscape"))
            {
                var regex = new Regex(@"rv:[0-9].[0-9a-b]");
                var match = regex.Match(_userAgentToLower);
                if (match.Success)
                {
                    var aversion = _userAgent.Substring(_userAgentToLower.IndexOf("rv:")).Split(' ');
                    regex = new Regex(@"rv:[0-9].[0-9a-b]");
                    match = regex.Match(_userAgentToLower);
                    if (match.Success)
                    {
                        Version = match.Groups[0].Value.Replace("rv:", string.Empty);
                        BrowserName = Browser.Mozilla;

                        return true;
                    }
                }

                regex = new Regex(@"rv:[0-9].[0-9]");
                match = regex.Match(_userAgentToLower);
                if (match.Success)
                {
                    var aversion = _userAgent.Substring(_userAgentToLower.IndexOf("rv:")).Split(' ');
                    Version = aversion[0].Replace("rv:", string.Empty);
                    BrowserName = Browser.Mozilla;

                    return true;
                }

                regex = new Regex(@"Mozilla/([^\s]+)");
                match = regex.Match(_userAgent);
                if (match.Success)
                {
                    Version = match.Groups[1].Value;
                    BrowserName = Browser.Mozilla;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserLynx()
        {
            if (_userAgentToLower.Contains("lynx"))
            {
                var aresult = _userAgent.Substring(_userAgentToLower.IndexOf("lynx")).Split('/');
                var aversion = (aresult.Count() >= 2 ? aresult[1] : string.Empty).Split(' ');
                Version = aversion[0];
                BrowserName = Browser.Lynx;

                return true;
            }

            return false;
        }

        protected bool CheckBrowserAmaya()
        {
            if (_userAgentToLower.Contains("amaya"))
            {
                var aresult = _userAgent.Substring(_userAgentToLower.IndexOf("amaya")).Split('/');
                if (aresult.Count() >= 2)
                {
                    var aversion = aresult[1].Split(' ');
                    Version = aversion[0];
                    BrowserName = Browser.Amaya;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserSafari()
        {
            if (_userAgentToLower.Contains("safari") &&
                !_userAgentToLower.Contains("iphone") &&
                !_userAgentToLower.Contains("ipod"))
            {
                Version = Unknown;
                var index = _userAgentToLower.IndexOf("version");
                if (index >= 0)
                {
                    var aresult = _userAgent.Substring(index).Split('/');
                    if (aresult.Count() >= 2)
                    {
                        var aversion = aresult[1].Split(' ');
                        Version = aversion[0];
                    }
                }

                BrowserName = Browser.Safari;

                return true;
            }

            return false;
        }

        protected bool CheckFacebookExternalHit()
        {
            if (_userAgentToLower.Contains("facebookexternalhit"))
            {
                IsRobot = true;
                IsFacebook = true;

                return true;
            }

            return false;
        }

        protected bool CheckFacebookIos()
        {
            if (_userAgentToLower.Contains("fbios"))
            {
                IsFacebook = true;

                return true;
            }

            return false;
        }

        protected bool GetSafariOnIos()
        {
            if (_userAgentToLower.Contains("version"))
            {
                var aresult = _userAgent.Substring(_userAgentToLower.IndexOf("version")).Split('/');
                if (aresult.Count() >= 2)
                {
                    var aversion = aresult[1].Split(' ');
                    BrowserName = Browser.Safari;
                    Version = aversion[0];

                    return true;
                }
            }

            return false;
        }

        protected bool GetChromeOnIos()
        {
            if (_userAgentToLower.Contains("crios"))
            {
                var aresult = _userAgent.Substring(_userAgentToLower.IndexOf("crios")).Split('/');
                if (aresult.Count() >= 2)
                {
                    var aversion = aresult[1].Split(' ');
                    Version = aversion[0];
                    BrowserName = Browser.Chrome;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowseriPhone()
        {
            if (_userAgentToLower.Contains("iphone"))
            {
                Version = Unknown;
                BrowserName = Browser.Iphone;
                GetSafariOnIos();
                GetChromeOnIos();
                CheckFacebookIos();
                IsMobile = true;

                return true;
            }

            return false;
        }

        protected bool CheckBrowseriPad()
        {
            if (_userAgentToLower.Contains("ipad"))
            {
                Version = Unknown;
                BrowserName = Browser.Ipad;
                GetSafariOnIos();
                GetChromeOnIos();
                CheckFacebookIos();
                IsTablet = true;

                return true;
            }

            return false;
        }

        protected bool CheckBrowseriPod()
        {
            if (_userAgentToLower.Contains("ipod"))
            {
                Version = Unknown;
                BrowserName = Browser.Ipod;
                GetSafariOnIos();
                GetChromeOnIos();
                CheckFacebookIos();
                IsMobile = true;

                return true;
            }

            return false;
        }

        protected bool CheckBrowserAndroid()
        {
            if (_userAgentToLower.Contains("android"))
            {
                var aresult = _userAgent.Substring(_userAgentToLower.IndexOf("android")).Split(' ');
                if (aresult.Count() >= 2)
                {
                    var aversion = aresult[1].Split(' ');
                    Version = aversion[0];
                }
                else
                {
                    Version = Unknown;
                }

                if (_userAgentToLower.Contains("mobile"))
                {
                    IsMobile = true;
                }
                else
                {
                    IsTablet = true;
                }

                BrowserName = Browser.Android;

                return true;
            }

            return false;
        }

        protected bool CheckBrowserEdge()
        {
            if (_userAgentToLower.Contains("edge"))
            {
                var aresult = _userAgent.Substring(_userAgentToLower.IndexOf("edge")).Split('/');
                if (aresult.Count() >= 2)
                {
                    var aversion = aresult[1].Split(' ');

                    Version = aversion[0];
                    BrowserName = Browser.Edge;

                    if (_userAgentToLower.Contains("android"))
                    {
                        if (_userAgentToLower.Contains("mobile"))
                        {
                            IsMobile = true;
                        }
                        else
                        {
                            IsTablet = true;
                        }
                    }

                    return true;
                }
            }

            return false;
        }

        protected bool CheckChromeFrame()
        {
            if (_userAgentToLower.Contains("chromeframe"))
            {
                _isChromeFrame = true;
            }

            return false;
        }
    }
}
