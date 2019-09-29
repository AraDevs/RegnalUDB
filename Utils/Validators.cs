
using System.Text.RegularExpressions;


namespace RegnalUDB.Utils
{
    static class Validators
    {
        public static bool isNumber(string value)
        {
            return Regex.Match(value, RegularExpression.isNumber).Success;
        }
    }
}
