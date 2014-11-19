using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public abstract class BaseProvider<T>
    {
        protected List<T> Gets(SqlDataReader reader)
        {
            List<T> list = new List<T>();
            while (reader.Read())
                list.Add(Get(reader));
            return list;
        }

        protected abstract T Get(SqlDataReader reader);
        public T Get(int id)
        {
            using (SqlConnection cn = new SqlConnection(Config.ConnectString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                SetGetParams(cmd, id);
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    return Get(reader);
                return default(T);
            }
        }

        protected abstract void SetGetParams(SqlCommand cmd, int id);

        public virtual int Count()
        {
            return 0;
        }

        public int Page(int pageSize)
        {
            int n = Count();
            int ret = n / pageSize;
            if (n % pageSize != 0)
                ret++;
            return ret;
        }
        
        public int Page()
        {
            return Page(Config.pageSize);
        }
        public virtual bool Insert(T t)
        {
            using (SqlConnection cn = new SqlConnection(Config.ConnectString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open();
                return SetInsertParams(cmd, t);
            }
        }

        protected abstract bool SetInsertParams(SqlCommand cmd, T t);

        public virtual bool Update(T t)
        {
            using (SqlConnection cn = new SqlConnection(Config.ConnectString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                SetUpdateParams(cmd, t);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        protected abstract void SetUpdateParams(SqlCommand cmd, T t);
        public virtual bool Delete(T t)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                SetDeleteParams(cmd, t);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        protected abstract void SetDeleteParams(SqlCommand cmd, T t);
    }
}
