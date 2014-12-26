using System.Collections.Generic;
using Microsoft.Office.Interop.Word;
using System;
namespace WebApp.Models
{
    public abstract class WordBase<T>
    {
        public IEnumerable<T> Gets(string path)
        {
            Application application = null;
            Microsoft.Office.Interop.Word.Document doc = null;
            IEnumerable<T> data = null;
            try
            {
                application = new Application();
                object missing = Type.Missing;
                object fileName = path;
                doc = application.Documents.Open(
                    ref fileName,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing
                );
                string read = string.Empty;
                data = GetsFromDocument(doc);
            }
            finally
            {
                if (doc != null)
                    ((_Document) doc).Close();
                    
                if (application != null)
                    ((_Application)application).Quit();
            }
            return data;
        }
        protected abstract IEnumerable<T> GetsFromDocument(Document doc);
    }
}