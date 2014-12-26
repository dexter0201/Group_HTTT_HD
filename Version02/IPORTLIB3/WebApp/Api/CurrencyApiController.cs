using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DTO;
namespace WebApp.Controllers
{
    public class CurrencyApiController : ApiController
    {
        public IEnumerable<Currency> Get()
        {
            return AppProvider.Currency.Gets(0);
        }
        public Currency Get(int id)
        {
            return AppProvider.Currency.Get(id);
        }
        public HttpResponseMessage Post(Currency currency)
        {
            AppProvider.Currency.Insert(currency);
            var respose = Request.CreateResponse<Currency>(HttpStatusCode.Created, currency);
            respose.Headers.Location = new System.Uri(Request.RequestUri, "/api/CurrencyApi/" + currency.CurrencyId);
            return respose;
        }
        public void Put(int id, [FromBody]string value)
        {
        }
        public Currency Delete(int id)
        {
            Currency currency = AppProvider.Currency.Get(id);
            if (currency == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            AppProvider.Currency.Delete(id);
            return currency;
        }
    }
}