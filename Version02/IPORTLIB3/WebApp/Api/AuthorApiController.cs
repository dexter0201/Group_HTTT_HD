using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DTO;
namespace WebApp.Controllers
{
    public class AuthorApiController : ApiController
    {
        public IEnumerable<Author> Get()
        {
            return AppProvider.Author.Gets(0);
        }
        public Author Get(int id)
        {
            return AppProvider.Author.Get(id);
        }
        public HttpResponseMessage Post(Author author)
        {
            AppProvider.Author.Insert(author);
            var respose = Request.CreateResponse<Author>(HttpStatusCode.Created, author);
            respose.Headers.Location = new System.Uri(Request.RequestUri, "/api/AuthorApi/" + author.AuthorId);
            return respose;
        }
        public void Put(int id, [FromBody]string value)
        {
        }
        public Author Delete(int id)
        {
            Author author = AppProvider.Author.Get(id);
            if (author == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            AppProvider.Author.Delete(id);
            return author;
        }
    }
}