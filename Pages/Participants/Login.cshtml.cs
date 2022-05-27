
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace ProjectCRUD.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public LoginModel()
        {
            UserName = "";
            Password = "";
            ErrorMessage = "";
        }
        public void OnGet()
        {
        }

        public async void OnPost()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid Login or Password";
                return;
            }

            if (UserName == "user" && Password == "password")
            {
                var userClaims = new List<Claim>()
                {
                    new Claim ("UserId", "1"),
                    new Claim (ClaimTypes.Name, "User"),
                    new Claim (ClaimTypes.Role, "user")
                };

                var userIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
                await HttpContext.SignInAsync(userPrincipal);


                Response.Redirect("/Index");
                return;
            }



            if (UserName == "Admin" && Password == "12345")
            {
                var userClaims = new List<Claim>()
                {
                    new Claim ("UserId", "2"),
                    new Claim (ClaimTypes.Name, "MR.Admin"),
                    new Claim (ClaimTypes.Role, "Admin")
                };

                var userIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
                await HttpContext.SignInAsync(userPrincipal);


                Response.Redirect("/Index");
                return;
            }







            ErrorMessage = "Invalid Login or Password";
        }
    }
}
