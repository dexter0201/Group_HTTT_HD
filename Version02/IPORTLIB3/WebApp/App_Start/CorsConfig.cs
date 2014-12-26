using Thinktecture.IdentityModel.Http.Cors.WebApi;
using System.Web.Http;

namespace WebApp
{
    public class CorsConfig
    {
        public static void RegisterCors(HttpConfiguration httpConfig)
        {
            WebApiCorsConfiguration corsConfig = new WebApiCorsConfiguration();

            // this adds the CorsMessageHandler to the HttpConfiguration's
            // MessageHandlers collection
            corsConfig.RegisterGlobal(httpConfig);

            // this allow all CORS requests to the Products controller
            // from the http://foo.com origin.
            corsConfig
                //.ForResources("Products")
                //.ForOrigins("*")
               .AllowAll();
        }
    }
}