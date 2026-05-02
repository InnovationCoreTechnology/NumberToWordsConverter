namespace NumberToWords.Web.Constants
{
    public static class NumberWordConstants
    {
        /// <summary>
        /// Numbers from 0 - 9
        /// </summary>
        public static readonly string[] Units =
        {
            "",
            "ONE",
            "TWO",
            "THREE",
            "FOUR",
            "FIVE",
            "SIX",
            "SEVEN",
            "EIGHT",
            "NINE"
        };

        /// <summary>
        /// Numbers from 10 - 19
        /// </summary>
        public static readonly string[] Teens =
        {
            "TEN",
            "ELEVEN",
            "TWELVE",
            "THIRTEEN",
            "FOURTEEN",
            "FIFTEEN",
            "SIXTEEN",
            "SEVENTEEN",
            "EIGHTEEN",
            "NINETEEN"
        };

        /// <summary>
        /// Multiples of 10 from 20 - 90
        /// Index starts from 0 for alignment.
        /// </summary>
        public static readonly string[] Tens =
        {
            "",
            "",
            "TWENTY",
            "THIRTY",
            "FORTY",
            "FIFTY",
            "SIXTY",
            "SEVENTY",
            "EIGHTY",
            "NINETY"
        };

        /// <summary>
        /// Large number groups based on
        /// International Numbering System
        /// </summary>
        public static readonly string[] Scales =
        {
            "",
            "THOUSAND",
            "MILLION",
            "BILLION",
            "TRILLION"
        };

        /// <summary>
        /// Currency Labels
        /// </summary>
        public const string DollarSingular = "DOLLAR";

        public const string DollarPlural = "DOLLARS";

        public const string CentSingular = "CENT";

        public const string CentPlural = "CENTS";

        /// <summary>
        /// Common Words
        /// </summary>
        public const string Hundred = "HUNDRED";

        public const string And = "AND";

        public const string Zero = "ZERO";
    }
}
