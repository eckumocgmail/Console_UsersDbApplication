namespace Mvc_WwwLogin.Pages
{
    public class SigninResult
    {
        public bool Succeeded { get; set; }
        public bool RequiresTwoFactor { get; set; }
        public bool IsLockedOut { get; set; }
    }
}