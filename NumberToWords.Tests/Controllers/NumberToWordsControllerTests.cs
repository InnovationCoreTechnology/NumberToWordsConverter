using Microsoft.AspNetCore.Mvc;
using NumberToWords.Tests.Fakes;
using NumberToWords.Tests.Helpers;
using NumberToWords.Web.Controllers.NumberToWords;
using NumberToWords.Web.Models.Common;
using NumberToWords.Web.Models.NumberToWords.Enums;
using NumberToWords.Web.Models.NumberToWords.Requests;

namespace NumberToWords.Tests.Controllers
{
    public class NumberToWordsControllerTests
    {
        private readonly NumberToWordsController _controller;

        public NumberToWordsControllerTests()
        {
            var fakeService = new InMemoryNumberToWordsService();
            _controller = new NumberToWordsController(fakeService);
        }

        [Fact]
        public async Task Post_NumberToWordsIndex_ReturnsJsonResult()
        {
            var request = new NumberToWordsRequest
            {
                Amount = 100m
            };

            var result = await _controller.NumberToWordsIndex(request);

            var json = Assert.IsType<JsonResult>(result);

            var response = Assert.IsType<ServiceResponse<string>>(json.Value);

            response.ShouldBeSuccess(
                "ONE HUNDRED DOLLARS",
                "NTW01"
            );
        }
    }
}