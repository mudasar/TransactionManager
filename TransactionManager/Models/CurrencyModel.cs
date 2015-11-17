using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace TransactionManager.Models
{
    public static class CurrencyModel
    {
        private static List<Currency> _currencies;

        static CurrencyModel()
        {
            _currencies = new List<Currency>
            {
                new Currency {Code = "AED", Name = " United Arab Emirates dirham", SkCode = "20000"},
new Currency {Code = "AFN", Name = " Afghani", SkCode = "20001"},
new Currency {Code = "ALL", Name = " Lek", SkCode = "20002"},
new Currency {Code = "AMD", Name = " Armenian Dram", SkCode = "20003"},
new Currency {Code = "ANG", Name = " Netherlands Antillian Guilder", SkCode = "20004"},
new Currency {Code = "AOA", Name = " Kwanza", SkCode = "20005"},
new Currency {Code = "ARS", Name = " Argentine Peso", SkCode = "20006"},
new Currency {Code = "AUD", Name = " Australian Dollar", SkCode = "20007"},
new Currency {Code = "AWG", Name = " Aruban Guilder", SkCode = "20008"},
new Currency {Code = "AZN", Name = " Azerbaijanian Manat", SkCode = "20009"},
new Currency {Code = "BAM", Name = " Convertible Marks", SkCode = "20010"},
new Currency {Code = "BBD", Name = " Barbados Dollar", SkCode = "20011"},
new Currency {Code = "BDT", Name = " Bangladeshi Taka", SkCode = "20012"},
new Currency {Code = "BGN", Name = " Bulgarian Lev", SkCode = "20013"},
new Currency {Code = "BHD", Name = " Bahraini Dinar", SkCode = "20014"},
new Currency {Code = "BIF", Name = " Burundian Franc", SkCode = "20015"},
new Currency {Code = "BMD", Name = " Bermudian Dollar", SkCode = "20016"},
new Currency {Code = "BND", Name = " Brunei Dollar", SkCode = "20017"},
new Currency {Code = "BOB", Name = " Boliviano", SkCode = "20018"},
new Currency {Code = "BOV", Name = " Bolivian Mvdol", SkCode = "20019"},
new Currency {Code = "BRL", Name = " Brazilian Real", SkCode = "20020"},
new Currency {Code = "BSD", Name = " Bahamian Dollar", SkCode = "20021"},
new Currency {Code = "BTN", Name = " Ngultrum", SkCode = "20022"},
new Currency {Code = "BWP", Name = " Pula", SkCode = "20023"},
new Currency {Code = "BYR", Name = " Belarussian Ruble", SkCode = "20024"},
new Currency {Code = "BZD", Name = " Belize Dollar", SkCode = "20025"},
new Currency {Code = "CAD", Name = " Canadian Dollar", SkCode = "20026"},
new Currency {Code = "CDF", Name = " Franc Congolais", SkCode = "20027"},
new Currency {Code = "CHE", Name = " WIR Euro", SkCode = "20028"},
new Currency {Code = "CHF", Name = " Swiss Franc", SkCode = "20029"},
new Currency {Code = "CHW", Name = " WIR Franc", SkCode = "20030"},
new Currency {Code = "CLF", Name = " Unidades de formento", SkCode = "20031"},
new Currency {Code = "CLP", Name = " Chilean Peso", SkCode = "20032"},
new Currency {Code = "CNY", Name = " Yuan Renminbi", SkCode = "20033"},
new Currency {Code = "COP", Name = " Colombian Peso", SkCode = "20034"},
new Currency {Code = "COU", Name = " Unidad de Valor Real", SkCode = "20035"},
new Currency {Code = "CRC", Name = " Costa Rican Colon", SkCode = "20036"},
new Currency {Code = "CUP", Name = " Cuban Peso", SkCode = "20037"},
new Currency {Code = "CVE", Name = " Cape Verde Escudo", SkCode = "20038"},
new Currency {Code = "CYP", Name = " Cyprus Pound", SkCode = "20039"},
new Currency {Code = "CZK", Name = " Czech Koruna", SkCode = "20040"},
new Currency {Code = "DJF", Name = " Djibouti Franc", SkCode = "20041"},
new Currency {Code = "DKK", Name = " Danish Krone", SkCode = "20042"},
new Currency {Code = "DOP", Name = " Dominican Peso", SkCode = "20043"},
new Currency {Code = "DZD", Name = " Algerian Dinar", SkCode = "20044"},
new Currency {Code = "EEK", Name = " Kroon", SkCode = "20045"},
new Currency {Code = "EGP", Name = " Egyptian Pound", SkCode = "20046"},
new Currency {Code = "ERN", Name = " Nakfa", SkCode = "20047"},
new Currency {Code = "ETB", Name = " Ethiopian Birr", SkCode = "20048"},
new Currency {Code = "EUR", Name = " Euro", SkCode = "20049"},
new Currency {Code = "FJD", Name = " Fiji Dollar", SkCode = "20050"},
new Currency {Code = "FKP", Name = " Falkland Islands Pound", SkCode = "20051"},
new Currency {Code = "GBP", Name = " Pound Sterling", SkCode = "20052"},
new Currency {Code = "GEL", Name = " Lari", SkCode = "20053"},
new Currency {Code = "GHS", Name = " Cedi", SkCode = "20054"},
new Currency {Code = "GIP", Name = " Gibraltar pound", SkCode = "20055"},
new Currency {Code = "GMD", Name = " Dalasi", SkCode = "20056"},
new Currency {Code = "GNF", Name = " Guinea Franc", SkCode = "20057"},
new Currency {Code = "GTQ", Name = " Quetzal", SkCode = "20058"},
new Currency {Code = "GYD", Name = " Guyana Dollar", SkCode = "20059"},
new Currency {Code = "HKD", Name = " Hong Kong Dollar", SkCode = "20060"},
new Currency {Code = "HNL", Name = " Lempira", SkCode = "20061"},
new Currency {Code = "HRK", Name = " Croatian Kuna", SkCode = "20062"},
new Currency {Code = "HTG", Name = " Haiti Gourde", SkCode = "20063"},
new Currency {Code = "HUF", Name = " Forint", SkCode = "20064"},
new Currency {Code = "IDR", Name = " Rupiah", SkCode = "20065"},
new Currency {Code = "ILS", Name = " New Israeli Shekel", SkCode = "20066"},
new Currency {Code = "INR", Name = " Indian Rupee", SkCode = "20067"},
new Currency {Code = "IQD", Name = " Iraqi Dinar", SkCode = "20068"},
new Currency {Code = "IRR", Name = " Iranian Rial", SkCode = "20069"},
new Currency {Code = "ISK", Name = " Iceland Krona", SkCode = "20070"},
new Currency {Code = "JMD", Name = " Jamaican Dollar", SkCode = "20071"},
new Currency {Code = "JOD", Name = " Jordanian Dinar", SkCode = "20072"},
new Currency {Code = "JPY", Name = " Japanese yen", SkCode = "20073"},
new Currency {Code = "KES", Name = " Kenyan Shilling", SkCode = "20074"},
new Currency {Code = "KGS", Name = " Som", SkCode = "20075"},
new Currency {Code = "KHR", Name = " Riel", SkCode = "20076"},
new Currency {Code = "KMF", Name = " Comoro Franc", SkCode = "20077"},
new Currency {Code = "KPW", Name = " North Korean Won", SkCode = "20078"},
new Currency {Code = "KRW", Name = " South Korean Won", SkCode = "20079"},
new Currency {Code = "KWD", Name = " Kuwaiti Dinar", SkCode = "20080"},
new Currency {Code = "KYD", Name = " Cayman Islands Dollar", SkCode = "20081"},
new Currency {Code = "KZT", Name = " Tenge", SkCode = "20082"},
new Currency {Code = "LAK", Name = " Kip", SkCode = "20083"},
new Currency {Code = "LBP", Name = " Lebanese Pound", SkCode = "20084"},
new Currency {Code = "LKR", Name = " Sri Lanka Rupee", SkCode = "20085"},
new Currency {Code = "LRD", Name = " Liberian Dollar", SkCode = "20086"},
new Currency {Code = "LSL", Name = " Loti", SkCode = "20087"},
new Currency {Code = "LTL", Name = " Lithuanian Litas", SkCode = "20088"},
new Currency {Code = "LVL", Name = " Latvian Lats", SkCode = "20089"},
new Currency {Code = "LYD", Name = " Libyan Dinar", SkCode = "20090"},
new Currency {Code = "MAD", Name = " Moroccan Dirham", SkCode = "20091"},
new Currency {Code = "MDL", Name = " Moldovan Leu", SkCode = "20092"},
new Currency {Code = "MGA", Name = " Malagasy Ariary", SkCode = "20093"},
new Currency {Code = "MKD", Name = " Denar", SkCode = "20094"},
new Currency {Code = "MMK", Name = " Kyat", SkCode = "20095"},
new Currency {Code = "MNT", Name = " Tugrik", SkCode = "20096"},
new Currency {Code = "MOP", Name = " Pataca", SkCode = "20097"},
new Currency {Code = "MRO", Name = " Ouguiya", SkCode = "20098"},
new Currency {Code = "MTL", Name = " Maltese Lira", SkCode = "20099"},
new Currency {Code = "MUR", Name = " Mauritius Rupee", SkCode = "20100"},
new Currency {Code = "MVR", Name = " Rufiyaa", SkCode = "20101"},
new Currency {Code = "MWK", Name = " Kwacha", SkCode = "20102"},
new Currency {Code = "MXN", Name = " Mexican Peso", SkCode = "20103"},
new Currency {Code = "MXV", Name = " Mexican Unidad de Inversion (UDI)", SkCode = "20104"},
new Currency {Code = "MYR", Name = " Malaysian Ringgit", SkCode = "20105"},
new Currency {Code = "MZN", Name = " Metical", SkCode = "20106"},
new Currency {Code = "NAD", Name = " Namibian Dollar", SkCode = "20107"},
new Currency {Code = "NGN", Name = " Naira", SkCode = "20108"},
new Currency {Code = "NIO", Name = " Cordoba Oro", SkCode = "20109"},
new Currency {Code = "NOK", Name = " Norwegian Krone", SkCode = "20110"},
new Currency {Code = "NPR", Name = " Nepalese Rupee", SkCode = "20111"},
new Currency {Code = "NZD", Name = " New Zealand Dollar", SkCode = "20112"},
new Currency {Code = "OMR", Name = " Rial Omani", SkCode = "20113"},
new Currency {Code = "PAB", Name = " Balboa", SkCode = "20114"},
new Currency {Code = "PEN", Name = " Nuevo Sol", SkCode = "20115"},
new Currency {Code = "PGK", Name = " Kina", SkCode = "20116"},
new Currency {Code = "PHP", Name = " Philippine Peso", SkCode = "20117"},
new Currency {Code = "PKR", Name = " Pakistan Rupee", SkCode = "20118"},
new Currency {Code = "PLN", Name = " Zloty", SkCode = "20119"},
new Currency {Code = "PYG", Name = " Guarani", SkCode = "20120"},
new Currency {Code = "QAR", Name = " Qatari Rial", SkCode = "20121"},
new Currency {Code = "RON", Name = " Romanian New Leu", SkCode = "20122"},
new Currency {Code = "RSD", Name = " Serbian Dinar", SkCode = "20123"},
new Currency {Code = "RUB", Name = " Russian Ruble", SkCode = "20124"},
new Currency {Code = "RWF", Name = " Rwanda Franc", SkCode = "20125"},
new Currency {Code = "SAR", Name = " Saudi Riyal", SkCode = "20126"},
new Currency {Code = "SBD", Name = " Solomon Islands Dollar", SkCode = "20127"},
new Currency {Code = "SCR", Name = " Seychelles Rupee", SkCode = "20128"},
new Currency {Code = "SDG", Name = " Sudanese Pound", SkCode = "20129"},
new Currency {Code = "SEK", Name = " Swedish Krona", SkCode = "20130"},
new Currency {Code = "SGD", Name = " Singapore Dollar", SkCode = "20131"},
new Currency {Code = "SHP", Name = " Saint Helena Pound", SkCode = "20132"},
new Currency {Code = "SKK", Name = " Slovak Koruna", SkCode = "20133"},
new Currency {Code = "SLL", Name = " Leone", SkCode = "20134"},
new Currency {Code = "SOS", Name = " Somali Shilling", SkCode = "20135"},
new Currency {Code = "SRD", Name = " Surinam Dollar", SkCode = "20136"},
new Currency {Code = "STD", Name = " Dobra", SkCode = "20137"},
new Currency {Code = "SYP", Name = " Syrian Pound", SkCode = "20138"},
new Currency {Code = "SZL", Name = " Lilangeni", SkCode = "20139"},
new Currency {Code = "THB", Name = " Baht", SkCode = "20140"},
new Currency {Code = "TJS", Name = " Somoni", SkCode = "20141"},
new Currency {Code = "TMM", Name = " Manat", SkCode = "20142"},
new Currency {Code = "TND", Name = " Tunisian Dinar", SkCode = "20143"},
new Currency {Code = "TOP", Name = " Pa'anga", SkCode = "20144"},
new Currency {Code = "TRY", Name = " New Turkish Lira", SkCode = "20145"},
new Currency {Code = "TTD", Name = " Trinidad and Tobago Dollar", SkCode = "20146"},
new Currency {Code = "TWD", Name = " New Taiwan Dollar", SkCode = "20147"},
new Currency {Code = "TZS", Name = " Tanzanian Shilling", SkCode = "20148"},
new Currency {Code = "UAH", Name = " Hryvnia", SkCode = "20149"},
new Currency {Code = "UGX", Name = " Uganda Shilling", SkCode = "20150"},
new Currency {Code = "USD", Name = " US Dollar", SkCode = "20151"},
new Currency {Code = "XAF", Name = " CFA Franc BEAC", SkCode = "20152"},
new Currency {Code = "XAG", Name = " Silver (one troy ounce)", SkCode = "20153"},
new Currency {Code = "XAU", Name = " Gold (one troy ounce)", SkCode = "20154"},
new Currency {Code = "XCD", Name = " East Carribean Dollar", SkCode = "20155"},
new Currency {Code = "XPT", Name = " Palladium (one troy ounce)", SkCode = "20156"},
new Currency {Code = "XXX", Name = " No Currency", SkCode = "20157"}

            };
        }

        public static bool ValidateCurrencyCode(string code)
        {
            return _currencies.Any(x => x.Code == code);
        }

        public static string GetCurrencyName(string code)
        {
            return _currencies.FirstOrDefault(x => x.Code == code).Name;
        }
    }

    public class Currency
    {
        public string Code { get; set; }
        public string SkCode { get; set; }
        public string Name { get; set; }

    }
}