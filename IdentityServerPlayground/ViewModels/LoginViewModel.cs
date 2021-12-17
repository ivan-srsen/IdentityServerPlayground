namespace IdentityServerPlayground.ViewModels
{
    using System.ComponentModel.DataAnnotations;

        public class LoginViewModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public bool RememberLogin { get; set; }
            public string ReturnUrl { get; set; }
        }
}
