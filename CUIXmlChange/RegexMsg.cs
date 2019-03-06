using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CUIXmlChange
{
    class RegexMsg
    {
        private static string INIPartten = @"\/i\s[\\\s\[\]\(\)\.\#\=\-\+\*\!\@\`\~\%\$\&\^\:0-9a-zA-Z_]*INI";
        private static string XmlPartten = @"\/o\s[\\\s\[\]\(\)\.\#\=\-\+\*\!\@\`\~\%\$\&\^\:0-9a-zA-Z_]*xml";
        private static string ExitPartten = @"[\s]*\/q[\s]*";

        public static string INIRegex(string msg)
        {
            Regex regex = new Regex(INIPartten, RegexOptions.IgnoreCase);
            MatchCollection m = regex.Matches(msg);

            if (m.Count == 1)
                return m[0].ToString();
            else
                return "";
        }

        public static string XmlRegex(string msg)
        {
            Regex regex = new Regex(XmlPartten, RegexOptions.IgnoreCase);
            MatchCollection m = regex.Matches(msg);

            if (m.Count == 1)
                return m[0].ToString();
            else
                return "";
        }

        public static bool ExitRegex(string msg)
        {
            Regex regex = new Regex(ExitPartten, RegexOptions.IgnoreCase);
            MatchCollection m = regex.Matches(msg);

            if (m.Count == 1)
                return true;
            else
                return false;
        }
    }
}
