namespace BrowserNET.IntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;
    using NUnit.Framework;

    [TestFixture]
    public class UserAgentTests
    {
        [Test]
        public void TestWithACollectionData()
        {
            var error = string.Empty;

            // Arrange
            var expectedUserAgents = GetExpectedOutput();

            // Act
            foreach (var expectedAgent in expectedUserAgents)
            {
                var userAgentNet = new UserAgentParser(expectedAgent.RawUserAgent);
                userAgentNet.Determine();

                // Assert
                if (expectedAgent.Browser != userAgentNet.BrowserName ||
                    expectedAgent.AolVersion != userAgentNet.AolVersion ||
                    expectedAgent.IsAol != userAgentNet.IsAol ||
                    expectedAgent.IsFacebook != userAgentNet.IsFacebook ||
                    expectedAgent.IsMobile != userAgentNet.IsMobile ||
                    expectedAgent.IsRobot != userAgentNet.IsRobot ||
                    expectedAgent.IsTablet != userAgentNet.IsTablet ||
                    expectedAgent.Platform != userAgentNet.Platform ||
                    expectedAgent.Version != userAgentNet.Version)
                {
                    error += expectedAgent.Browser + "--" + expectedAgent.Version + "-------" + userAgentNet.BrowserName + "--" + userAgentNet.Version + "-------" + expectedAgent.RawUserAgent + Environment.NewLine;
                }

                Assert.AreEqual(expectedAgent.Browser, userAgentNet.BrowserName);
                Assert.AreEqual(expectedAgent.Version, userAgentNet.Version);
                Assert.AreEqual(expectedAgent.AolVersion, userAgentNet.AolVersion);
                Assert.AreEqual(expectedAgent.IsAol, userAgentNet.IsAol);
                Assert.AreEqual(expectedAgent.IsChromeFrame, userAgentNet.IsChromeFrame);
                Assert.AreEqual(expectedAgent.IsFacebook, userAgentNet.IsFacebook);
                Assert.AreEqual(expectedAgent.IsMobile, userAgentNet.IsMobile);
                Assert.AreEqual(expectedAgent.IsRobot, userAgentNet.IsRobot);
                Assert.AreEqual(expectedAgent.IsTablet, userAgentNet.IsTablet);
                Assert.AreEqual(expectedAgent.Platform, userAgentNet.Platform);
            }

            File.WriteAllText(@"error.txt", error);
        }

        private List<ExpectedUserAgent> GetExpectedOutput()
        {
            string error = string.Empty;
            var lines = File.ReadAllLines(@"useragent.json");
            var result = new List<ExpectedUserAgent>();
            for (var i = 0; i < lines.Count(); i++)
            {
                try
                {
                    result.Add(JsonConvert.DeserializeObject<ExpectedUserAgent>(lines[i]));
                }
                catch
                {
                    error += i + Environment.NewLine;
                }
            }

            File.WriteAllText(@"parse.txt", error);

            return result;
        }
    }
}
