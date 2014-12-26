using System;
using System.Data.SqlClient;
using System.Data;
using IDAL;
using DTO;
namespace DAL
{
	public class GroupRepository : Repository<Group>, IGroupRepository
	{
		protected override void SetReturnParam(SqlCommand cmd, Group obj)
		{
			obj.GroupId = (int)cmd.Parameters["@GroupId"].Value;
		}
		protected override void SetDeleteParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "DeleteGroup";
			cmd.Parameters.Add("@GroupId", SqlDbType.Int).Value = id;
		}
		protected override void SetGetsParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "GetGroups";
		}
		protected override void SetCountParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "CountGroups";
		}
		protected override void SetGetParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "GetGroupById";
			cmd.Parameters.Add("@GroupId", SqlDbType.Int).Value = id;
		}
		protected override void SetInsertParam(SqlCommand cmd, Group obj)
		{
			cmd.CommandText = "InsertGroup";
			cmd.Parameters.Add("@GroupId", SqlDbType.Int).Direction = ParameterDirection.Output;
		}
		protected override void SetUpdateParam(SqlCommand cmd, Group obj)
		{
			cmd.CommandText = "UpdateGroup";
			cmd.Parameters.Add("@GroupId", SqlDbType.Int).Value = obj.GroupId;
		}
		protected override void SetParam(SqlCommand cmd, Group obj)
		{
			cmd.Parameters.Add("@GroupName", SqlDbType.NVarChar).Value = obj.GroupName;

		}
		protected override Group GetFromReader(SqlDataReader reader)
		{
			return new Group { GroupId = (int)reader["GroupId"], GroupName = (string)reader["GroupName"] };
		}
	}
}
