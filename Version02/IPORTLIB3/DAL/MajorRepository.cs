using System;
using System.Data.SqlClient;
using System.Data;
using IDAL;
using DTO;
namespace DAL
{
	public class MajorRepository : Repository<Major>, IMajorRepository
	{
		protected override void SetReturnParam(SqlCommand cmd, Major obj)
		{
			obj.MajorId = (int)cmd.Parameters["@MajorId"].Value;
		}
		protected override void SetDeleteParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "DeleteMajor";
			cmd.Parameters.Add("@MajorId", SqlDbType.Int).Value = id;
		}
		protected override void SetGetsParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "GetMajors";
		}
		protected override void SetCountParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "CountMajors";
		}
		protected override void SetGetParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "GetMajorById";
			cmd.Parameters.Add("@MajorId", SqlDbType.Int).Value = id;
		}
		protected override void SetInsertParam(SqlCommand cmd, Major obj)
		{
			cmd.CommandText = "InsertMajor";
			cmd.Parameters.Add("@MajorId", SqlDbType.Int).Direction = ParameterDirection.Output;
		}
		protected override void SetUpdateParam(SqlCommand cmd, Major obj)
		{
			cmd.CommandText = "UpdateMajor";
			cmd.Parameters.Add("@MajorId", SqlDbType.Int).Value = obj.MajorId;
		}
		protected override void SetParam(SqlCommand cmd, Major obj)
		{
			cmd.Parameters.Add("@MajorName", SqlDbType.NVarChar).Value = obj.MajorName;

		}
		protected override Major GetFromReader(SqlDataReader reader)
		{
			return new Major { MajorId = (int)reader["MajorId"], MajorName = (string)reader["MajorName"] };
		}
	}
}
