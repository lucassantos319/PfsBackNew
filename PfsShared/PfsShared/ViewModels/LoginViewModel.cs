
namespace PfsShared.ViewModels
{
    public class LoginViewModel
    {
        public class LoginRequest
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class LoginResponse
        {
            public string AccessToken { get; set; }
            public int ExpireAt { get; set; }
        }
    }
}
