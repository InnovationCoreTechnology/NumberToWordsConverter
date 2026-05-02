namespace NumberToWords.Web.Models.NumberToWords.Responses
{
    public class NumberToWordsResponse
    {
        public decimal? Amount { get; set; }
        public string NumberToWords { get; set; } = string.Empty;
    }
}
