using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DTO;
namespace WebApp.Controllers
{
    public class PeriodApiController : ApiController
    {
        public IEnumerable<Period> Get()
        {
            return AppProvider.Period.Gets(0);
        }
        public Period Get(int id)
        {
            return AppProvider.Period.Get(id);
        }
        public HttpResponseMessage Post(Period period)
        {
            AppProvider.Period.Insert(period);
            var respose = Request.CreateResponse<Period>(HttpStatusCode.Created, period);
            respose.Headers.Location = new System.Uri(Request.RequestUri, "/api/PeriodApi/" + period.PeriodId);
            return respose;
        }
        public void Put(int id, [FromBody]string value)
        {
        }
        public Period Delete(int id)
        {
            Period period = AppProvider.Period.Get(id);
            if (period == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            AppProvider.Period.Delete(id);
            return period;
        }
    }
}