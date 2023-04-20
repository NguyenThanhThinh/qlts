using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin;
using Owin;
using System;
using System.Web;
using System.Web.Mvc;

namespace qlts
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            //app.CreatePerOwinContext(MaintenanceDbContext.Create);

            var url = new UrlHelper(HttpContext.Current.Request.RequestContext);

            //app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            //app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "CookieAuth",
                LoginPath = new PathString("/Account/login"),
                ExpireTimeSpan = TimeSpan.FromDays(1)
            });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(30));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);
        }
    }
}