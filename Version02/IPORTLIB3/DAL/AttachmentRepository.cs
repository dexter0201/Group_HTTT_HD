using System;
using System.Data.SqlClient;
using System.Data;
using DTO;
using System.Collections.Generic;
using IDAL;

namespace DAL
{
	public class AttachmentRepository : Repository<Attachment>, IAttachmentRepository
	{
		protected override void SetReturnParam(SqlCommand cmd, Attachment obj)
		{
			obj.AttachmentId = (int)cmd.Parameters["@AttachmentId"].Value;
		}
		//protected override void SetDeleteParam(SqlCommand cmd, object id)
		//{
		//	cmd.CommandText = "DeleteAttachment";
		//	cmd.Parameters.Add("@AttachmentId", SqlDbType.Int).Value = id;
		//}
		protected override void SetGetsParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "GetAttachments";
		}
		protected override void SetCountParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "CountAttachments";
		}
		//protected override void SetGetParam(SqlCommand cmd, object id)
		//{
		//	cmd.CommandText = "GetAttachmentById";
		//	cmd.Parameters.Add("@AttachmentId", SqlDbType.Int).Value = id;
		//}
		//protected override void SetInsertParam(SqlCommand cmd, Attachment obj)
		//{
		//	cmd.CommandText = "InsertAttachment";
		//	cmd.Parameters.Add("@AttachmentId", SqlDbType.Int).Direction = ParameterDirection.Output;
		//}
		protected override void SetUpdateParam(SqlCommand cmd, Attachment obj)
		{
			cmd.CommandText = "UpdateAttachment";
			cmd.Parameters.Add("@AttachmentId", SqlDbType.Int).Value = obj.AttachmentId;
		}
		protected override void SetParam(SqlCommand cmd, Attachment obj)
		{
            //cmd.Parameters.Add("@Url", SqlDbType.NVarChar).Value = obj.Url;
            //cmd.Parameters.Add("@AttachmentTypeId", SqlDbType.Int).Value = obj.AttachmentTypeId;

		}
		protected override Attachment GetFromReader(SqlDataReader reader)
		{
			return new Attachment {
				AttachmentId = (int)reader["AttachmentId"],
				Url = (string)reader["Url"],
				AttachmentTypeId = (int)reader["AttachmentTypeId"],
				//UserNo = reader["UserNo"] == DBNull.Value ? null : reader["UserNo"].ToString()
                UserNo = reader.GetSchemaTable().Select("ColumnName='UserNo'").Length > 0 && reader["UserNo"].ToString() != "" ? (string)reader["UserNo"] : "Unknown"
			};
		}

        // ================================
		//protected override Attachment Get(System.Data.SqlClient.SqlDataReader reader)
		//{
		//	return new Attachment
		//	{
		//		AttachmentId = (int)reader["AttachmentId"],
		//		AttachmentTypeId = (int)reader["AttachmentTypeId"],
		//		Url = (string)reader["Url"],
		//		UserNo = reader.GetSchemaTable().Select("ColumnName='UserNo'").Length > 0 && reader["UserNo"].ToString() != "" ? (string)reader["UserNo"] : "Unknown"
		//	};
		//}

		//public void Insert(Attachment attachment)
		//{
		//	using (SqlConnection cn = new SqlConnection(Setting.ConnString))
		//	{
		//		SqlCommand cmd = new SqlCommand("InsertAttachment", cn);
		//		cmd.CommandType = CommandType.StoredProcedure;
		//		cmd.Parameters.Add("@AttachmentId", SqlDbType.Int).Direction = ParameterDirection.Output;
		//		cmd.Parameters.Add("@AttachmentTypeId", SqlDbType.Int).Value = attachment.AttachmentTypeId;
		//		cmd.Parameters.Add("@Url", SqlDbType.NVarChar).Value = attachment.Url;
		//		cn.Open();
		//		cmd.ExecuteNonQuery();
		//		attachment.AttachmentId = (int)cmd.Parameters["@AttachmentId"].Value;
		//	}
		//}

		protected override void SetInsertParam(SqlCommand cmd, Attachment attachment)
        {
            cmd.CommandText = "InsertAttachment";
            cmd.Parameters.Add("@AttachmentId", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@AttachmentTypeId", SqlDbType.Int).Value = attachment.AttachmentTypeId;
            cmd.Parameters.Add("@Url", SqlDbType.NVarChar).Value = attachment.Url;
            //int ret = cmd.ExecuteNonQuery();
            //if (ret > 0)
            //{
            //    attachment.AttachmentId = (int)cmd.Parameters["@AttachmentId"].Value;
            //}
        }


        /// <summary>
        /// set parameters for deleteAttachment
        /// </summary>
        /// <param name="cmd">SqlCommand</param>
        /// <param name="id">int</param>
		protected override void SetDeleteParam(SqlCommand cmd, object id)
        {
            cmd.CommandText = "DeleteAttachmentById";
            cmd.Parameters.Add("@AttachmentId", SqlDbType.Int).Value = id;
        }

		protected override void SetGetParam(SqlCommand cmd, object id)
        {
            cmd.CommandText = "GetAttachmentById";
            cmd.Parameters.Add("@AttachmentId", SqlDbType.Int).Value = id;
        }

		public IEnumerable<Attachment> Gets(int pageSize, int pageIndex)
        {
            using (SqlConnection cn = new SqlConnection(Setting.ConnString))
            {
                SqlCommand cmd = new SqlCommand("GetAttachments", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
                //cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                return Gets(reader);
            }
        }
	}
}
