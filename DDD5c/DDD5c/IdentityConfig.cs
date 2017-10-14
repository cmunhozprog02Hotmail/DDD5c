using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using DDD5c.DAL;
using DDD5c.Infraestrutura;

namespace DDD5c
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
             app.CreatePerOwinContext<IdentityDbContextAplicacao>(IdentityDbContextAplicacao.Create);
             app.CreatePerOwinContext<GerenciadorUsuario>(GerenciadorUsuario.Create);
             app.UseCookieAuthentication(new CookieAuthenticationOptions { AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie, LoginPath = new PathString("/Seguranca/Account/Login"), });
        }
    }
 }
