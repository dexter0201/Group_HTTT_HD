using System;
using System.Data.SqlClient;
using System.Data;
using IDAL;
using DTO;
namespace DAL
{
	public class TopicRepository : Repository<Topic>, ITopicRepository
	{
		protected override void SetReturnParam(SqlCommand cmd, Topic obj)
		{
			obj.TopicId = (int)cmd.Parameters["@TopicId"].Value;
		}
		protected override void SetDeleteParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "DeleteTopic";
			cmd.Parameters.Add("@TopicId", SqlDbType.Int).Value = id;
		}
		protected override void SetGetsParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "GetTopics";
		}
		protected override void SetCountParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "CountTopics";
		}
		protected override void SetGetParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "GetTopicById";
			cmd.Parameters.Add("@TopicId", SqlDbType.Int).Value = id;
		}
		protected override void SetInsertParam(SqlCommand cmd, Topic obj)
		{
			cmd.CommandText = "InsertTopic";
			cmd.Parameters.Add("@TopicId", SqlDbType.Int).Direction = ParameterDirection.Output;
		}
		protected override void SetUpdateParam(SqlCommand cmd, Topic obj)
		{
			cmd.CommandText = "UpdateTopic";
			cmd.Parameters.Add("@TopicId", SqlDbType.Int).Value = obj.TopicId;
		}
		protected override void SetParam(SqlCommand cmd, Topic obj)
		{
			cmd.Parameters.Add("@TopicName", SqlDbType.NVarChar).Value = obj.TopicName;
			cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = obj.Note;

		}
		protected override Topic GetFromReader(SqlDataReader reader)
		{
			return new Topic { TopicId = (int)reader["TopicId"], TopicName = (string)reader["TopicName"], Note = reader["Note"] == DBNull.Value ? null : (string)reader["Note"] };
		}
	}
}
