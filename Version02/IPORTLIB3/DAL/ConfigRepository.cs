using System;
using System.Data.SqlClient;
using System.Data;
using IDAL;
using DTO;
namespace DAL
{
	public class ConfigRepository : Repository<Config>, IConfigRepository
	{
		protected override void SetReturnParam(SqlCommand cmd, Config obj)
		{
			obj.ConfigId = (int)cmd.Parameters["@ConfigId"].Value;
		}
		protected override void SetDeleteParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "DeleteConfig";
			cmd.Parameters.Add("@ConfigId", SqlDbType.Int).Value = id;
		}
		protected override void SetGetsParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "GetConfigs";
		}
		protected override void SetCountParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "CountConfigs";
		}
		protected override void SetGetParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "GetConfigById";
			cmd.Parameters.Add("@ConfigId", SqlDbType.Int).Value = id;
		}
		protected override void SetInsertParam(SqlCommand cmd, Config obj)
		{
			cmd.CommandText = "InsertConfig";
			cmd.Parameters.Add("@ConfigId", SqlDbType.Int).Direction = ParameterDirection.Output;
		}
		protected override void SetUpdateParam(SqlCommand cmd, Config obj)
		{
			cmd.CommandText = "UpdateConfig";
			cmd.Parameters.Add("@ConfigId", SqlDbType.Int).Value = obj.ConfigId;
		}
		protected override void SetParam(SqlCommand cmd, Config obj)
		{
			cmd.Parameters.Add("@ConfigName", SqlDbType.NVarChar).Value = obj.ConfigName;
			cmd.Parameters.Add("@DataType", SqlDbType.VarChar).Value = obj.DataType;
			cmd.Parameters.Add("@Value", SqlDbType.VarChar).Value = obj.Value;
			cmd.Parameters.Add("@StatusId", SqlDbType.Int).Value = obj.StatusId;

		}
		protected override Config GetFromReader(SqlDataReader reader)
		{
			return new Config { ConfigId = (int)reader["ConfigId"], ConfigName = (string)reader["ConfigName"], DataType = (string)reader["DataType"], Value = (string)reader["Value"], StatusId = (int)reader["StatusId"] };
		}
	}
}
