using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DTO;
namespace WebApp.Controllers
{
    public class UnitApiController : ApiController
    {
        public IEnumerable<Unit> Get()
        {
            return AppProvider.Unit.Gets(0);
        }
        public Unit Get(int id)
        {
            return AppProvider.Unit.Get(id);
        }
        public HttpResponseMessage Post(Unit unit)
        {
            AppProvider.Unit.Insert(unit);
            var respose = Request.CreateResponse<Unit>(HttpStatusCode.Created, unit);
            respose.Headers.Location = new System.Uri(Request.RequestUri, "/api/UnitApi/" + unit.UnitId);
            return respose;
        }
        public void Put(int id, [FromBody]string value)
        {
        }
        public Unit Delete(int id)
        {
            Unit unit = AppProvider.Unit.Get(id);
            if (unit == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            AppProvider.Unit.Delete(id);
            return unit;
        }
    }
}