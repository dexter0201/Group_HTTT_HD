using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
namespace DAL
{
    public class UserEnrollmentProvider : BaseProvider<UserEnrollment>
    {
        protected override void SetDeleteParams(System.Data.SqlClient.SqlCommand cmd, int id)
        {
            throw new NotImplementedException();
        }

        protected override void SetGetParams(System.Data.SqlClient.SqlCommand cmd, int id)
        {
            throw new NotImplementedException();
        }

        protected override UserEnrollment Get(System.Data.SqlClient.SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
        //protected override bool SetInsertParams(SqlCommand cmd, User user)
        //{
        //    cmd.CommandText = "InsertUser";
        //    cmd.Parameters.Add("@UserId", SqlDbType.Int).Direction = ParameterDirection.Output;
        //    cmd.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = user.DepartmentId;
        //    cmd.Parameters.Add("@ProvinceId", SqlDbType.Int).Value = user.ProvinceId;
        //    cmd.Parameters.Add("@GroupId", SqlDbType.Int).Value = user.GroupId;
        //    cmd.Parameters.Add("@AttachmentId", SqlDbType.Int).Value = user.AttachmentId;
        //    cmd.Parameters.Add("@UserNo", SqlDbType.VarChar).Value = user.UserNo;
        //    cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = user.FirstName;
        //    cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = user.LastName;
        //    cmd.Parameters.Add("@Gender", SqlDbType.Bit).Value = user.Gender;
        //    cmd.Parameters.Add("@BirthDay", SqlDbType.Date).Value = user.BirthDay;
        //    cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = user.Address;
        //    cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = user.Phone;
        //    cmd.Parameters.Add("@IdentityCard", SqlDbType.VarChar).Value = user.IdentityCard;
        //    cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = user.Email;
        //    int ret = cmd.ExecuteNonQuery();
        //    if (ret > 0)
        //    {
        //        user.UserId = (int)cmd.Parameters["@UserId"].Value;
        //        return true;
        //    }
        //    return false;
        //}

        protected override bool SetInsertParams(SqlCommand cmd, UserEnrollment UE)
        {
            cmd.CommandText = "InsertUserEnrollment";
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UE.UserID;
            return true;
        }

        protected override void SetUpdateParams(System.Data.SqlClient.SqlCommand cmd, UserEnrollment t)
        {
            throw new NotImplementedException();
        }
    }
}
