namespace Browser.NET
{
    using System.Linq;
    using System.Text.RegularExpressions;

    public class UserAgent
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
        private string _aolVersion;
        private string _platform;

        public UserAgent(string userAgent)
        {
            this._userAgent = userAgent;
            this._userAgentToLower = userAgent.ToLower();
            this.BrowserName = Browser.Unknown;
            this.Version = Unknown;
            this.Platform = Platforms.Unknown;
            this.AolVersion = Unknown;
            this.IsMobile = false;
            this.IsRobot = false;
            this.IsTablet = false;
            this.IsFacebook = false;
            this.IsAol = false;
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

        public bool IsChromeFrame()
        {
            return this._userAgentToLower.Contains("chromeframe");
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
                this.Platform = Platforms.Windows;
            }
            else if (_userAgentToLower.Contains("ipad"))
            {
                this.Platform = Platforms.Ipad;
            }
            else if (_userAgentToLower.Contains("ipod"))
            {
                this.Platform = Platforms.Ipod;
            }
            else if (_userAgentToLower.Contains("iphone"))
            {
                this.Platform = Platforms.Iphone;
            }
            else if (_userAgentToLower.Contains("mac"))
            {
                this.Platform = Platforms.Apple;
            }
            else if (_userAgentToLower.Contains("android"))
            {
                this.Platform = Platforms.Android;
            }
            else if (_userAgentToLower.Contains("linux"))
            {
                this.Platform = Platforms.Linux;
            }
            else if (_userAgentToLower.Contains("nokia"))
            {
                this.Platform = Platforms.Nokia;
            }
            else if (_userAgentToLower.Contains("blackberry"))
            {
                this.Platform = Platforms.BlackBerry;
            }
            else if (_userAgentToLower.Contains("Freebsd"))
            {
                this.Platform = Platforms.FreeBSD;
            }
            else if (_userAgentToLower.Contains("openbsd"))
            {
                this.Platform = Platforms.OpenBSD;
            }
            else if (_userAgentToLower.Contains("netbsd"))
            {
                this.Platform = Platforms.NetBSD;
            }
            else if (_userAgentToLower.Contains("opensolaris"))
            {
                this.Platform = Platforms.OpenSolaris;
            }
            else if (_userAgentToLower.Contains("sunos"))
            {
                this.Platform = Platforms.SunOS;
            }
            else if (_userAgentToLower.Contains("os\\//2"))
            {
                this.Platform = Platforms.OS2;
            }
            else if (_userAgentToLower.Contains("beos"))
            {
                this.Platform = Platforms.BeOS;
            }
            else if (_userAgentToLower.Contains("win"))
            {
                this.Platform = Platforms.Windows;
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
            return this.CheckBrowserWebTv() ||
                this.CheckBrowserInternetExplore() ||
                this.CheckBrowserOpera() ||
                this.CheckBrowserGaleon() ||
                this.CheckBrowserNetscapeNavigator9Plus() ||
                this.CheckBrowserFireFox() ||
                this.CheckBrowserChrome() ||
                this.CheckBrowserOmniWeb() ||
                this.CheckBrowserAndroid() ||
                this.CheckBrowseriPad() ||
                this.CheckBrowseriPod() ||
                this.CheckBrowseriPhone() ||
                this.CheckBrowserBlackBerry() ||
                this.CheckBrowserNokia() ||
                this.CheckBrowserGoogleBot() ||
                this.CheckBrowserMSNBot() ||
                this.CheckBrowserBingBot() ||
                this.CheckBrowserSlurp() ||
                this.CheckFacebookExternalHit() ||
                this.CheckBrowserSafari() ||
                this.CheckBrowserNetPositive() ||
                this.CheckBrowserFirebird() ||
                this.CheckBrowserKonqueror() ||
                this.CheckBrowserIcab() ||
                this.CheckBrowserPhoenix() ||
                this.CheckBrowserAmaya() ||
                this.CheckBrowserLynx() ||
                this.CheckBrowserShiretoko() ||
                this.CheckBrowserIceCat() ||
                this.CheckBrowserIceweasel() ||
                this.CheckBrowserW3CValidator() ||
                this.CheckBrowserMozilla();
        }

        protected bool CheckBrowserBlackBerry()
        {
            if (_userAgentToLower.Contains("blackberry"))
            {
                var aresult = this._userAgent.Substring(this._userAgentToLower.IndexOf("blackberry")).Split('/');
                if (aresult.Count() >= 2)
                {
                    var aversion = aresult[1].Split(' ');
                    this.Version = aversion[0];
                    this.BrowserName = Browser.BlackBerry;
                    this.IsMobile = true;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserGoogleBot()
        {
            if (_userAgentToLower.Contains("googlebot"))
            {
                var aresult = this._userAgent.Substring(this._userAgentToLower.IndexOf("googlebot")).Split('/');
                if (aresult.Count() >= 2)
                {
                    var aversion = aresult[1].Split(' ');
                    this.Version = aversion[0].Replace(';', ' ');
                    this.BrowserName = Browser.GoogleBot;
                    this.IsRobot = true;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserMSNBot()
        {
            if (_userAgentToLower.Contains("msnbot"))
            {
                var aresult = this._userAgent.Substring(this._userAgentToLower.IndexOf("msnbot")).Split('/');
                if (aresult.Count() >= 2)
                {
                    var aversion = aresult[1].Split(' ');
                    this.Version = aversion[0].Replace(';', ' ');
                    this.BrowserName = Browser.MsnBot;
                    this.IsRobot = true;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserBingBot()
        {
            if (_userAgentToLower.Contains("bingbot"))
            {
                var aresult = this._userAgent.Substring(this._userAgentToLower.IndexOf("bingbot")).Split('/');
                if (aresult.Count() >= 2)
                {
                    var aversion = aresult[1].Split(' ');
                    this.Version = aversion[0].Replace(';', ' ');
                    this.BrowserName = Browser.BingBot;
                    this.IsRobot = true;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserW3CValidator()
        {
            if (this._userAgentToLower.Contains("w3c-checklink"))
            {
                var aresult = this._userAgent.Substring(this._userAgentToLower.IndexOf("w3c-checklink")).Split('/');
                if (aresult.Count() >= 2)
                {
                    var version = aresult[1].Split(' ');
                    this.Version = version[0];
                    this.BrowserName = Browser.W3cValidation;

                    return true;
                }
            }
            else if (this._userAgentToLower.Contains("w3c_validator"))
            {
                // Some of the Validator versions do not delineate w/ a slash - add it back in
                var tempUserAgent = this._userAgentToLower.Replace("w3c_validator ", "w3c_validator/");
                var index = tempUserAgent.IndexOf("w3c_validator");
                var aresult = tempUserAgent.Split('/');
                if (aresult.Count() >= 2)
                {
                    var aversion = aresult[1].Split(' ');
                    this.Version = aversion[0];
                    this.BrowserName = Browser.W3cValidation;

                    return true;
                }
            }
            else if (this._userAgentToLower.Contains("w3c-mobileok"))
            {
                this.BrowserName = Browser.W3cValidation;
                this.IsMobile = true;

                return true;
            }

            return false;
        }

        protected bool CheckBrowserSlurp()
        {
            if (this._userAgentToLower.Contains("slurp"))
            {
                var slurp = this._userAgent.Substring(this._userAgentToLower.IndexOf("slurp"));
                var aresult = slurp.Split('/');
                if (aresult.Count() >= 2)
                {
                    var aversion = aresult[1].Split(' ');
                    this.Version = aversion[0];
                    this.BrowserName = Browser.Slurp;
                    this.IsMobile = false;
                    this.IsRobot = true;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserInternetExplore()
        {
            // Test for IE11
            if (this._userAgentToLower.Contains("trident/7.0; rv:11.0"))
            {
                this.BrowserName = Browser.IE;
                this.Version = "11.0";

                return true;
            }
            else if (this._userAgentToLower.Contains("microsoft internet explorer"))
            {
                // Test for v1 - v1.5 IE
                this.BrowserName = Browser.IE;
                this.Version = "1.0";
                var aresult = this._userAgentToLower.Substring(this._userAgentToLower.IndexOf('/'));
                var regex = new Regex(@"308|425|426|474|0b1");
                var match = regex.Match(aresult);
                if (match.Success)
                {
                    this.Version = "1.5";
                }

                return true;
            }
            else if (this._userAgentToLower.Contains("msie") && !this._userAgentToLower.Contains("opera"))
            {
                // Test for versions > 1.5
                // See if the browser is the odd MSN Explorer
                if (this._userAgentToLower.Contains("msnb"))
                {
                    var index = this._userAgentToLower.Replace(";", "; ").IndexOf("msn");
                    var msn = this._userAgentToLower.Substring(index);
                    var aresult = msn.Split(' ');
                    if (aresult.Count() >= 2)
                    {
                        this.BrowserName = Browser.Msn;
                        this.Version = aresult[1].Replace('(', ' ').Replace(')', ' ').Replace(';', ' ');

                        return true;
                    }
                }

                var temp = this._userAgent.Replace(";", "; ");
                var aresult2 = temp.Substring(temp.IndexOf("MSIE")).Split(' ');
                if (aresult2.Count() >= 2)
                {
                    this.BrowserName = Browser.IE;
                    this.Version = aresult2[1].Replace("(", string.Empty).Replace(")", string.Empty).Replace(";", string.Empty);
                    if (this._userAgentToLower.Contains("iemobile"))
                    {
                        this.BrowserName = Browser.PocketIE;
                        this.IsMobile = true;
                    }

                    return true;
                }
            }
            else if (this._userAgentToLower.Contains("trident"))
            {
                // Test for versions > IE 10
                this.BrowserName = Browser.IE;
                var result = this._userAgentToLower.Split(new string[] { "rv:" }, System.StringSplitOptions.None);
                if (result.Count() >= 2)
                {
                    var regex = new Regex(@"[^0-9\.]+");
                    this.Version = regex.Replace(result[1], string.Empty);
                    this._userAgentToLower = this._userAgentToLower.Replace("mozilla", "msie").Replace("gecko", "msie");
                    this._userAgent = this._userAgent.Replace("Mozilla", "MSIE").Replace("Gecko", "MSIE");
                }
            }
            else if (this._userAgentToLower.Contains("mspie") || this._userAgentToLower.Contains("pocket"))
            {
                // Test for Pocket IE
                var index = this._userAgentToLower.IndexOf("mspie") == -1 ? this._userAgentToLower.IndexOf("pocket") : this._userAgentToLower.IndexOf("mspie");
                var aresult = this._userAgent.Substring(index).Split(' ');
                if (aresult.Count() >= 2)
                {
                    this.Platform = Platforms.WindowsCE;
                    this.BrowserName = Browser.PocketIE;
                    this.IsMobile = true;

                    if (this._userAgentToLower.Contains("mspie"))
                    {
                        this.Version = aresult[1];
                    }
                    else
                    {
                        var aversion = this._userAgentToLower.Split('/');
                        if (aversion.Count() >= 2)
                        {
                            this.Version = aversion[1];
                        }
                    }
                }
            }

            return false;
        }

        protected bool CheckBrowserOpera()
        {
            if (this._userAgentToLower.Contains("opera mini"))
            {
                var resultant = this._userAgent.Substring(this._userAgentToLower.IndexOf("opera mini"));
                var regex = new Regex(@"/");
                var match = regex.Match(resultant);
                if (match.Success)
                {
                    var aresult = resultant.Split('/');
                    if (aresult.Count() >= 2)
                    {
                        var aversion = aresult[1].Split(' ');
                        this.Version = aversion[0];
                    }
                }
                else
                {
                    var aversion = resultant.Substring(resultant.IndexOf("Opera Mini")).Split(' ');
                    if (aversion.Count() >= 2)
                    {
                        this.Version = aversion[1];
                    }
                }

                this.BrowserName = Browser.OperaMini;
                this.IsMobile = true;

                return true;
            }
            else if (this._userAgentToLower.Contains("opera"))
            {
                var resultant = this._userAgent.Substring(this._userAgentToLower.IndexOf("opera"));
                var regex = new Regex(@"Version/(1\d.[\d]+)");
                var match = regex.Match(resultant);
                if (match.Success)
                {
                    this.Version = match.Groups[1].Value;
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
                            this.Version = aversion[0];
                        }
                    }
                    else
                    {
                        var aversion = resultant.Substring(resultant.IndexOf("Opera")).Split(' ');
                        this.Version = aversion.Count() >= 2 ? aversion[1] : string.Empty;
                    }
                }

                if (this._userAgentToLower.Contains("opera mobi"))
                {
                    this.IsMobile = true;
                }

                this.BrowserName = Browser.Opera;

                return true;
            }
            else if (this._userAgentToLower.Contains("opr"))
            {
                var resultant = this._userAgent.Substring(this._userAgentToLower.IndexOf("opr"));
                var regex = new Regex(@"/");
                var match = regex.Match(resultant);
                if (match.Success)
                {
                    var aresult = resultant.Replace("(", " ").Split('/');
                    if (aresult.Count() >= 2)
                    {
                        var aversion = aresult[1].Split(' ');
                        this.Version = aversion[0];
                    }
                }

                if (this._userAgentToLower.Contains("mobile"))
                {
                    this.IsMobile = true;
                }

                this.BrowserName = Browser.Opera;

                return true;
            }

            return false;
        }

        protected bool CheckBrowserChrome()
        {
            if (this._userAgentToLower.Contains("chrome"))
            {
                var aresult = this._userAgent.Substring(this._userAgentToLower.IndexOf("chrome")).Split('/');
                if (aresult.Count() >= 2)
                {
                    var aversion = aresult[1].Split(' ');
                    this.Version = aversion[0];
                    this.BrowserName = Browser.Chrome;

                    // Chrome on Android
                    if (this._userAgentToLower.Contains("android"))
                    {
                        if (this._userAgentToLower.Contains("mobile"))
                        {
                            this.IsMobile = true;
                        }
                        else
                        {
                            this.IsTablet = true;
                        }
                    }

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserWebTv()
        {
            if (this._userAgentToLower.Contains("webtv"))
            {
                var aresult = this._userAgent.Substring(this._userAgentToLower.IndexOf("webtv")).Split('/');
                if (aresult.Count() >= 2)
                {
                    var aversion = aresult[1].Split(' ');
                    this.Version = aversion[0];
                    this.BrowserName = Browser.WebTv;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserNetPositive()
        {
            if (this._userAgentToLower.Contains("netpositive"))
            {
                var aresult = this._userAgent.Substring(this._userAgentToLower.IndexOf("netpositive")).Split('/');
                if (aresult.Count() >= 2)
                {
                    var aversion = aresult[1].Split(' ');
                    this.Version = aversion[0].Replace("(", string.Empty).Replace(")", string.Empty).Replace(";", string.Empty);
                    this.BrowserName = Browser.NetPositive;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserGaleon()
        {
            if (this._userAgentToLower.Contains("galeon"))
            {
                var aresult = this._userAgent.Substring(this._userAgentToLower.IndexOf("galeon")).Split(' ');
                var aversion = aresult[0].Split('/');
                if (aversion.Count() >= 2)
                {
                    this.Version = aversion[1];
                    this.BrowserName = Browser.Galeon;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserKonqueror()
        {
            if (this._userAgentToLower.Contains("konqueror"))
            {
                var aresult = this._userAgent.Substring(this._userAgentToLower.IndexOf("konqueror")).Split('/');
                var aversion = aresult[0].Split('/');
                if (aversion.Count() >= 2)
                {
                    this.Version = aversion[1];
                    this.BrowserName = Browser.Konqueror;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserIcab()
        {
            if (this._userAgentToLower.Contains("icab"))
            {
                var tempUserAgent = this._userAgentToLower.Replace('/', ' ');
                var aversion = tempUserAgent.Substring(tempUserAgent.IndexOf("icab")).Split(' ');
                if (aversion.Count() >= 2)
                {
                    this.Version = aversion[1];
                    this.BrowserName = Browser.Icab;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserOmniWeb()
        {
            if (this._userAgentToLower.Contains("omniweb"))
            {
                var aresult = this._userAgent.Substring(this._userAgentToLower.IndexOf("omniweb")).Split('/');
                var averion = (aresult.Count() >= 2 ? aresult[1] : string.Empty).Split(' ');
                this.Version = averion[0];
                this.BrowserName = Browser.OmniWeb;

                return true;
            }

            return false;
        }

        protected bool CheckBrowserPhoenix()
        {
            if (this._userAgentToLower.Contains("phoenix"))
            {
                var aversion = this._userAgent.Substring(this._userAgentToLower.IndexOf("phoenix")).Split('/');
                if (aversion.Count() >= 2)
                {
                    this.Version = aversion[1];
                    this.BrowserName = Browser.Phoenix;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserFirebird()
        {
            if (this._userAgentToLower.Contains("firebird"))
            {
                var aversion = this._userAgent.Substring(this._userAgentToLower.IndexOf("firebird")).Split('/');
                if (aversion.Count() >= 2)
                {
                    this.Version = aversion[1];
                    this.BrowserName = Browser.Firebird;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserNetscapeNavigator9Plus()
        {
            if (this._userAgentToLower.Contains("firefox"))
            {
                var regex = new Regex(@"navigator/([^\s]+)");
                var match = regex.Match(this._userAgentToLower);
                if (match.Success)
                {
                    this.Version = match.Groups[1].Value;
                    this.BrowserName = Browser.NetscapeNavigator;

                    return true;
                }
            }
            else
            {
                var regex = new Regex(@"netscape6/([^\s]+)");
                var match = regex.Match(this._userAgentToLower);
                if (match.Success)
                {
                    this.Version = match.Groups[1].Value;
                    this.BrowserName = Browser.NetscapeNavigator;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserShiretoko()
        {
            if (this._userAgentToLower.Contains("mozilla"))
            {
                var regex = new Regex(@"shiretoko/([^\s]+)");
                var match = regex.Match(this._userAgentToLower);
                if (match.Success)
                {
                    this.Version = match.Groups[1].Value;
                    this.BrowserName = Browser.Shiretoko;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserIceCat()
        {
            if (this._userAgentToLower.Contains("mozilla"))
            {
                var regex = new Regex(@"ececat/([^\s]+)");
                var match = regex.Match(this._userAgentToLower);
                if (match.Success)
                {
                    this.Version = match.Groups[1].Value;
                    this.BrowserName = Browser.IceCat;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserNokia()
        {
            var regex = new Regex(@"nokia([^/]+)/([0-9\.]+)");
            var match = regex.Match(this._userAgentToLower);
            if (match.Success)
            {
                this.Version = match.Groups[2].Value;
                if (this._userAgentToLower.Contains("serias60") || this._userAgentToLower.Contains("s60"))
                {
                    this.BrowserName = Browser.NokiaS60;
                }
                else
                {
                    this.BrowserName = Browser.Nokia;
                }

                this.IsMobile = true;

                return true;
            }

            return false;
        }

        protected bool CheckBrowserFireFox()
        {
            if (!this._userAgentToLower.Contains("safari"))
            {
                var regex = new Regex(@"Firefox/([0-9a-zA-Z\.]+)");
                var match = regex.Match(this._userAgent);
                if (match.Success)
                {
                    this.Version = match.Groups[1].Value;
                    this.BrowserName = Browser.Firefox;

                    // FF on Android
                    if (this._userAgentToLower.Contains("android"))
                    {
                        if (this._userAgentToLower.Contains("mobile"))
                        {
                            this.IsMobile = true;
                        }
                        else
                        {
                            this.IsTablet = true;
                        }
                    }

                    return true;
                }

                regex = new Regex(@"firefox/");
                match = regex.Match(this._userAgentToLower);
                if (match.Success)
                {
                    this.Version = string.Empty;
                    this.BrowserName = Browser.Firefox;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserIceweasel()
        {
            if (this._userAgentToLower.Contains("iceweasel"))
            {
                var aresult = this._userAgent.Substring(this._userAgentToLower.IndexOf("iceweasel")).Split('/');
                if (aresult.Count() >= 2)
                {
                    var aversion = aresult[1].Split(' ');
                    this.Version = aversion[0];
                    this.BrowserName = Browser.Iceweasel;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserMozilla()
        {
            if (this._userAgentToLower.Contains("mozilla") && !this._userAgentToLower.Contains("netscape"))
            {
                var regex = new Regex(@"rv:[0-9].[0-9a-b]");
                var match = regex.Match(this._userAgentToLower);
                if (match.Success)
                {
                    var aversion = this._userAgent.Substring(this._userAgentToLower.IndexOf("rv:")).Split(' ');
                    regex = new Regex(@"rv:[0-9].[0-9a-b]");
                    match = regex.Match(this._userAgentToLower);
                    if (match.Success)
                    {
                        this.Version = match.Groups[0].Value.Replace("rv:", string.Empty);
                        this.BrowserName = Browser.Mozilla;

                        return true;
                    }
                }

                regex = new Regex(@"rv:[0-9].[0-9]");
                match = regex.Match(this._userAgentToLower);
                if (match.Success)
                {
                    var aversion = this._userAgent.Substring(this._userAgentToLower.IndexOf("rv:")).Split(' ');
                    this.Version = aversion[0].Replace("rv:", string.Empty);
                    this.BrowserName = Browser.Mozilla;

                    return true;
                }

                regex = new Regex(@"Mozilla/([^\s]+)");
                match = regex.Match(this._userAgent);
                if (match.Success)
                {
                    this.Version = match.Groups[1].Value;
                    this.BrowserName = Browser.Mozilla;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserLynx()
        {
            if (this._userAgentToLower.Contains("lynx"))
            {
                var aresult = this._userAgent.Substring(this._userAgentToLower.IndexOf("lynx")).Split('/');
                var aversion = (aresult.Count() >= 2 ? aresult[1] : string.Empty).Split(' ');
                this.Version = aversion[0];
                this.BrowserName = Browser.Lynx;

                return true;
            }

            return false;
        }

        protected bool CheckBrowserAmaya()
        {
            if (this._userAgentToLower.Contains("amaya"))
            {
                var aresult = this._userAgent.Substring(this._userAgentToLower.IndexOf("amaya")).Split('/');
                if (aresult.Count() >= 2)
                {
                    var aversion = aresult[1].Split(' ');
                    this.Version = aversion[0];
                    this.BrowserName = Browser.Amaya;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowserSafari()
        {
            if (this._userAgentToLower.Contains("safari") &&
                !this._userAgentToLower.Contains("iphone") &&
                !this._userAgentToLower.Contains("ipod"))
            {
                this.Version = Unknown;
                var index = this._userAgentToLower.IndexOf("version");
                if (index >= 0)
                {
                    var aresult = this._userAgent.Substring(index).Split('/');
                    if (aresult.Count() >= 2)
                    {
                        var aversion = aresult[1].Split(' ');
                        this.Version = aversion[0];
                    }
                }

                this.BrowserName = Browser.Safari;

                return true;
            }

            return false;
        }

        protected bool CheckFacebookExternalHit()
        {
            if (this._userAgentToLower.Contains("facebookexternalhit"))
            {
                this.IsRobot = true;
                this.IsFacebook = true;

                return true;
            }

            return false;
        }

        protected bool CheckFacebookIos()
        {
            if (this._userAgentToLower.Contains("fbios"))
            {
                this.IsFacebook = true;

                return true;
            }

            return false;
        }

        protected bool GetSafariVersionOnIos()
        {
            if (this._userAgentToLower.Contains("version"))
            {
                var aresult = this._userAgent.Substring(this._userAgentToLower.IndexOf("version")).Split('/');
                if (aresult.Count() >= 2)
                {
                    var aversion = aresult[1].Split(' ');
                    this.Version = aversion[0];

                    return true;
                }
            }

            return false;
        }

        protected bool GetChromeVersionOnIos()
        {
            if (this._userAgentToLower.Contains("crios"))
            {
                var aresult = this._userAgent.Substring(this._userAgentToLower.IndexOf("crios")).Split('/');
                if (aresult.Count() >= 2)
                {
                    var aversion = aresult[1].Split(' ');
                    this.Version = aversion[0];
                    this.BrowserName = Browser.Chrome;

                    return true;
                }
            }

            return false;
        }

        protected bool CheckBrowseriPhone()
        {
            if (this._userAgentToLower.Contains("iphone"))
            {
                this.Version = Unknown;
                this.BrowserName = Browser.Iphone;
                this.GetSafariVersionOnIos();
                this.GetChromeVersionOnIos();
                this.CheckFacebookIos();
                this.IsMobile = true;

                return true;
            }

            return false;
        }

        protected bool CheckBrowseriPad()
        {
            if (this._userAgentToLower.Contains("ipad"))
            {
                this.Version = Unknown;
                this.BrowserName = Browser.Ipad;
                this.GetSafariVersionOnIos();
                this.GetChromeVersionOnIos();
                this.CheckFacebookIos();
                this.IsTablet = true;

                return true;
            }

            return false;
        }

        protected bool CheckBrowseriPod()
        {
            if (this._userAgentToLower.Contains("ipod"))
            {
                this.Version = Unknown;
                this.BrowserName = Browser.Ipod;
                this.GetSafariVersionOnIos();
                this.GetChromeVersionOnIos();
                this.CheckFacebookIos();
                this.IsMobile = true;

                return true;
            }

            return false;
        }

        protected bool CheckBrowserAndroid()
        {
            if (this._userAgentToLower.Contains("android"))
            {
                var aresult = this._userAgent.Substring(this._userAgentToLower.IndexOf("android")).Split(' ');
                if (aresult.Count() >= 2)
                {
                    var aversion = aresult[1].Split(' ');
                    this.Version = aversion[0];
                }
                else
                {
                    this.Version = Unknown;
                }

                if (this._userAgentToLower.Contains("mobile"))
                {
                    this.IsMobile = true;
                }
                else
                {
                    this.IsTablet = true;
                }

                this.BrowserName = Browser.Android;

                return true;
            }

            return false;
        }

        protected bool CheckForAol()
        {
            this._isAol = false;
            this._aolVersion = Unknown;

            if (this._userAgentToLower.Contains("aol"))
            {
                var aversion = this._userAgent.Substring(this._userAgentToLower.IndexOf("aol")).Split(' ');
                if (aversion.Count() >= 2)
                {
                    this._isAol = true;
                    this._aolVersion = aversion[1].Replace(@"/[^0-9\.a-z]/i", string.Empty);

                    return true;
                }
            }

            return false;
        }
    }
}
