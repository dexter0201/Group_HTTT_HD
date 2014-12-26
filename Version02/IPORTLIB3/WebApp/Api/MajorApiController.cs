using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DTO;
namespace WebApp.Controllers
{
    public class MajorApiController : ApiController
    {
        public IEnumerable<Major> Get()
        {
            return AppProvider.Major.Gets(0);
        }
        public Major Get(int id)
        {
            return AppProvider.Major.Get(id);
        }
        public HttpResponseMessage Post(Major major)
        {
            AppProvider.Major.Insert(major);
            var respose = Request.CreateResponse<Major>(HttpStatusCode.Created, major);
            respose.Headers.Location = new System.Uri(Request.RequestUri, "/api/MajorApi/" + major.MajorId);
            return respose;
        }
        public void Put(int id, [FromBody]string value)
        {
        }
        public Major Delete(int id)
        {
            Major major = AppProvider.Major.Get(id);
            if (major == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            AppProvider.Major.Delete(id);
            return major;
        }
    }
}