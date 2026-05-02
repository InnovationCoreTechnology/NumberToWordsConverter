using NumberToWords.Web.Interfaces.NumberToWords;
using NumberToWords.Web.Models.Common;
using NumberToWords.Web.Models.NumberToWords.Enums;

namespace NumberToWords.Tests.Fakes
{
    public class InMemoryNumberToWordsService : INumberToWordsService
    {
        public Task<ServiceResponse<string>> ConvertNumberToWordsAsync(decimal amount)
        {
            if (amount < 0)
            {
                return Task.FromResult(
                    ServiceResponse<string>.Failure(
                        NumberToWordsStatus.InvalidInput
                    )
                );
            }

            return Task.FromResult(
                ServiceResponse<string>.SuccessResponse(
                    "ONE HUNDRED DOLLARS",
                    NumberToWordsStatus.Success
                )
            );
        }
    }
}
