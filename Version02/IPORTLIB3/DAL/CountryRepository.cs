using System;
using System.Data.SqlClient;
using System.Data;
using IDAL;
using DTO;
namespace DAL
{
	public class CountryRepository : Repository<Country>, ICountryRepository
	{
		protected override void SetReturnParam(SqlCommand cmd, Country obj)
		{
			obj.CountryId = (int)cmd.Parameters["@CountryId"].Value;
		}
		protected override void SetDeleteParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "DeleteCountry";
			cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = id;
		}
		protected override void SetGetsParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "GetCountries";
		}
		protected override void SetCountParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "CountCountries";
		}
		protected override void SetGetParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "GetCountryById";
			cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = id;
		}
		protected override void SetInsertParam(SqlCommand cmd, Country obj)
		{
			cmd.CommandText = "InsertCountry";
			cmd.Parameters.Add("@CountryId", SqlDbType.Int).Direction = ParameterDirection.Output;
		}
		protected override void SetUpdateParam(SqlCommand cmd, Country obj)
		{
			cmd.CommandText = "UpdateCountry";
			cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = obj.CountryId;
		}
		protected override void SetParam(SqlCommand cmd, Country obj)
		{
			cmd.Parameters.Add("@CountryName", SqlDbType.NVarChar).Value = obj.CountryName;

		}
		protected override Country GetFromReader(SqlDataReader reader)
		{
			return new Country { CountryId = (int)reader["CountryId"], CountryName = reader["CountryName"] == DBNull.Value ? null : (string)reader["CountryName"] };
		}
	}
}
