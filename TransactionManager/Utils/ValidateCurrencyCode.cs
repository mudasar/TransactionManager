using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace TransactionManager.Utils
{
    public static class ValidateCurrencyCode
    {

        /// <summary>  
        /// Method used to return a currency symbol.  
        /// It receive as a parameter a currency code (3 digits).  
        /// </summary>  
        /// <param name="code">3 digits code. Samples GBP, BRL, USD, etc.</param>  
        public static bool ValidateCurrencySymbol(string code)
        {
            return (from culture in System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.InstalledWin32Cultures)
                    where culture.Name.Length > 0 && !culture.IsNeutralCulture
                    let region = new System.Globalization.RegionInfo(culture.LCID)
                    where String.Equals(region.ISOCurrencySymbol, code, StringComparison.InvariantCultureIgnoreCase)
                    select region).Any();
        }
    }
}