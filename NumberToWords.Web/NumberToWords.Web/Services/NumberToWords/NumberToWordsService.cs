using NumberToWords.Web.Constants;
using NumberToWords.Web.Interfaces.NumberToWords;
using NumberToWords.Web.Models.Common;
using NumberToWords.Web.Models.Common.Extensions;
using NumberToWords.Web.Models.NumberToWords.Enums;

namespace NumberToWords.Web.Services.NumberToWords
{
    public class NumberToWordsService : INumberToWordsService
    {
        /// <summary>
        /// Asynchronously converts a numeric monetary amount to its equivalent words representation in English,
        /// including both dollars and cents.
        /// </summary>
        /// <remarks>If the amount is zero, the method returns 'zero dollars'. Singular and plural forms
        /// for dollars and cents are used as appropriate based on the values provided.</remarks>
        /// <param name="amount">The monetary amount to convert, expressed as a decimal value. Must be zero or greater.</param>
        /// <returns>A string containing the amount in words, formatted as 'X dollars and Y cents' or 'X dollars' if there are no
        /// cents.</returns>
        public async Task<ServiceResponse<string>> ConvertNumberToWordsAsync(decimal amount)
        {
            if (amount < 0)
            {
                return ServiceResponse<string>.Failure(
                    NumberToWordsStatus.InvalidInput
                );
            }

            if (amount == 0)
            {
                return ServiceResponse<string>.SuccessResponse(
                    $"{NumberWordConstants.Zero} {NumberWordConstants.DollarPlural}",
                    NumberToWordsStatus.Success
                );
            }

            long dollars = (long)Math.Floor(amount);

            int cents = (int)Math.Round((amount - dollars) * 100);

            string dollarWords = ConvertWholeNumber(dollars);

            string dollarLabel = dollars == 1
                ? NumberWordConstants.DollarSingular
                : NumberWordConstants.DollarPlural;

            string result = $"{dollarWords} {dollarLabel}";

            if (cents > 0)
            {
                string centWords = ConvertWholeNumber(cents);

                string centLabel =
                    cents == 1
                    ? NumberWordConstants.CentSingular
                    : NumberWordConstants.CentPlural;

                result += $" {NumberWordConstants.And} {centWords} {centLabel}";
            }

            return ServiceResponse<string>.SuccessResponse(
                    result.Trim(),
                    NumberToWordsStatus.Success
                );
        }

        /// <summary>
        /// Converts a non-negative whole number to its English word representation.
        /// </summary>
        /// <remarks>This method supports numbers up to the highest scale defined in
        /// NumberWordConstants.Scales. The output follows standard English conventions, including the use of hyphens
        /// for compound numbers and the word 'and' where appropriate.</remarks>
        /// <param name="number">The non-negative whole number to convert to words.</param>
        /// <returns>A string containing the English words that represent the specified number.</returns>
        private string ConvertWholeNumber(long number)
        {
            if (number == 0)
            {
                return NumberWordConstants.Zero;
            }

            if (number < 10)
            {
                return NumberWordConstants.Units[number];
            }

            if (number < 20)
            {
                return NumberWordConstants.Teens[number - 10];
            }

            if (number < 100)
            {
                string tens = NumberWordConstants.Tens[number / 10];

                string units = ConvertWholeNumber(number % 10);

                return number % 10 == 0
                    ? tens
                    : $"{tens}-{units}";
            }

            if (number < 1000)
            {
                string hundreds = $"{ConvertWholeNumber(number / 100)} {NumberWordConstants.Hundred}";

                string remainder = ConvertWholeNumber(number % 100);

                return number % 100 == 0 ? hundreds
                    : $"{hundreds} {NumberWordConstants.And} {remainder}";
            }

            for (int i = 1; i < NumberWordConstants.Scales.Length; i++)
            {
                long scaleValue = (long)Math.Pow(1000, i);

                long nextScaleValue = scaleValue * 1000;

                if (number < nextScaleValue)
                {
                    string scalePart =
                        ConvertWholeNumber(number / scaleValue);

                    string scaleName =
                        NumberWordConstants.Scales[i];

                    long remainder = number % scaleValue;

                    if (remainder == 0)
                    {
                        return $"{scalePart} {scaleName}";
                    }

                    return
                        $"{scalePart} {scaleName} {ConvertWholeNumber(remainder)}";
                }
            }

            return string.Empty;
        }
    }
}
