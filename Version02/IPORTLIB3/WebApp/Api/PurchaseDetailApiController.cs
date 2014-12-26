using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DTO;
namespace WebApp.Controllers
{
    public class PurchaseDetailApiController : ApiController
    {
        public IEnumerable<PurchaseDetail> Get()
        {
            return AppProvider.PurchaseDetail.Gets(0);
        }
        public PurchaseDetail Get(int id)
        {
            return AppProvider.PurchaseDetail.Get(id);
        }
        public HttpResponseMessage Post(PurchaseDetail purchaseDetail)
        {
            AppProvider.PurchaseDetail.Insert(purchaseDetail);
            var respose = Request.CreateResponse<PurchaseDetail>(HttpStatusCode.Created, purchaseDetail);
            respose.Headers.Location = new System.Uri(Request.RequestUri, "/api/PurchaseDetailApi/" + purchaseDetail.PurchaseDetailId);
            return respose;
        }
        public void Put(int id, [FromBody]string value)
        {
        }
        public PurchaseDetail Delete(int id)
        {
            PurchaseDetail purchaseDetail = AppProvider.PurchaseDetail.Get(id);
            if (purchaseDetail == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            AppProvider.PurchaseDetail.Delete(id);
            return purchaseDetail;
        }
    }
}