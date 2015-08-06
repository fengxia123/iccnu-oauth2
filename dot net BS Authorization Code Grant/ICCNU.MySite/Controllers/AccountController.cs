using System;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using DotNetOpenAuth.OAuth2;
using ICCNU.MySite.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Newtonsoft.Json;

namespace ICCNU.MySite.Controllers
{
    public class AccountController : Controller
    {
        private WebServerClient _webServerClient;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? (_signInManager = HttpContext.GetOwinContext().Get<ApplicationSignInManager>());
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? (_userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>());
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Account
        public ActionResult Login(string returnUrl)
        {
            _webServerClient = OAuthConfiguration.InitializeWebServerClient();

            var result = _webServerClient.ProcessUserAuthorization(Request);
            if (result == null)
            {

                var userAuthorization = _webServerClient.PrepareRequestUserAuthorization();

                //Clear returnUrl

                userAuthorization.Send(HttpContext);
                Response.End();
            }
            else
            {
                var username = OAuthConfiguration.GetMe(result.AccessToken);
                var user = UserManager.FindByName(username);
                if (user != null)
                {
                    SignInManager.SignIn(user, false, false);
                }
                else
                {
                    var newuser = new ApplicationUser { UserName = username, Email = username };
                    UserManager.Create(newuser);
                    SignInManager.SignIn(newuser, false, false);
                }

                return RedirectToLocal(returnUrl);
            }

            return View();
        }

        public IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        //
        // POST: /Account/LogOff
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }

    public static class OAuthConfiguration
    {
        static OAuthConfiguration()
        {

            ClientId = "code_test";

            ClientSecret = "code_test";

#if DEBUG
            AuthorizationServerUri = new Uri("http://localhost.:3000/");

            ResourceServerUri = new Uri("http://localhost.:3000/");
#else
            AuthorizationServerUri = new Uri("http://www.iccnu.net/");

            ResourceServerUri = new Uri("http://www.iccnu.net/");
#endif

            AuthorizationEndpoint = "/oauth2/authorize";

            TokenEndpoint = "/api/oauth2/token";

            ApiMeEndpoint = "/api/oauth2/me";
        }

        public static string AuthorizationEndpoint { get; private set; }

        public static string TokenEndpoint { get; private set; }

        public static  string ClientId { get; private set; }
                
        public static string ClientSecret { get; private set; }
                
        public static string ApiMeEndpoint { get; private set; }
                
        public static Uri AuthorizationServerUri { get; private set; }
                
        public static Uri ResourceServerUri { get; private set; }

        public static WebServerClient InitializeWebServerClient()
        {
            var authorizationServer = new AuthorizationServerDescription
            {
                AuthorizationEndpoint = new Uri(AuthorizationServerUri, AuthorizationEndpoint),
                TokenEndpoint = new Uri(AuthorizationServerUri, TokenEndpoint),
            };
            return new WebServerClient(authorizationServer, ClientId, ClientSecret);
        }

        public static string GetMe(string accessToken)
        {
            var client = new HttpClient(InitializeWebServerClient().CreateAuthorizingHandler(accessToken));
            string body = client.GetStringAsync(new Uri(ResourceServerUri, ApiMeEndpoint)).Result;

            return JsonConvert.DeserializeObject<dynamic>(body).email;
        }
    }
}