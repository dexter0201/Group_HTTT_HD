using DTO;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class AttachmentProvider : BaseProvider<Attachment>
    {
        protected override Attachment Get(System.Data.SqlClient.SqlDataReader reader)
        {
            return new Attachment {
				AttachmentId = (int)reader["AttachmentId"],
				AttachmentTypeId = (int)reader["AttachmentTypeId"],
				Url = (string)reader["Url"],
				UserNo = reader["UserNo"].ToString() != "" ? (string)reader["UserNo"] : "Unknown"
			};
        }

        public void Insert(Attachment attachment)
        {
            using (SqlConnection cn = new SqlConnection(Config.ConnectString))
            {
                SqlCommand cmd = new SqlCommand("InsertAttachment", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@AttachmentId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@AttachmentTypeId", SqlDbType.Int).Value = attachment.AttachmentTypeId;
                cmd.Parameters.Add("@Url", SqlDbType.NVarChar).Value = attachment.Url;
                cn.Open();
                cmd.ExecuteNonQuery();
                attachment.AttachmentId = (int)cmd.Parameters["@AttachmentId"].Value;
            }
        }

        protected override bool SetInsertParams(SqlCommand cmd, Attachment attachment)
        {
            cmd.CommandText = "InsertAttachment";
            cmd.Parameters.Add("@AttachmentId", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@AttachmentTypeId", SqlDbType.Int).Value = attachment.AttachmentTypeId;
            cmd.Parameters.Add("@Url", SqlDbType.NVarChar).Value = attachment.Url;
            int ret = cmd.ExecuteNonQuery();
            if (ret > 0)
            {
                attachment.AttachmentId = (int)cmd.Parameters["@AttachmentId"].Value;
                return true;
            }
            return false;
        }

        protected override void SetUpdateParams(SqlCommand cmd, Attachment t)
        {
            throw new System.NotImplementedException();
        }

		/// <summary>
		/// set parameters for deleteAttachment
		/// </summary>
		/// <param name="cmd">SqlCommand</param>
		/// <param name="id">int</param>
        protected override void SetDeleteParams(SqlCommand cmd, int id)
        {
			cmd.CommandText = "DeleteAttachmentById";
			cmd.Parameters.Add("@AttachmentId", SqlDbType.Int).Value = id;
        }

        protected override void SetGetParams(SqlCommand cmd, int id)
        {
            throw new System.NotImplementedException();
        }

		public List<Attachment> Gets(int pageSize, int pageIndex)
		{
			using (SqlConnection cn = new SqlConnection(Config.ConnectString))
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
