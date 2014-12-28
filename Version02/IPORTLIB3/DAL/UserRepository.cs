using System;
using System.Data.SqlClient;
using System.Data;
using IDAL;
using DTO;
using System.Collections.Generic;
namespace DAL
{
	public class UserRepository : Repository<User>, IUserRepository
	{
		protected override void SetReturnParam(SqlCommand cmd, User obj)
		{
			obj.UserId = (int)cmd.Parameters["@UserId"].Value;
		}
		protected override void SetDeleteParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "DeleteUser";
			cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = id;
		}
		protected override void SetGetsParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "GetUsers";
            cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = obj;
            cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = Setting.PageSize;
		}
		protected override void SetCountParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "CountUsers";
		}
		protected override void SetGetParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "GetUserById";
			cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = id;
		}
		protected override void SetInsertParam(SqlCommand cmd, User obj)
		{
			cmd.CommandText = "InsertUser";
			cmd.Parameters.Add("@UserId", SqlDbType.Int).Direction = ParameterDirection.Output;
		}
		protected override void SetUpdateParam(SqlCommand cmd, User obj)
		{
			cmd.CommandText = "UpdateUser";
			cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = obj.UserId;
		}
		protected override void SetParam(SqlCommand cmd, User obj)
		{
			cmd.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = obj.DepartmentId;
			cmd.Parameters.Add("@ProvinceId", SqlDbType.Int).Value = obj.ProvinceId;
			cmd.Parameters.Add("@GroupId", SqlDbType.Int).Value = obj.GroupId;
			cmd.Parameters.Add("@AttachmentId", SqlDbType.Int).Value = obj.AttachmentId;
			cmd.Parameters.Add("@UserNo", SqlDbType.VarChar).Value = obj.UserNo;
			cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = obj.FirstName;
			cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = obj.LastName;
			cmd.Parameters.Add("@Gender", SqlDbType.Bit).Value = obj.Gender;
			cmd.Parameters.Add("@BirthDay", SqlDbType.Date).Value = obj.BirthDay;
			cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = obj.Address;
			cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = obj.Phone;
			cmd.Parameters.Add("@IdentityCard", SqlDbType.VarChar).Value = obj.IdentityCard;
			cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = obj.Email;

		}
		protected override User GetFromReader(SqlDataReader reader)
		{
			return new User {
                UserId = (int)reader["UserId"],
                DepartmentId = reader["DepartmentId"].ToString() != "" ? (int)reader["DepartmentId"] : -1,
                ProvinceId = reader["ProvinceId"] == DBNull.Value ? null : (int?)reader["ProvinceId"],
                GroupId = (int)reader["GroupId"],
                AttachmentId = reader["AttachmentId"] == DBNull.Value ? null : (int?)reader["AttachmentId"],
                UserNo = (string)reader["UserNo"],
                Url = reader.GetSchemaTable().Select("ColumnName='Url'").Length > 0 && reader["Url"].ToString() != "" ? (string)reader["Url"] : "",
                FirstName = (string)reader["FirstName"],
                LastName = (string)reader["LastName"],
                Gender = reader["Gender"] == DBNull.Value ? null : (bool?)reader["Gender"],
                BirthDay = reader["BirthDay"] == DBNull.Value ? DateTime.Now : (DateTime)reader["BirthDay"],
                Address = reader["Address"] == DBNull.Value ? null : (string)reader["Address"],
                Phone = reader["Phone"] == DBNull.Value ? null : (string)reader["Phone"],
                IdentityCard = reader["IdentityCard"] == DBNull.Value ? null : (string)reader["IdentityCard"],
                Email = reader["Email"] == DBNull.Value ? null : (string)reader["Email"]
            };
		}
        /* -------- Report Users -----------*/
        public List<ReportUsersLoan> ReportUsersLoan()
        {
            using (SqlConnection cn = new SqlConnection(Setting.ConnString))
            {

                SqlCommand cmd = new SqlCommand("ReportUsersLoan", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<ReportUsersLoan> list = new List<ReportUsersLoan>();
                while (reader.Read())
                {
                    list.Add(new ReportUsersLoan
                    {
                        Year = reader["Year"].ToString(),
                        Count = (int)reader["CountUsers"]
                    });
                }
                return list;
            }
        }

        public IEnumerable<User> GetReportUsersLoanByYear(string year)
        {
            using (SqlConnection cn = new SqlConnection(Setting.ConnString))
            {

                SqlCommand cmd = new SqlCommand("GetReportUsersLoanByYear", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<User> list = new List<User>();
                while (reader.Read())
                {
                    list.Add(new User
                    {
                        UserNo = (string)reader["UserNo"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        CountLoan = (int)reader["CountLoan"]
                    });
                }
                return list;
            }
        }
        public IEnumerable<Store> ReportLoansPercent()
        {
            using (SqlConnection cn = new SqlConnection(Setting.ConnString))
            {

                SqlCommand cmd = new SqlCommand("ReportLoansPercent", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Store> list = new List<Store>();
                while (reader.Read())
                {
                    list.Add(new Store
                    {
                        StoreName = (string)reader["storename"],
                        LoanPercent = decimal.Parse(reader["LoanPercent"].ToString())
                    });
                }
                return list;
            }
        }

        public List<ReportOutOfDateLoans> GetReportOutOfDateLoans()
        {
            using (SqlConnection cn = new SqlConnection(Setting.ConnString))
            {

                SqlCommand cmd = new SqlCommand("GetReportOutOfDateLoans", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<ReportOutOfDateLoans> list = new List<ReportOutOfDateLoans>();
                while (reader.Read())
                {
                    list.Add(new ReportOutOfDateLoans
                    {
                        UserNo = (string)reader["UserNo"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        DateLoan = DateTime.Parse(reader["DateLoan"].ToString()).ToString("dd/MM/yyyy"),
                        DatePay = DateTime.Parse(reader["DatePay"].ToString()).ToString("dd/MM/yyyy"),
                        NumberSpecific = (string)reader["NumberSpecific"],
                        Title = (string)reader["Title"]
                    });
                }
                return list;
            }
        }

        /* -------- Theo dõi mượn sách -----------*/
        public IEnumerable<User> GetUsersLoan()
        {
            using (SqlConnection cn = new SqlConnection(Setting.ConnString))
            {
                SqlCommand cmd = new SqlCommand("GetUsersLoan", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                return Gets2(reader);
            }

        }
        public IEnumerable<User> Gets2(SqlDataReader reader)
        {
            List<User> list = new List<User>();
            while (reader.Read())
            {
                list.Add(new User { UserId = (int)reader["UserId"], DepartmentName = (string)reader["DepartmentName"], UserNo = (string)reader["UserNo"], FirstName = (string)reader["FirstName"], LastName = (string)reader["LastName"] });
            }
            return list;
        }
        public IEnumerable<User> GetUsersLoanByUserNo(string userno)
        {
            using (SqlConnection cn = new SqlConnection(Setting.ConnString))
            {
                SqlCommand cmd = new SqlCommand("GetUserLoanByUserNo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserNo", SqlDbType.VarChar).Value = userno;
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                return Gets2(reader);
            }

        }
        public IEnumerable<User> GetUsersLoanByBookNumber(string book)
        {
            using (SqlConnection cn = new SqlConnection(Setting.ConnString))
            {
                SqlCommand cmd = new SqlCommand("GetUserLoanByBookNum", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@booknum", SqlDbType.VarChar).Value = book;
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                return Gets2(reader);
            }

        }
        public List<ReportOutOfDateLoans> GetDetailLoanByUserid(int id)
        {
            using (SqlConnection cn = new SqlConnection(Setting.ConnString))
            {
                SqlCommand cmd = new SqlCommand("GetDetailLoanByUserid", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<ReportOutOfDateLoans> list = new List<ReportOutOfDateLoans>();
                while (reader.Read())
                {
                    list.Add(new ReportOutOfDateLoans
                    {
                        UserNo = (string)reader["UserNo"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        DateLoan = DateTime.Parse(reader["DateLoan"].ToString()).ToString("dd/MM/yyyy"),
                        DatePay = DateTime.Parse(reader["DatePay"].ToString()).ToString("dd/MM/yyyy"),
                        NumberSpecific = (string)reader["NumberSpecific"],
                        Title = (string)reader["Title"],
                        DepartmentName = (string)reader["DepartmentName"],
                        Image = reader["Url"].ToString()
                    });
                }
                return list;
            }
        }
        public IEnumerable<User> ReportUsers(int? departmentId, int? provinceId)
        {
            using (SqlConnection cn = new SqlConnection(Setting.ConnString))
            {
                SqlCommand cmd = new SqlCommand("ReportUsers", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = departmentId;
                cmd.Parameters.Add("@ProvinceId", SqlDbType.Int).Value = provinceId;
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                return GetsFromReader(reader);
            }
        }
        public IEnumerable <User> GetUsersByFullName(string keyword)
        {
            using (SqlConnection cn = new SqlConnection(Setting.ConnString))
            {
                SqlCommand cmd = new SqlCommand("GetUsersByFullName", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = keyword;
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                return Gets2(reader);
            }
        }
    }
}
