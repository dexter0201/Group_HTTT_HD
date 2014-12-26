using System;
using System.Data.SqlClient;
using System.Data;
using IDAL;
using DTO;
using System.Collections.Generic;
namespace DAL
{
	public class UserEnrollRepository : Repository<UserEnroll>, IUserEnrollRepository
	{
		protected override void SetReturnParam(SqlCommand cmd, UserEnroll obj)
		{
			obj.UserEnrollId = (int)cmd.Parameters["@UserEnrollId"].Value;
		}
		protected override void SetDeleteParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "DeleteUserEnroll";
			cmd.Parameters.Add("@UserEnrollId", SqlDbType.Int).Value = id;
		}
		protected override void SetGetsParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "GetUserEnrolls";
		}
		protected override void SetCountParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "CountUserEnrolls";
		}
		protected override void SetGetParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "GetUserEnrollById";
			cmd.Parameters.Add("@UserEnrollId", SqlDbType.Int).Value = id;
		}
		protected override void SetInsertParam(SqlCommand cmd, UserEnroll obj)
		{
			cmd.CommandText = "InsertUserEnroll";
			cmd.Parameters.Add("@UserEnrollId", SqlDbType.Int).Direction = ParameterDirection.Output;
		}
		protected override void SetUpdateParam(SqlCommand cmd, UserEnroll obj)
		{
			cmd.CommandText = "UpdateUserEnroll";
			cmd.Parameters.Add("@UserEnrollId", SqlDbType.Int).Value = obj.UserEnrollId;
		}
		protected override void SetParam(SqlCommand cmd, UserEnroll obj)
		{
			cmd.Parameters.Add("@CourseId", SqlDbType.Int).Value = obj.CourseId;
			cmd.Parameters.Add("@GroupId", SqlDbType.Int).Value = obj.GroupId;
			cmd.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = obj.DepartmentId;
			cmd.Parameters.Add("@UserNo", SqlDbType.VarChar).Value = obj.UserNo;
			cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = obj.FirstName;
			cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = obj.LastName;
			cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = obj.Email;
			cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = obj.Phone;
			cmd.Parameters.Add("@StatusId", SqlDbType.Int).Value = obj.StatusId;

		}
		protected override UserEnroll GetFromReader(SqlDataReader reader)
		{
			return new UserEnroll { UserEnrollId = (int)reader["UserEnrollId"], CourseId = (int)reader["CourseId"], GroupId = (int)reader["GroupId"], DepartmentId = (int)reader["DepartmentId"], UserNo = (string)reader["UserNo"], FirstName = (string)reader["FirstName"], LastName = (string)reader["LastName"], Email = (string)reader["Email"], Phone = (string)reader["Phone"], CreatedDate = (DateTime)reader["CreatedDate"], StatusId = (int)reader["StatusId"] };
		}

        public bool Insert(IEnumerable<UserEnroll> objs)
        {
            using (SqlConnection cn = new SqlConnection(Setting.ConnString))
            {
                SqlCommand cmd = new SqlCommand("InsertUserEnroll", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserEnrollId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@CourseId", SqlDbType.Int);
                cmd.Parameters.Add("@GroupId", SqlDbType.Int);
                cmd.Parameters.Add("@DepartmentId", SqlDbType.Int);
                cmd.Parameters.Add("@UserNo", SqlDbType.VarChar);
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar);
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Email", SqlDbType.VarChar);
                cmd.Parameters.Add("@Phone", SqlDbType.VarChar);
                cmd.Parameters.Add("@StatusId", SqlDbType.Int);
                cn.Open();
                //SqlTransaction tran = null;
                try
                {
                    //tran = cn.BeginTransaction();
                    //cmd.Transaction = tran;
                    foreach (UserEnroll item in objs)
                    {
                        cmd.Parameters["@CourseId"].Value = item.CourseId;
                        cmd.Parameters["@GroupId"].Value = item.GroupId;
                        cmd.Parameters["@DepartmentId"].Value = item.DepartmentId;
                        cmd.Parameters["@UserNo"].Value = item.UserNo;
                        cmd.Parameters["@FirstName"].Value = item.FirstName;
                        cmd.Parameters["@LastName"].Value = item.LastName;
                        cmd.Parameters["@Email"].Value = item.Email;
                        cmd.Parameters["@Phone"].Value = item.Phone;
                        cmd.Parameters["@StatusId"].Value = item.StatusId;
                        cmd.ExecuteNonQuery();
                        item.UserEnrollId = (int)cmd.Parameters["@UserEnrollId"].Value;
                    }
                    //tran.Commit();
                    return true;
                }
                catch(Exception ex)
                {
                    string str = ex.Message;
                    //tran.Rollback();
                    return false;
                }
            }
        }
    }
}
