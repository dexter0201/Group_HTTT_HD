using System;
using System.Data.SqlClient;
using System.Data;
using IDAL;
using DTO;
namespace DAL
{
	public class CardUserRepository : Repository<CardUser>, ICardUserRepository
	{
		protected override void SetReturnParam(SqlCommand cmd, CardUser obj)
		{
			obj.CardUserId = (int)cmd.Parameters["@CardUserId"].Value;
		}
		protected override void SetDeleteParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "DeleteCardUser";
			cmd.Parameters.Add("@CardUserId", SqlDbType.Int).Value = id;
		}
		protected override void SetGetsParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "GetCardUsers";
		}
		protected override void SetCountParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "CountCardUsers";
		}
		protected override void SetGetParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "GetCardUserById";
			cmd.Parameters.Add("@CardUserId", SqlDbType.Int).Value = id;
		}
		protected override void SetInsertParam(SqlCommand cmd, CardUser obj)
		{
			cmd.CommandText = "InsertCardUser";
			cmd.Parameters.Add("@CardUserId", SqlDbType.Int).Direction = ParameterDirection.Output;
		}
		protected override void SetUpdateParam(SqlCommand cmd, CardUser obj)
		{
			cmd.CommandText = "UpdateCardUser";
			cmd.Parameters.Add("@CardUserId", SqlDbType.Int).Value = obj.CardUserId;
		}
		protected override void SetParam(SqlCommand cmd, CardUser obj)
		{
			cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = obj.UserId;
			cmd.Parameters.Add("@CardUserNo", SqlDbType.VarChar).Value = obj.CardUserNo;
			cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = obj.UserName;
			cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = obj.Password;
			cmd.Parameters.Add("@DueDate", SqlDbType.Date).Value = obj.DueDate;

		}
		protected override CardUser GetFromReader(SqlDataReader reader)
		{
			return new CardUser { CardUserId = (int)reader["CardUserId"], UserId = (int)reader["UserId"], CardUserNo = (string)reader["CardUserNo"], UserName = (string)reader["UserName"], Password = (string)reader["Password"], Status = (bool)reader["Status"], DueDate = (DateTime)reader["DueDate"] };
		}
	}
}
