using Microsoft.AspNetCore.Html;

namespace [Application Name].Models
{
    public class Patterns
    {
        public static HtmlString Password(int MinLength = 8)
        {
            string Pattern = "(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^\\da-zA-Z])(?!.*\\s).{" + MinLength.ToString() + ",}";
            return new HtmlString(Pattern);  
        }
        public static HtmlString Email()
        {
            string Pattern = "^[^ ]+@[^ ]+\\.[a-z]{2,6}$";
            return new HtmlString(Pattern);
        }
        public static HtmlString Date()
        {
            string DateFormat = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
            return Date(DateFormat);
        }
        public static HtmlString Date(string ShortDatePattern)
        {
            string Pattern = "";
            string[] DatePart = ShortDatePattern.Split("/");
            for (int i = 0; i < 3; i++)
            {
                switch (DatePart[i].ToUpper().Substring(0, 1))
                {
                    case "D":
                        if (Pattern != "") Pattern = Pattern + "\\" + "/";
                        Pattern = Pattern + "(0[1-9]|[12][0-9]|3[01])";
                        break;
                    case "M":
                        if (Pattern != "") Pattern = Pattern + "\\" + "/";
                        Pattern = Pattern + "(0[1-9]|1[0,1,2])";
                        break;
                    case "Y":
                        if (Pattern != "") Pattern = Pattern + "\\" + "/";
                        Pattern = Pattern + "(19|20)\\d{2}";
                        break;
                }
            }
            return new HtmlString(Pattern);
        }
        public static HtmlString DatePlaceHolder()
        {
            return DatePlaceHolder(System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern);
        }
        public static HtmlString DatePlaceHolder(string ShortDatePattern)
        {
          return  new HtmlString(ShortDatePattern.ToLower());   
        }
        public static HtmlString Integer(bool signed)
        {
           if (signed) return new HtmlString("^[+-]?\\d+$");
           return new HtmlString("^\\d+$");
        }
        public static HtmlString IntegerPlaceHolder() { return new HtmlString("12345"); }
        public static HtmlString Decimal(int NumberOfDecimal, bool signed)
        {
           return Decimal(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator, NumberOfDecimal, signed);
        }
        public static HtmlString Decimal(string CurrencyDecimalSeparator, int NumberOfDecimal, bool signed)
        {
            string pattern;
            if (signed) pattern = "^[+-]?\\d*(\\" + CurrencyDecimalSeparator + "\\d{0," + NumberOfDecimal.ToString() + "})?$";
            else pattern = "^\\d*(\\" + CurrencyDecimalSeparator + "\\d{0," + NumberOfDecimal.ToString() + "})?$";
            return new HtmlString(pattern);
        }
        public static HtmlString DecimalPlaceHolder(int NumberOfDecimal, bool signed)
        {
            return DecimalPlaceHolder(System.Globalization.CultureInfo.CurrentUICulture.NumberFormat.CurrencyDecimalSeparator,
                                      NumberOfDecimal,
                                      signed);
        }
        public static HtmlString DecimalPlaceHolder(string CurrencyDecimalSeparator, int NumberOfDecimal, bool signed)
        {
            return new HtmlString((signed == true?"(+/-)":"") + "123" + CurrencyDecimalSeparator + new string('0', NumberOfDecimal));
        }
        public static HtmlString Text(int MinLength = 0, bool SpaceAllowed = true)
        {
            string Pattern = ".{" + MinLength.ToString() + ",}";
            if (!SpaceAllowed) Pattern = "(?!.*\\s)" + Pattern;
            return new HtmlString(Pattern);
        }
    }
}
