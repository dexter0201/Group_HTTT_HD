using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DTO;
namespace WebApp.Controllers
{
    public class CountryApiController : ApiController
    {
        public IEnumerable<Country> Get()
        {
            return AppProvider.Country.Gets(0);
        }
        public Country Get(int id)
        {
            return AppProvider.Country.Get(id);
        }
        public HttpResponseMessage Post(Country country)
        {
            AppProvider.Country.Insert(country);
            var respose = Request.CreateResponse<Country>(HttpStatusCode.Created, country);
            respose.Headers.Location = new System.Uri(Request.RequestUri, "/api/CountryApi/" + country.CountryId);
            return respose;
        }
        public void Put(int id, [FromBody]string value)
        {
        }
        public Country Delete(int id)
        {
            Country country = AppProvider.Country.Get(id);
            if (country == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            AppProvider.Country.Delete(id);
            return country;
        }
    }
}