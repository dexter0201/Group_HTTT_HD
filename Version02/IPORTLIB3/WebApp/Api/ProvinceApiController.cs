using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DTO;
namespace WebApp.Controllers
{
    public class ProvinceApiController : ApiController
    {
        public IEnumerable<Province> Get()
        {
            return AppProvider.Province.Gets(0);
        }
        public Province Get(int id)
        {
            return AppProvider.Province.Get(id);
        }
        public HttpResponseMessage Post(Province province)
        {
            AppProvider.Province.Insert(province);
            var respose = Request.CreateResponse<Province>(HttpStatusCode.Created, province);
            respose.Headers.Location = new System.Uri(Request.RequestUri, "/api/ProvinceApi/" + province.ProvinceId);
            return respose;
        }
        public void Put(int id, [FromBody]string value)
        {
        }
        public Province Delete(int id)
        {
            Province province = AppProvider.Province.Get(id);
            if (province == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            AppProvider.Province.Delete(id);
            return province;
        }
    }
}