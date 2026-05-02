using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;
using NumberToWords.Web.Interfaces.NumberToWords;
using NumberToWords.Web.Models.NumberToWords.Requests;
using NumberToWords.Web.Models.NumberToWords.Responses;

namespace NumberToWords.Web.Controllers.NumberToWords
{
    public class NumberToWordsController : Controller
    {
        private readonly INumberToWordsService _service;
        public NumberToWordsController(INumberToWordsService service)
        {
            _service = service;
        }

        /// <summary>
        /// Returns a view that displays the number to words conversion interface.
        /// </summary>
        /// <remarks>This action method is typically used to render the starting page for the number to
        /// words conversion feature. The view is initialized with a new instance of NumberToWordsResponse to prepare
        /// the interface for user input.</remarks>
        /// <returns>An IActionResult that renders the initial view for converting numbers to words.</returns>
        [HttpGet]
        public IActionResult NumberToWordsIndex()
        {
            return View(new NumberToWordsResponse());
        }

        /// <summary>
        /// Converts a specified numeric amount into its equivalent words representation.
        /// </summary>
        /// <remarks>This method is asynchronous and may involve network or processing delays. Ensure that
        /// the input amount is a valid number.</remarks>
        /// <param name="numberRequest">The request object containing the numeric amount to be converted into words. Must not be null.</param>
        /// <returns>A JSON object containing the words representation of the specified numeric amount.</returns>
        [HttpPost]
        public async Task<IActionResult> NumberToWordsIndex([FromBody] NumberToWordsRequest numberRequest)
        {
            var serviceResponse = await _service.ConvertNumberToWordsAsync(numberRequest.Amount);

            return Json(serviceResponse);
        }
    }
}
