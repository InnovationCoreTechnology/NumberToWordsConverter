namespace NumberToWords.Web.Models.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ResponseStatusAttribute : Attribute
    {
        public string Code { get; }
        public string Message { get; }

        public ResponseStatusAttribute(string code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
