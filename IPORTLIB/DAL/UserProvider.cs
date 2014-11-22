using System.Linq;
using System.Collections.Generic;
using DTO;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
    public class UserProvider : BaseProvider<User>
    {
        protected override User Get(SqlDataReader reader)
        {
            return new User {
                UserId = (int)reader["UserId"],
                UserNo = (string)reader["UserNo"],
                DepartmentId = (int)reader["DepartmentId"],
                DepartmentName = (string)reader["DepartmentName"],
                FirstName = (string)reader["FirstName"],
                LastName = (string)reader["LastName"],
                //AttachmentId = reader.GetSchemaTable().Select("ColumnName='AttachmentId'").Length > 0 ? (int)reader["AttachmentId"] : -1,
                //Url = reader.GetSchemaTable().Select("ColumnName='Url'").Length > 0 ? (string)reader["Url"] : ""
            };
        }

        public List<User> Gets(int pageSize, int pageIndex)
        {
            using (SqlConnection cn = new SqlConnection(Config.ConnectString))
            {
                SqlCommand cmd = new SqlCommand("GetUsers", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
                cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                return Gets(reader);
            }
        }
        public override int Count()
        {
            using (SqlConnection cn = new SqlConnection(Config.ConnectString))
            {
                SqlCommand cmd = new SqlCommand("CountUsers", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }
        public List<User> Gets(int pageIndex)
        {
            return Gets(Config.pageSize, pageIndex);
        }

        private User getForUpdate(SqlDataReader reader)
        {
            return new User
            {
                UserId = (int)reader["UserId"],
                UserNo = (string)reader["UserNo"],
                DepartmentId = (int)reader["DepartmentId"],
                DepartmentName = (string)reader["DepartmentName"],
                FirstName = (string)reader["FirstName"],
                LastName = (string)reader["LastName"],
                AttachmentId = (int)reader["AttachmentId"],
                Url = (string)reader["Url"]
            };
        }

        public User Get(int id)
        {
            using (SqlConnection cn = new SqlConnection(Config.ConnectString))
            {
                SqlCommand cmd = new SqlCommand("GetUserById", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = id;
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    return getForUpdate(reader);
                return null;
            }
        }
        

        public User Get(string no)
        {
            using (SqlConnection cn = new SqlConnection(Config.ConnectString))
            {
                SqlCommand cmd = new SqlCommand("GetUserByNo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserNo", SqlDbType.VarChar).Value = no;
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    return Get(reader);
                return null;
            }
        }
        public List<User> GetUsersByFullName(string keyword)
        {
            using (SqlConnection cn = new SqlConnection(Config.ConnectString))
            {
                SqlCommand cmd = new SqlCommand("GetUsersByFullName", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = keyword;
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                return Gets(reader);
            }
        }
        public List<User> ReportUsers(int? departmentId, int? provinceId)
        {
            using (SqlConnection cn = new SqlConnection(Config.ConnectString))
            {
                SqlCommand cmd = new SqlCommand("ReportUsers", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = departmentId;
                cmd.Parameters.Add("@ProvinceId", SqlDbType.Int).Value = provinceId;
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                return Gets(reader);
            }
        }
        protected override bool SetInsertParams(SqlCommand cmd, User user)
        {
            cmd.CommandText = "InsertUser";
            cmd.Parameters.Add("@UserId", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = user.DepartmentId;
            cmd.Parameters.Add("@ProvinceId", SqlDbType.Int).Value = user.ProvinceId;
            cmd.Parameters.Add("@GroupId", SqlDbType.Int).Value = user.GroupId;
            cmd.Parameters.Add("@AttachmentId", SqlDbType.Int).Value = user.AttachmentId;
            cmd.Parameters.Add("@UserNo", SqlDbType.VarChar).Value = user.UserNo;
            cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = user.FirstName;
            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = user.LastName;
            cmd.Parameters.Add("@Gender", SqlDbType.Bit).Value = user.Gender;
            cmd.Parameters.Add("@BirthDay", SqlDbType.Date).Value = user.BirthDay;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = user.Address;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = user.Phone;
            cmd.Parameters.Add("@IdentityCard", SqlDbType.VarChar).Value = user.IdentityCard;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = user.Email;
            int ret = cmd.ExecuteNonQuery();
            if (ret > 0)
            {
                user.UserId = (int)cmd.Parameters["@UserId"].Value;
                return true;
            }
            return false;
        }

        protected override void SetUpdateParams(SqlCommand cmd, User user)
        {
            cmd.CommandText = "UpdateUser";
            cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = user.UserId;
            cmd.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = user.DepartmentId;
            cmd.Parameters.Add("@ProvinceId", SqlDbType.Int).Value = user.ProvinceId;
            cmd.Parameters.Add("@GroupId", SqlDbType.Int).Value = user.GroupId;
            cmd.Parameters.Add("@AttachmentId", SqlDbType.Int).Value = user.AttachmentId;
            cmd.Parameters.Add("@UserNo", SqlDbType.VarChar).Value = user.UserNo;
            cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = user.FirstName;
            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = user.LastName;
            cmd.Parameters.Add("@Gender", SqlDbType.Bit).Value = user.Gender;
            cmd.Parameters.Add("@BirthDay", SqlDbType.Date).Value = user.BirthDay;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = user.Address;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = user.Phone;
            cmd.Parameters.Add("@IdentityCard", SqlDbType.VarChar).Value = user.IdentityCard;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = user.Email;
        }

        protected override void SetDeleteParams(SqlCommand cmd, User t)
        {
            throw new System.NotImplementedException();
        }

        protected override void SetGetParams(SqlCommand cmd, int id)
        {
            cmd.CommandText = "GetUserById";
            cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = id;
        }
    }
}
