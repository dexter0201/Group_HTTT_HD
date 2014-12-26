using System;
using System.Data.SqlClient;
using System.Data;
using IDAL;
using DTO;
namespace DAL
{
	public class StatusRepository : Repository<Status>, IStatusRepository
	{
		protected override void SetReturnParam(SqlCommand cmd, Status obj)
		{
			obj.StatusId = (int)cmd.Parameters["@StatusId"].Value;
		}
		protected override void SetDeleteParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "DeleteStatus";
			cmd.Parameters.Add("@StatusId", SqlDbType.Int).Value = id;
		}
		protected override void SetGetsParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "GetStatuses";
		}
		protected override void SetCountParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "CountStatuses";
		}
		protected override void SetGetParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "GetStatusById";
			cmd.Parameters.Add("@StatusId", SqlDbType.Int).Value = id;
		}
		protected override void SetInsertParam(SqlCommand cmd, Status obj)
		{
			cmd.CommandText = "InsertStatus";
			cmd.Parameters.Add("@StatusId", SqlDbType.Int).Direction = ParameterDirection.Output;
		}
		protected override void SetUpdateParam(SqlCommand cmd, Status obj)
		{
			cmd.CommandText = "UpdateStatus";
			cmd.Parameters.Add("@StatusId", SqlDbType.Int).Value = obj.StatusId;
		}
		protected override void SetParam(SqlCommand cmd, Status obj)
		{
			cmd.Parameters.Add("@StatusName", SqlDbType.NVarChar).Value = obj.StatusName;

		}
		protected override Status GetFromReader(SqlDataReader reader)
		{
			return new Status { StatusId = (int)reader["StatusId"], StatusName = (string)reader["StatusName"] };
		}
	}
}
