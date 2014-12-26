using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DTO;
namespace WebApp.Controllers
{
    public class PurchaseApiController : ApiController
    {
        public IEnumerable<Purchase> Get()
        {
            return AppProvider.Purchase.Gets(0);
        }
        public Purchase Get(int id)
        {
            return AppProvider.Purchase.Get(id);
        }
        public HttpResponseMessage Post(Purchase purchase)
        {
            AppProvider.Purchase.Insert(purchase);
            var respose = Request.CreateResponse<Purchase>(HttpStatusCode.Created, purchase);
            respose.Headers.Location = new System.Uri(Request.RequestUri, "/api/PurchaseApi/" + purchase.PurchaseId);
            return respose;
        }
        public void Put(int id, [FromBody]string value)
        {
        }
        public Purchase Delete(int id)
        {
            Purchase purchase = AppProvider.Purchase.Get(id);
            if (purchase == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            AppProvider.Purchase.Delete(id);
            return purchase;
        }
    }
}