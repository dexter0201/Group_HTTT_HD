using System;
using System.Data.SqlClient;
using System.Data;
using IDAL;
using DTO;
namespace DAL
{
	public class StoreRepository : Repository<Store>, IStoreRepository
	{
		protected override void SetReturnParam(SqlCommand cmd, Store obj)
		{
			obj.StoreId = (int)cmd.Parameters["@StoreId"].Value;
		}
		protected override void SetDeleteParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "DeleteStore";
			cmd.Parameters.Add("@StoreId", SqlDbType.Int).Value = id;
		}
		protected override void SetGetsParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "GetStores";
		}
		protected override void SetCountParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "CountStores";
		}
		protected override void SetGetParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "GetStoreById";
			cmd.Parameters.Add("@StoreId", SqlDbType.Int).Value = id;
		}
		protected override void SetInsertParam(SqlCommand cmd, Store obj)
		{
			cmd.CommandText = "InsertStore";
			cmd.Parameters.Add("@StoreId", SqlDbType.Int).Direction = ParameterDirection.Output;
		}
		protected override void SetUpdateParam(SqlCommand cmd, Store obj)
		{
			cmd.CommandText = "UpdateStore";
			cmd.Parameters.Add("@StoreId", SqlDbType.Int).Value = obj.StoreId;
		}
		protected override void SetParam(SqlCommand cmd, Store obj)
		{
			cmd.Parameters.Add("@StoreName", SqlDbType.NVarChar).Value = obj.StoreName;

		}
		protected override Store GetFromReader(SqlDataReader reader)
		{
			return new Store { StoreId = (int)reader["StoreId"], StoreName = (string)reader["StoreName"] };
		}
	}
}
