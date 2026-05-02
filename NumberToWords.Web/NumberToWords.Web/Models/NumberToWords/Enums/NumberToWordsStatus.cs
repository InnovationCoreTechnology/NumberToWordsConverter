using NumberToWords.Web.Models.Common.Attributes;

namespace NumberToWords.Web.Models.NumberToWords.Enums
{
    public enum NumberToWordsStatus
    {
        [ResponseStatus("NTW01", "Conversion completed successfully")]
        Success,

        [ResponseStatus("NTW02", "Invalid input: amount cannot be negative")]
        InvalidInput,

        [ResponseStatus("NTW99", "Conversion failed due to an unexpected error")]
        UnexpectedError
    }
}
