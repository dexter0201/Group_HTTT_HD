using System;
using System.Data.SqlClient;
using System.Data;
using IDAL;
using DTO;
namespace DAL
{
	public class PublicationTypeRepository : Repository<PublicationType>, IPublicationTypeRepository
	{
		protected override void SetReturnParam(SqlCommand cmd, PublicationType obj)
		{
			obj.PublicationTypeId = (int)cmd.Parameters["@PublicationTypeId"].Value;
		}
		protected override void SetDeleteParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "DeletePublicationType";
			cmd.Parameters.Add("@PublicationTypeId", SqlDbType.Int).Value = id;
		}
		protected override void SetGetsParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "GetPublicationTypes";
		}
		protected override void SetCountParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "CountPublicationTypes";
		}
		protected override void SetGetParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "GetPublicationTypeById";
			cmd.Parameters.Add("@PublicationTypeId", SqlDbType.Int).Value = id;
		}
		protected override void SetInsertParam(SqlCommand cmd, PublicationType obj)
		{
			cmd.CommandText = "InsertPublicationType";
			cmd.Parameters.Add("@PublicationTypeId", SqlDbType.Int).Direction = ParameterDirection.Output;
		}
		protected override void SetUpdateParam(SqlCommand cmd, PublicationType obj)
		{
			cmd.CommandText = "UpdatePublicationType";
			cmd.Parameters.Add("@PublicationTypeId", SqlDbType.Int).Value = obj.PublicationTypeId;
		}
		protected override void SetParam(SqlCommand cmd, PublicationType obj)
		{
			cmd.Parameters.Add("@PublicationTypeName", SqlDbType.NVarChar).Value = obj.PublicationTypeName;

		}
		protected override PublicationType GetFromReader(SqlDataReader reader)
		{
			return new PublicationType { PublicationTypeId = (int)reader["PublicationTypeId"], PublicationTypeName = (string)reader["PublicationTypeName"] };
		}
	}
}
