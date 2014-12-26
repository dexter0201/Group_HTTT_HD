using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DTO;
namespace WebApp.Controllers
{
    public class StoreApiController : ApiController
    {
        public IEnumerable<Store> Get()
        {
            return AppProvider.Store.Gets(0);
        }
        public Store Get(int id)
        {
            return AppProvider.Store.Get(id);
        }
        public HttpResponseMessage Post(Store store)
        {
            AppProvider.Store.Insert(store);
            var respose = Request.CreateResponse<Store>(HttpStatusCode.Created, store);
            respose.Headers.Location = new System.Uri(Request.RequestUri, "/api/StoreApi/" + store.StoreId);
            return respose;
        }
        public void Put(int id, [FromBody]string value)
        {
        }
        public Store Delete(int id)
        {
            Store store = AppProvider.Store.Get(id);
            if (store == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            AppProvider.Store.Delete(id);
            return store;
        }
    }
}