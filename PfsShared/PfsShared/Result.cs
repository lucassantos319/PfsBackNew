using PfsShared.Errors;

namespace PfsShared
{
    public sealed class Result<T>
    {
        public static Result<T> Sucesss(T valor)
        {
            return new Result<T>
            {
                Success = true,
                Obj = new[] { valor }
            };
        }

        public ErrorResult Errors { get; set; }
        public IEnumerable<T> Obj { get; set; }
        public bool Success { get; set; }
    }

    public sealed class Result
    {
        public static Result<T> Error<T>(string code, string message)
        {
            return new Result<T>
            {
                Success = false,
                Errors = new ErrorResult
                {
                    Code = code,
                    Message = message
                }
            };
        }
    }

    public class ErrorResult
    {
        public string Message { get; set; }
        public string Code { get; set; }
    }
}
