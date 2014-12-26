using System;
using System.Data.SqlClient;
using System.Data;
using IDAL;
using DTO;
namespace DAL
{
	public class PublisherRepository : Repository<Publisher>, IPublisherRepository
	{
		protected override void SetReturnParam(SqlCommand cmd, Publisher obj)
		{
			obj.PublisherId = (int)cmd.Parameters["@PublisherId"].Value;
		}
		protected override void SetDeleteParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "DeletePublisher";
			cmd.Parameters.Add("@PublisherId", SqlDbType.Int).Value = id;
		}
		protected override void SetGetsParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "GetPublishers";
		}
		protected override void SetCountParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "CountPublishers";
		}
		protected override void SetGetParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "GetPublisherById";
			cmd.Parameters.Add("@PublisherId", SqlDbType.Int).Value = id;
		}
		protected override void SetInsertParam(SqlCommand cmd, Publisher obj)
		{
			cmd.CommandText = "InsertPublisher";
			cmd.Parameters.Add("@PublisherId", SqlDbType.Int).Direction = ParameterDirection.Output;
		}
		protected override void SetUpdateParam(SqlCommand cmd, Publisher obj)
		{
			cmd.CommandText = "UpdatePublisher";
			cmd.Parameters.Add("@PublisherId", SqlDbType.Int).Value = obj.PublisherId;
		}
		protected override void SetParam(SqlCommand cmd, Publisher obj)
		{
			cmd.Parameters.Add("@PublisherName", SqlDbType.NVarChar).Value = obj.PublisherName;
			cmd.Parameters.Add("@Note", SqlDbType.VarChar).Value = obj.Note;

		}
		protected override Publisher GetFromReader(SqlDataReader reader)
		{
			return new Publisher { PublisherId = (int)reader["PublisherId"], PublisherName = (string)reader["PublisherName"], Note = reader["Note"] == DBNull.Value ? null : (string)reader["Note"] };
		}
	}
}
