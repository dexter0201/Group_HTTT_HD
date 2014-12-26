using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DTO;
namespace WebApp.Controllers
{
    public class LoanApiController : ApiController
    {
        public IEnumerable<Loan> Get()
        {
            return AppProvider.Loan.Gets(0);
        }
        public Loan Get(int id)
        {
            return AppProvider.Loan.Get(id);
        }
        public HttpResponseMessage Post(Loan loan)
        {
            AppProvider.Loan.Insert(loan);
            var respose = Request.CreateResponse<Loan>(HttpStatusCode.Created, loan);
            respose.Headers.Location = new System.Uri(Request.RequestUri, "/api/LoanApi/" + loan.LoanId);
            return respose;
        }
        public void Put(int id, [FromBody]string value)
        {
        }
        public Loan Delete(int id)
        {
            Loan loan = AppProvider.Loan.Get(id);
            if (loan == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            AppProvider.Loan.Delete(id);
            return loan;
        }
    }
}