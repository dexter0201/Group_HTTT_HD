using System.Collections.Generic;
using Microsoft.Office.Interop.Word;

namespace WebApp.Models
{
    public class WordMail : WordBase<string>
    {
        protected override IEnumerable<string> GetsFromDocument(Document doc)
        {
            List<string> list = new List<string>();
            foreach (Table table in doc.Tables)
            {
                foreach (Row row in table.Rows)
                {
                    string str = row.Cells[2].Range.Text;
                    list.Add(str.Substring(0, str.Length - 2));
                }
            }
            return list;
        }
    }
}