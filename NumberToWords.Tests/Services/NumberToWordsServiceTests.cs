using NumberToWords.Web.Services.NumberToWords;
using NumberToWords.Tests.Helpers;

namespace NumberToWords.Tests.Services
{
    public class NumberToWordsServiceTests
    {
        private readonly NumberToWordsService _service;

        public NumberToWordsServiceTests()
        {
            _service = new NumberToWordsService();
        }

        [Fact]
        public async Task ConvertNumberToWordsAsync_WhenNegativeAmount_ReturnsFailure()
        {
            var result = await _service.ConvertNumberToWordsAsync(-5);

            result.ShouldBeFailure(
                "NTW02",
                "Invalid input: amount cannot be negative"
            );
        }

        [Fact]
        public async Task ConvertNumberToWordsAsync_WhenZero_ReturnsZeroDollars()
        {
            var result = await _service.ConvertNumberToWordsAsync(0);

            result.ShouldBeSuccess(
                "ZERO DOLLARS",
                "NTW01"
            );
        }

        [Fact]
        public async Task ConvertNumberToWordsAsync_WhenWholeNumber_ReturnsDollarsOnly()
        {
            var result = await _service.ConvertNumberToWordsAsync(5);

            result.ShouldContain("DOLLARS");
            Assert.DoesNotContain("CENTS", result.Data);
        }

        [Fact]
        public async Task ConvertNumberToWordsAsync_WhenDecimal_ReturnsDollarsAndCents()
        {
            var result = await _service.ConvertNumberToWordsAsync(10.50m);

            result.ShouldBeSuccess("TEN DOLLARS AND FIFTY CENTS");

            Assert.Contains("TEN DOLLARS", result.Data);
            Assert.Contains("FIFTY CENTS", result.Data);
        }

        [Fact]
        public async Task ConvertNumberToWordsAsync_WhenOneDollar_UsesSingular()
        {
            var result = await _service.ConvertNumberToWordsAsync(1);

            result.ShouldContain("DOLLAR");
        }
    }
}