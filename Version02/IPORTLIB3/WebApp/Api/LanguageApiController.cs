using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DTO;
namespace WebApp.Controllers
{
    public class LanguageApiController : ApiController
    {
        public IEnumerable<Language> Get()
        {
            return AppProvider.Language.Gets(0);
        }
        public Language Get(int id)
        {
            return AppProvider.Language.Get(id);
        }
        public HttpResponseMessage Post(Language language)
        {
            AppProvider.Language.Insert(language);
            var respose = Request.CreateResponse<Language>(HttpStatusCode.Created, language);
            respose.Headers.Location = new System.Uri(Request.RequestUri, "/api/LanguageApi/" + language.LanguageId);
            return respose;
        }
        public void Put(int id, [FromBody]string value)
        {
        }
        public Language Delete(int id)
        {
            Language language = AppProvider.Language.Get(id);
            if (language == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            AppProvider.Language.Delete(id);
            return language;
        }
    }
}