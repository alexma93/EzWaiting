using System;
using System.Reflection;
using System.Diagnostics;
using System.Resources;
using System.Threading;
using System.Globalization;
using Xamarin.Forms;

namespace ezWaiting
{
    public class L10n
    {
        public static void SetLocale()
        {
            DependencyService.Get<ILocalize>().SetLocale();
        }

        /// <remarks>
        /// Maybe we can cache this info rather than querying every time
        /// </remarks>
        public static string Locale()
        {
            return DependencyService.Get<ILocalize>().GetCurrent();
        }

        public static string Localize(string key)
        {
            var netLanguage = Locale();
            // Platform-specific

            //This should be the right code but doesn't work, so I'll make a trick
            ResourceManager temp = new ResourceManager("ezWaiting.Resx.AppResources", typeof(L10n).GetTypeInfo().Assembly);
            string result = temp.GetString(key, new CultureInfo(netLanguage));
            return result;

            //Debug.WriteLine("Localize " + key + " Lingua: " + netLanguage);

            //string resVal = EnTranslation.ResourceManager.GetString(key);
            //Console.Write(resVal);

            //return "Logout";
        }
    }
}

