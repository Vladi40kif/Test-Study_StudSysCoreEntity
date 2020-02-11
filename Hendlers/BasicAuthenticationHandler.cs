using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StudentsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace StudentsApp.Hendlers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {

        private readonly StudentAppContext _context;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            StudentAppContext context,
            ISystemClock clock) : base(options, logger, encoder, clock)
        {
            _context = context;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {

            try
            {

                if (!Request.Headers.ContainsKey("Authoruzation"))
                    return AuthenticateResult.Fail("non implement");

                var autHeaderVal = AuthenticationHeaderValue.Parse(Request.Headers["Authoruzation"]);
                var bytesAfterConvert = Convert.FromBase64String(autHeaderVal.Parameter);
                string[] rez = Encoding.UTF8.GetString(bytesAfterConvert).Split(":");

                string username = rez[0];
                string pass = rez[1];

                Admins admins = _context.Admins.Where(admin =>
                    admin.Username == username && admin.Password == pass).FirstOrDefault();

                if (admins == null)
                    return AuthenticateResult.Fail("non implement");
                else
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, admins.Username) };
                    var indentity = new ClaimsIdentity(claims, Scheme.Name);
                    var princip = new ClaimsPrincipal(indentity);
                    var ticket = new AuthenticationTicket(princip, Scheme.Name);

                    return AuthenticateResult.Success(ticket);
                }

            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail("err username or pass");
            }
           
        }
    }
}
