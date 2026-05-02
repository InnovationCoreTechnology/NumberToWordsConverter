using NumberToWords.Web.Models.Common;

namespace NumberToWords.Tests.Helpers
{
    public static class ServiceResponseTestExtensions
    {
        public static void ShouldBeSuccess<T>(this ServiceResponse<T> response,
            T expectedData, string? expectedCode = null)
        {
            Assert.NotNull(response);
            Assert.True(response.Success);
            Assert.Equal(expectedData, response.Data);

            if (!string.IsNullOrWhiteSpace(expectedCode))
            {
                Assert.Equal(expectedCode, response.Code);
            }
        }

        public static void ShouldBeFailure<T>(this ServiceResponse<T> response,
             string expectedCode,
             string? expectedMessageContains = null)
        {
            Assert.NotNull(response);
            Assert.False(response.Success);
            Assert.Equal(expectedCode, response.Code);

            if (!string.IsNullOrWhiteSpace(expectedMessageContains))
            {
                Assert.Contains(
                    expectedMessageContains,
                    response.Message,
                    StringComparison.OrdinalIgnoreCase);
            }
        }

        public static void ShouldContain<T>(this ServiceResponse<T> response, string text)
        {
            Assert.NotNull(response);
            Assert.Contains(text, response.Data?.ToString(), StringComparison.OrdinalIgnoreCase);
        }

        public static void ShouldNotContain<T>(this ServiceResponse<T> response, string text)
        {
            Assert.NotNull(response);
            Assert.DoesNotContain(text, response.Data?.ToString(), StringComparison.OrdinalIgnoreCase);
        }
    }
}
