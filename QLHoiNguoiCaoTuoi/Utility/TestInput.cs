using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QLHoiNguoiCaoTuoi.Utility
{
    public static class TestInput
    {
        /// <summary>
        /// Test string input if it null or empty or only whitespace
        /// </summary>
        /// <param name="input">test string</param>
        /// <returns>True if string input is null or empty or only whitespace</returns>
        public static bool StringIsNullEmptyWhiteSpace(string input)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
            {
                return true;
            }
            return false;
        }

        public static bool StringIsEmail(string input)
        {
            var regex = @"\w+@\w+\.\w+";

            var match = Regex.Match(input, regex, RegexOptions.IgnoreCase);

            if (match.Success)
            {
                return true;
            }

            return false;
        }

    }
}
