using System.Collections.Generic;
using System.Data.OleDb;
using BLL;
namespace WebApp.Models
{
    public abstract class ExcelBase<T>
    {
        public IEnumerable<T> Gets(object obj)
        {
            using (OleDbConnection cn = new OleDbConnection(string.Format(Setting.ConnectExcel, obj)))
            {
                OleDbCommand cmd = cn.CreateCommand();
                SetGetsParam(cmd);
                cn.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                return GetsFromReader(reader);
            }
        }
        private IEnumerable<T> GetsFromReader(OleDbDataReader reader)
        {
            List<T> list = new List<T>();
            while (reader.Read())
                list.Add(GetFromReader(reader));
            return list;
        }
        protected abstract T GetFromReader(OleDbDataReader reader);
        protected abstract void SetGetsParam(OleDbCommand cmd);
    }
}