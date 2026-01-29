using PfsShared.Errors;

namespace PfsShared
{
    public sealed class Result<T>
    {
        private Result(T valor)
        {
        }

        public static Result<T> Error(string code,string message)
        {
            return new Result<T>
            {
                Success = false,
                Errors = new()
                {
                    Code = code,
                    Message = message
                }
            };
        }

        public static Result<T> Sucesss()
        {

        }

        public ErrorResult Errors { get; set; }
        public IEnumerable<T> Obj { get; set; }
        public bool Success { get; set; }
    }

    public class ErrorResult
    {
        public string Message { get; set; }
        public string Code { get; set; }
    }
}
