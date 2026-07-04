using System.Text.RegularExpressions;

namespace TaxIntake.Services
{
    public static partial class ServiceOperation
    {

        [GeneratedRegex(@"\s+")]
        private static partial Regex RegexWhitespace();
        public static string RemoveWhitespace(string input)
        {
            return RegexWhitespace().Replace(input, "");
        }

        #region SIN

        [GeneratedRegex(@"^\s*(?:\d\s*){9}$")]
        private static partial Regex RegexUserSINAsValid();
        private static void SINOperationMove(Span<char> span, ReadOnlySpan<char> state)
        {
            state[..3].CopyTo(span[..3]);
            span[3] = ' ';
            state[3..6].CopyTo(span[4..7]);
            span[7] = ' ';
            state[6..].CopyTo(span[8..]);
        }

        // This method formats a SIN to the format XXX XXX XXX, if it is valid
        public static string? FormatSIN(string? input)
        {
            if (input is null)
                return input;
            if (!RegexUserSINAsValid().IsMatch(input))
                return input;

            string s_1 = RemoveWhitespace(input);
            ReadOnlySpan<char> s_2 = s_1.AsSpan();

            return string.Create(11, s_2, SINOperationMove);
        }

        #endregion

        #region date of birth

        private const string _pattern_DOB_1 = @"^(?:Jan(?:uary)?|Feb(?:ruary)?|Mar(?:ch)?" +
            @"|Apr(?:il)?|May|Jun(?:e)?|Jul(?:y)?|Aug(?:ust)?|Sep(?:tember)?" +
            @"|Oct(?:ober)?|Nov(?:ember)?|Dec(?:ember)?)\.?\s+(?:\d{1,2}),?\s*(?:\d{4})$";
        [GeneratedRegex(_pattern_DOB_1, RegexOptions.IgnoreCase)]
        private static partial Regex RegexUserDOBAcceptable_1();
        [GeneratedRegex(@"^(?<year>\d{4})[ -/]?(?<month>\d{2})[ -/]?(?<day>\d{2})$")]
        private static partial Regex RegexUserDOBAcceptable_2();
        public static string? FormatDOB(string? input)
        {
            if (input is null)
                return input;

            bool m_1 = RegexUserDOBAcceptable_1().IsMatch(input);
            if (m_1)
            {
                bool b_date_1 = DateOnly.TryParse(input, out DateOnly date);
                if (b_date_1)
                {
                    return date.ToString("yyyy-MM-dd");
                }
            }
            Match m_2 = RegexUserDOBAcceptable_2().Match(input);
            if (m_2.Success)
            {
                string s_year = m_2.Groups["year"].Value;
                string s_month = m_2.Groups["month"].Value;
                string s_day = m_2.Groups["day"].Value;
                bool b_date_2 = DateOnly.TryParse($"{s_year}-{s_month}-{s_day}", out DateOnly date);
                if (b_date_2)
                {
                    return date.ToString("yyyy-MM-dd");
                }
            }
            return input;
        }
        #endregion

        #region postal code

        [GeneratedRegex(@"^\s*(?<first>[A-Za-z]\d[A-Za-z])[ -]?(?<second>\d[A-Za-z]\d)\s*$")]
        private static partial Regex RegexUserPostalCodeAsValid();
        private static void PostalCodeOperationMove(Span<char> span, Match state)
        {
            ReadOnlySpan<char> firstSpan = state.Groups["first"].ValueSpan;
            ReadOnlySpan<char> secondSpan = state.Groups["second"].ValueSpan;
            firstSpan.ToUpperInvariant(span[..3]);
            span[3] = ' ';
            secondSpan.ToUpperInvariant(span[4..]);
        }
        public static string? FormatPostalCode(string? input)
        {
            if (input is null)
                return input;

            Match m = RegexUserPostalCodeAsValid().Match(input);
            return m.Success ? string.Create(7, m, PostalCodeOperationMove) : input;
        }

        #endregion
    }
}
