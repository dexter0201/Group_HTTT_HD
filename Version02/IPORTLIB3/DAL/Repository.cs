using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using IDAL;

namespace DAL
{
    public abstract class Repository<T>
    {
        public bool Insert(T obj)
        {
            using (SqlConnection cn = new SqlConnection(Setting.ConnString))
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open();
                SetInsertParam(cmd, obj);
                SetParam(cmd, obj);
                int ret = cmd.ExecuteNonQuery();
                if (ret > 0)
                {
                    SetReturnParam(cmd, obj);
                    return true;
                }
                return false;
            }
        }
        protected abstract void SetParam(SqlCommand cmd, T obj);
        protected abstract void SetReturnParam(SqlCommand cmd, T obj);
        protected abstract void SetInsertParam(SqlCommand cmd, T obj);
        public bool Delete(object id)
        {
            using (SqlConnection cn = new SqlConnection(Setting.ConnString))
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                SetDeleteParam(cmd, id);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        protected abstract void SetDeleteParam(SqlCommand cmd, object id);
        public bool Update(T obj)
        {
            using (SqlConnection cn = new SqlConnection(Setting.ConnString))
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                SetUpdateParam(cmd, obj);
                SetParam(cmd, obj);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        protected abstract void SetUpdateParam(SqlCommand cmd, T obj);
        public T Get(object id)
        {
            using (SqlConnection cn = new SqlConnection(Setting.ConnString))
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                SetGetParam(cmd, id);
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    return GetFromReader(reader);
                return default(T);
            }
        }
        protected abstract void SetGetParam(SqlCommand cmd, object id);
        protected abstract T GetFromReader(SqlDataReader reader);
        public IEnumerable<T> Gets(object obj = null)
        {
            using (SqlConnection cn = new SqlConnection(Setting.ConnString))
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                SetGetsParam(cmd, obj);
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                return GetsFromReader(reader);
            }
        }
        protected abstract void SetGetsParam(SqlCommand cmd, object obj);
        protected IEnumerable<T> GetsFromReader(SqlDataReader reader)
        {
            List<T> list = new List<T>();
            while (reader.Read())
                list.Add(GetFromReader(reader));
            return list;
        }
        public int Page(int pageSize, object obj = null)
        {
            int n = Count(obj);
            int ret = n / pageSize;
            if (n % pageSize != 0)
                ret++;
            return ret;
        }
        public int Page(object obj = null)
        {
            return Page(Setting.PageSize, obj);
        }
        public int Count(object obj)
        {
            using (SqlConnection cn = new SqlConnection(Setting.ConnString))
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                SetCountParam(cmd, obj);
                cn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }
        protected abstract void SetCountParam(SqlCommand cmd, object obj);
    }
}