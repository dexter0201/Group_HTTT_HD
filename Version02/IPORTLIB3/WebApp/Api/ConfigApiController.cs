using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DTO;
namespace WebApp.Controllers
{
    public class ConfigApiController : ApiController
    {
        public IEnumerable<Config> Get()
        {
            return AppProvider.Config.Gets(0);
        }
        public Config Get(int id)
        {
            return AppProvider.Config.Get(id);
        }
        public HttpResponseMessage Post(Config config)
        {
            AppProvider.Config.Insert(config);
            var respose = Request.CreateResponse<Config>(HttpStatusCode.Created, config);
            respose.Headers.Location = new System.Uri(Request.RequestUri, "/api/ConfigApi/" + config.ConfigId);
            return respose;
        }
        public void Put(int id, [FromBody]string value)
        {
        }
        public Config Delete(int id)
        {
            Config config = AppProvider.Config.Get(id);
            if (config == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            AppProvider.Config.Delete(id);
            return config;
        }
    }
}