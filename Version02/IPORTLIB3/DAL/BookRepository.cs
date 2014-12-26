using System;
using System.Data.SqlClient;
using System.Data;
using IDAL;
using DTO;
namespace DAL
{
	public class BookRepository : Repository<Book>, IBookRepository
	{
		protected override void SetReturnParam(SqlCommand cmd, Book obj)
		{
			obj.BookId = (int)cmd.Parameters["@BookId"].Value;
		}
		protected override void SetDeleteParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "DeleteBook";
			cmd.Parameters.Add("@BookId", SqlDbType.Int).Value = id;
		}
		protected override void SetGetsParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "GetBooks";
		}
		protected override void SetCountParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "CountBooks";
		}
		protected override void SetGetParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "GetBookById";
			cmd.Parameters.Add("@BookId", SqlDbType.Int).Value = id;
		}
		protected override void SetInsertParam(SqlCommand cmd, Book obj)
		{
			cmd.CommandText = "InsertBook";
			cmd.Parameters.Add("@BookId", SqlDbType.Int).Direction = ParameterDirection.Output;
		}
		protected override void SetUpdateParam(SqlCommand cmd, Book obj)
		{
			cmd.CommandText = "UpdateBook";
			cmd.Parameters.Add("@BookId", SqlDbType.Int).Value = obj.BookId;
		}
		protected override void SetParam(SqlCommand cmd, Book obj)
		{
			cmd.Parameters.Add("@PublicationId", SqlDbType.Int).Value = obj.PublicationId;
			cmd.Parameters.Add("@StoreId", SqlDbType.Int).Value = obj.StoreId;
			cmd.Parameters.Add("@NumberSpecific", SqlDbType.VarChar).Value = obj.NumberSpecific;

		}
		protected override Book GetFromReader(SqlDataReader reader)
		{
			return new Book { BookId = (int)reader["BookId"], PublicationId = (int)reader["PublicationId"], StoreId = (int)reader["StoreId"], NumberSpecific = (string)reader["NumberSpecific"], Status = (bool)reader["Status"] };
		}
	}
}
