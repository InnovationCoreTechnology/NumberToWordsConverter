using NumberToWords.Web.Models.Common.Extensions;

namespace NumberToWords.Web.Models.Common
{
    public class ServiceResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;

        public static ServiceResponse<T> SuccessResponse(T data, Enum status)
        {
            var meta = status.GetMetadata();

            return new ServiceResponse<T>
            {
                Success = true,
                Data = data,
                Code = meta.Code,
                Message = meta.Message
            };
        }

        public static ServiceResponse<T> Failure(Enum status)
        {
            var meta = status.GetMetadata();

            return new ServiceResponse<T>
            {
                Success = false,
                Data = default,
                Code = meta.Code,
                Message = meta.Message
            };
        }
    }
}