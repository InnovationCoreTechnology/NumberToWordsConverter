using NumberToWords.Web.Models.Common.Attributes;
using System.Reflection;

namespace NumberToWords.Web.Models.Common.Extensions
{
    public static class EnumMetadataExtensions
    {
        public static (string Code, string Message) GetMetadata(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());

            var attr = field?
                .GetCustomAttribute<ResponseStatusAttribute>();

            return attr == null
                ? ("UNKNOWN", "Unknown status")
                : (attr.Code, attr.Message);
        }

        public static (string Code, string Message) Info(this Enum value)
            => value.GetMetadata();
    }
}
