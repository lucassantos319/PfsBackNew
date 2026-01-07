using PfsShared.Errors;

namespace PfsShared
{
    public class ResponseResult<T>
    {
        public ResponseResult()
        {
        }

        public static ResponseResult<T> Error(IEnumerable<ErrorResult> errors)
        {
            return new ResponseResult<T>()
            {
                Errors = errors,
                Success = false
            };
        }

        public IEnumerable<ErrorResult> Errors { get; set; }
        public IEnumerable<T> Obj { get; set; }
        public bool Success { get; set; }
    }
}
