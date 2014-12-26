using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DTO;
namespace WebApp.Controllers
{
    public class BookApiController : ApiController
    {
        public IEnumerable<Book> Get()
        {
            return AppProvider.Book.Gets(0);
        }
        public Book Get(int id)
        {
            return AppProvider.Book.Get(id);
        }
        public HttpResponseMessage Post(Book book)
        {
            AppProvider.Book.Insert(book);
            var respose = Request.CreateResponse<Book>(HttpStatusCode.Created, book);
            respose.Headers.Location = new System.Uri(Request.RequestUri, "/api/BookApi/" + book.BookId);
            return respose;
        }
        public void Put(int id, [FromBody]string value)
        {
        }
        public Book Delete(int id)
        {
            Book book = AppProvider.Book.Get(id);
            if (book == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            AppProvider.Book.Delete(id);
            return book;
        }
    }
}