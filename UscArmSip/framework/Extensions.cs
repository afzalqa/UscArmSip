using FluentAssertions;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RestSharp;
using SeleniumExtras.WaitHelpers;
using System.Text.RegularExpressions;

namespace UscArmSip
{
    public static class Extensions
    {
        public static void IsPresent(this IWebElement element)
        {
            if (element is null)
            {
                throw new NoSuchElementException($"Expected element to be present, but it's not");
            }
        }

        public static void IsNotPresent(this IWebElement element)
        {
            if (element is not null)
            {
                throw new NoSuchElementException($"Expected element to be NOT present, but it is");
            }
        }

        public static string Color(this IWebElement element)
        {
            return element.GetCssValue("color");
        }

        public static string BackgroundColor(this IWebElement element)
        {
            return element.GetCssValue("background-color");
        }

        public static IWebElement WaitForElementBeforeGettingIt(this IWebDriver driver, By by, int timeoutInSeconds = 5)
        {
            Thread.Sleep(400);
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds)).Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
            return driver.FindElement(by);
        }

        public static IWebElement WaitForValidationElementToBeFilledWithText(this IWebDriver driver, By by, int timeoutInSeconds = 2)
        {
            Thread.Sleep(700);
            return WaitForElementBeforeGettingIt(driver, by, timeoutInSeconds);
        }

        public static string GetText(this IWebElement element)
        {
            var innerText = element.GetAttribute("innerText");
            return string.IsNullOrEmpty(innerText) ? element.GetAttribute("value") ?? element.Text : innerText;
        }

        public static string ConvertDoubleSpacesToSingles(this string sentence)
        {
            return Regex.Replace(sentence, @"[ ]{2,}", " ").Trim();
        }

        public static void SendText(this IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public static string RemoveSpaces(this string loginWithSpace)
        {
            return Regex.Replace(loginWithSpace, @"\s+", "");
        }

        public static string AddRandomDoubleSpaces(this string s)
        {
            string result = default;

            for (var i = 0; i <= s.Length - 1; i++)
            {
                var replaceWithSpace = Help.GetBoolean();

                if (
                    replaceWithSpace
                    || i == 0 
                    || i == 1
                    || i == s.Length - 1
                    || i == s.Length - 2)
                {
                    result += " ";
                }
                else if (!replaceWithSpace)
                {
                    result += s[i];
                }
            }

            return result;
        }

        public static string AddTrailingSpace(this string s)
        {
            return s + " ";
        }

        public static void UscPortal(this INavigation navigation)
        {
            navigation.GoToUrl("https://" + "test.eskso.ru");
        }

        public static void UscCabinet(this INavigation navigation)
        {
            navigation.GoToUrl("https://" + "test-lk.eskso.ru");
        }

        public static void UscArmSip(this INavigation navigation)
        {
            navigation.GoToUrl("http://" + "eskso2.sapfir.corp:17155");
        }

        public static void NewTab(this IWebDriver driver)
        {
            driver.SwitchTo().NewWindow(WindowType.Tab);
        }

        public static void SelectTab(this IWebDriver driver, int tab)
        {
            driver.SwitchTo().Window(driver.WindowHandles[tab]);
        }

        public static void CloseTab(this IWebDriver driver)
        {
            driver.Close();
        }

        public static void DoubleClick(this IWebElement element)
        {
            element.Click();
            element.Click();
        }

        public static string FormatAsPhone(this string phone)
        {
            return Regex.Replace("+7" + phone, @"^(..)(...)(...)(..)(..)$", "$1 ($2) $3-$4-$5");
        }

        public static string FormatAsSnils(this string snils)
        {
            return Regex.Replace(snils, @"^(...)(...)(...)(..)$", "$1-$2-$3 $4");
        }

        public static string FormatAsCardNumber(this string snils)
        {
            return Regex.Replace(snils, @"^(....)(....)(....)(....)$", "$1 $2 $3 $4");
        }

        public static bool Marked(this IWebElement element)
        {
            return Convert.ToBoolean(element.GetAttribute("aria-checked"));
        }

        public static bool Disabled(this IWebElement element)
        {
            return Convert.ToBoolean(element.GetAttribute("aria-disabled"));
        }

        public static dynamic Deserealize(this RestResponse response)
        {
            return JsonConvert.DeserializeObject<dynamic>(response.Content);
        }

        public static RestRequest AddParameters(this RestRequest restRequest, List<(string, string)> parameters)
        {
            foreach (var parameter in parameters)
            {
                restRequest.AddParameter(parameter.Item1, parameter.Item2);
            }

            return restRequest;
        }

        public static void AssertValidation(this IWebElement element, string text)
        {
            element.GetText().Should().Be(text);
            element.Color().Should().Be(Colors.ValidationRed);
        }
    }
}