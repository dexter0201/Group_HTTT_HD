using System;
using System.Data.SqlClient;
using System.Data;
using IDAL;
using DTO;
namespace DAL
{
	public class AttachmentTypeRepository : Repository<AttachmentType>, IAttachmentTypeRepository
	{
		protected override void SetReturnParam(SqlCommand cmd, AttachmentType obj)
		{
			obj.AttachmentTypeId = (int)cmd.Parameters["@AttachmentTypeId"].Value;
		}
		protected override void SetDeleteParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "DeleteAttachmentType";
			cmd.Parameters.Add("@AttachmentTypeId", SqlDbType.Int).Value = id;
		}
		protected override void SetGetsParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "GetAttachmentTypes";
		}
		protected override void SetCountParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "CountAttachmentTypes";
		}
		protected override void SetGetParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "GetAttachmentTypeById";
			cmd.Parameters.Add("@AttachmentTypeId", SqlDbType.Int).Value = id;
		}
		protected override void SetInsertParam(SqlCommand cmd, AttachmentType obj)
		{
			cmd.CommandText = "InsertAttachmentType";
			cmd.Parameters.Add("@AttachmentTypeId", SqlDbType.Int).Direction = ParameterDirection.Output;
		}
		protected override void SetUpdateParam(SqlCommand cmd, AttachmentType obj)
		{
			cmd.CommandText = "UpdateAttachmentType";
			cmd.Parameters.Add("@AttachmentTypeId", SqlDbType.Int).Value = obj.AttachmentTypeId;
		}
		protected override void SetParam(SqlCommand cmd, AttachmentType obj)
		{
			cmd.Parameters.Add("@AttachmentTypeName", SqlDbType.NVarChar).Value = obj.AttachmentTypeName;

		}
		protected override AttachmentType GetFromReader(SqlDataReader reader)
		{
			return new AttachmentType { AttachmentTypeId = (int)reader["AttachmentTypeId"], AttachmentTypeName = reader["AttachmentTypeName"] == DBNull.Value ? null : (string)reader["AttachmentTypeName"] };
		}
	}
}
