
namespace PfsShared.ViewModels
{
    public class LoginViewModel
    {
        public class Request
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class Response
        {
            public string AccessToken { get; set; }
            public int ExpireAt { get; set; }
        }
    }
}
