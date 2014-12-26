using System;
using System.Data.SqlClient;
using System.Data;
using IDAL;
using DTO;
namespace DAL
{
	public class AuthorRepository : Repository<Author>, IAuthorRepository
	{
		protected override void SetReturnParam(SqlCommand cmd, Author obj)
		{
			obj.AuthorId = (int)cmd.Parameters["@AuthorId"].Value;
		}
		protected override void SetDeleteParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "DeleteAuthor";
			cmd.Parameters.Add("@AuthorId", SqlDbType.Int).Value = id;
		}
		protected override void SetGetsParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "GetAuthors";
			cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = obj;
            cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = Setting.PageSize;
		}
		protected override void SetCountParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "CountAuthors";
		}
		protected override void SetGetParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "GetAuthorById";
			cmd.Parameters.Add("@AuthorId", SqlDbType.Int).Value = id;
		}
		protected override void SetInsertParam(SqlCommand cmd, Author obj)
		{
			cmd.CommandText = "InsertAuthor";
			cmd.Parameters.Add("@AuthorId", SqlDbType.Int).Direction = ParameterDirection.Output;
		}
		protected override void SetUpdateParam(SqlCommand cmd, Author obj)
		{
			cmd.CommandText = "UpdateAuthor";
			cmd.Parameters.Add("@AuthorId", SqlDbType.Int).Value = obj.AuthorId;
		}
		protected override void SetParam(SqlCommand cmd, Author obj)
		{
			cmd.Parameters.Add("@AuthorNo", SqlDbType.VarChar).Value = obj.AuthorNo;
			cmd.Parameters.Add("@AuthorName", SqlDbType.NVarChar).Value = obj.AuthorName;
			cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = obj.Note;

		}
		protected override Author GetFromReader(SqlDataReader reader)
		{
			return new Author { AuthorId = (int)reader["AuthorId"], AuthorNo = reader["AuthorNo"] == DBNull.Value ? null : (string)reader["AuthorNo"], AuthorName = (string)reader["AuthorName"], Note = reader["Note"] == DBNull.Value ? null : (string)reader["Note"] };
		}
	}
}
