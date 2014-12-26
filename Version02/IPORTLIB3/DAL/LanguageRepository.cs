using System;
using System.Data.SqlClient;
using System.Data;
using IDAL;
using DTO;
namespace DAL
{
	public class LanguageRepository : Repository<Language>, ILanguageRepository
	{
		protected override void SetReturnParam(SqlCommand cmd, Language obj)
		{
			obj.LanguageId = (int)cmd.Parameters["@LanguageId"].Value;
		}
		protected override void SetDeleteParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "DeleteLanguage";
			cmd.Parameters.Add("@LanguageId", SqlDbType.Int).Value = id;
		}
		protected override void SetGetsParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "GetLanguages";
		}
		protected override void SetCountParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "CountLanguages";
		}
		protected override void SetGetParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "GetLanguageById";
			cmd.Parameters.Add("@LanguageId", SqlDbType.Int).Value = id;
		}
		protected override void SetInsertParam(SqlCommand cmd, Language obj)
		{
			cmd.CommandText = "InsertLanguage";
			cmd.Parameters.Add("@LanguageId", SqlDbType.Int).Direction = ParameterDirection.Output;
		}
		protected override void SetUpdateParam(SqlCommand cmd, Language obj)
		{
			cmd.CommandText = "UpdateLanguage";
			cmd.Parameters.Add("@LanguageId", SqlDbType.Int).Value = obj.LanguageId;
		}
		protected override void SetParam(SqlCommand cmd, Language obj)
		{
			cmd.Parameters.Add("@LanguageName", SqlDbType.NVarChar).Value = obj.LanguageName;

		}
		protected override Language GetFromReader(SqlDataReader reader)
		{
			return new Language { LanguageId = (int)reader["LanguageId"], LanguageName = (string)reader["LanguageName"] };
		}
	}
}
