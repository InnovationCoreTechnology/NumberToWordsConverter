using NumberToWords.Web.Models.Common;

namespace NumberToWords.Web.Interfaces.NumberToWords
{
    public interface INumberToWordsService
    {
        Task<ServiceResponse<string>> ConvertNumberToWordsAsync(decimal amount);
    }
}
