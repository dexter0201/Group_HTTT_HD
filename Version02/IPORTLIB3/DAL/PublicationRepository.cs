using System;
using System.Data.SqlClient;
using System.Data;
using IDAL;
using DTO;
namespace DAL
{
	public class PublicationRepository : Repository<Publication>, IPublicationRepository
	{
		protected override void SetReturnParam(SqlCommand cmd, Publication obj)
		{
			obj.PublicationId = (int)cmd.Parameters["@PublicationId"].Value;
		}
		protected override void SetDeleteParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "DeletePublication";
			cmd.Parameters.Add("@PublicationId", SqlDbType.Int).Value = id;
		}
		protected override void SetGetsParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "GetPublications";
		}
		protected override void SetCountParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "CountPublications";
		}
		protected override void SetGetParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "GetPublicationById";
			cmd.Parameters.Add("@PublicationId", SqlDbType.Int).Value = id;
		}
		protected override void SetInsertParam(SqlCommand cmd, Publication obj)
		{
			cmd.CommandText = "InsertPublication";
			cmd.Parameters.Add("@PublicationId", SqlDbType.Int).Direction = ParameterDirection.Output;
		}
		protected override void SetUpdateParam(SqlCommand cmd, Publication obj)
		{
			cmd.CommandText = "UpdatePublication";
			cmd.Parameters.Add("@PublicationId", SqlDbType.Int).Value = obj.PublicationId;
		}
		protected override void SetParam(SqlCommand cmd, Publication obj)
		{
			cmd.Parameters.Add("@TopicId", SqlDbType.Int).Value = obj.TopicId;
			cmd.Parameters.Add("@AuthorId", SqlDbType.Int).Value = obj.AuthorId;
			cmd.Parameters.Add("@PublisherId", SqlDbType.Int).Value = obj.PublisherId;
			cmd.Parameters.Add("@PublicationTypeId", SqlDbType.Int).Value = obj.PublicationTypeId;
			cmd.Parameters.Add("@MajorId", SqlDbType.Int).Value = obj.MajorId;
			cmd.Parameters.Add("@LanguageId", SqlDbType.Int).Value = obj.LanguageId;
			cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = obj.Title;
			cmd.Parameters.Add("@SubTitle", SqlDbType.NVarChar).Value = obj.SubTitle;
			cmd.Parameters.Add("@PublisherYear", SqlDbType.Int).Value = obj.PublisherYear;
			cmd.Parameters.Add("@Edition", SqlDbType.Int).Value = obj.Edition;
			cmd.Parameters.Add("@Copyright", SqlDbType.NVarChar).Value = obj.Copyright;
			cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = obj.Description;
			cmd.Parameters.Add("@Size", SqlDbType.VarChar).Value = obj.Size;
			cmd.Parameters.Add("@UnitId", SqlDbType.Int).Value = obj.UnitId;
			cmd.Parameters.Add("@Price", SqlDbType.Int).Value = obj.Price;
			cmd.Parameters.Add("@CurrencyId", SqlDbType.Int).Value = obj.CurrencyId;
			cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = obj.Quantity;
			cmd.Parameters.Add("@NumberDewey", SqlDbType.VarChar).Value = obj.NumberDewey;
			cmd.Parameters.Add("@ISBN", SqlDbType.VarChar).Value = obj.ISBN;
			cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = obj.Note;

		}
		protected override Publication GetFromReader(SqlDataReader reader)
		{
			return new Publication { PublicationId = (int)reader["PublicationId"], TopicId = (int)reader["TopicId"], AuthorId = (int)reader["AuthorId"], PublisherId = (int)reader["PublisherId"], PublicationTypeId = (int)reader["PublicationTypeId"], MajorId = (int)reader["MajorId"], LanguageId = (int)reader["LanguageId"], Title = (string)reader["Title"], SubTitle = reader["SubTitle"] == DBNull.Value ? null : (string)reader["SubTitle"], PublisherYear = (int)reader["PublisherYear"], Edition = reader["Edition"] == DBNull.Value ? null : (int?)reader["Edition"], Copyright = reader["Copyright"] == DBNull.Value ? null : (string)reader["Copyright"], Description = reader["Description"] == DBNull.Value ? null : (string)reader["Description"], Size = reader["Size"] == DBNull.Value ? null : (string)reader["Size"], UnitId = (int)reader["UnitId"], Price = (int)reader["Price"], CurrencyId = (int)reader["CurrencyId"], Quantity = (int)reader["Quantity"], NumberDewey = reader["NumberDewey"] == DBNull.Value ? null : (string)reader["NumberDewey"], ISBN = reader["ISBN"] == DBNull.Value ? null : (string)reader["ISBN"], Note = reader["Note"] == DBNull.Value ? null : (string)reader["Note"] };
		}
	}
}
