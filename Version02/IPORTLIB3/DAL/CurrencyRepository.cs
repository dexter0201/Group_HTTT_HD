using System;
using System.Data.SqlClient;
using System.Data;
using IDAL;
using DTO;
namespace DAL
{
	public class CurrencyRepository : Repository<Currency>, ICurrencyRepository
	{
		protected override void SetReturnParam(SqlCommand cmd, Currency obj)
		{
			obj.CurrencyId = (int)cmd.Parameters["@CurrencyId"].Value;
		}
		protected override void SetDeleteParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "DeleteCurrency";
			cmd.Parameters.Add("@CurrencyId", SqlDbType.Int).Value = id;
		}
		protected override void SetGetsParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "GetCurrencies";
		}
		protected override void SetCountParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "CountCurrencies";
		}
		protected override void SetGetParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "GetCurrencyById";
			cmd.Parameters.Add("@CurrencyId", SqlDbType.Int).Value = id;
		}
		protected override void SetInsertParam(SqlCommand cmd, Currency obj)
		{
			cmd.CommandText = "InsertCurrency";
			cmd.Parameters.Add("@CurrencyId", SqlDbType.Int).Direction = ParameterDirection.Output;
		}
		protected override void SetUpdateParam(SqlCommand cmd, Currency obj)
		{
			cmd.CommandText = "UpdateCurrency";
			cmd.Parameters.Add("@CurrencyId", SqlDbType.Int).Value = obj.CurrencyId;
		}
		protected override void SetParam(SqlCommand cmd, Currency obj)
		{
			cmd.Parameters.Add("@CurrencyName", SqlDbType.NVarChar).Value = obj.CurrencyName;

		}
		protected override Currency GetFromReader(SqlDataReader reader)
		{
			return new Currency { CurrencyId = (int)reader["CurrencyId"], CurrencyName = (string)reader["CurrencyName"] };
		}
	}
}
