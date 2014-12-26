using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DTO;
namespace WebApp.Controllers
{
    public class LoanDetailApiController : ApiController
    {
        public IEnumerable<LoanDetail> Get()
        {
            return AppProvider.LoanDetail.Gets(0);
        }
        public LoanDetail Get(int id)
        {
            return AppProvider.LoanDetail.Get(id);
        }
        public HttpResponseMessage Post(LoanDetail loanDetail)
        {
            AppProvider.LoanDetail.Insert(loanDetail);
            var respose = Request.CreateResponse<LoanDetail>(HttpStatusCode.Created, loanDetail);
            respose.Headers.Location = new System.Uri(Request.RequestUri, "/api/LoanDetailApi/" + loanDetail.LoanDetailId);
            return respose;
        }
        public void Put(int id, [FromBody]string value)
        {
        }
        public LoanDetail Delete(int id)
        {
            LoanDetail loanDetail = AppProvider.LoanDetail.Get(id);
            if (loanDetail == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            AppProvider.LoanDetail.Delete(id);
            return loanDetail;
        }
    }
}