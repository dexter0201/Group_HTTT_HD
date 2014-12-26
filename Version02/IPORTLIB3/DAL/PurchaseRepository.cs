using System;
using System.Data.SqlClient;
using System.Data;
using IDAL;
using DTO;
namespace DAL
{
	public class PurchaseRepository : Repository<Purchase>, IPurchaseRepository
	{
		protected override void SetReturnParam(SqlCommand cmd, Purchase obj)
		{
			obj.PurchaseId = (int)cmd.Parameters["@PurchaseId"].Value;
		}
		protected override void SetDeleteParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "DeletePurchase";
			cmd.Parameters.Add("@PurchaseId", SqlDbType.Int).Value = id;
		}
		protected override void SetGetsParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "GetPurchases";
		}
		protected override void SetCountParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "CountPurchases";
		}
		protected override void SetGetParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "GetPurchaseById";
			cmd.Parameters.Add("@PurchaseId", SqlDbType.Int).Value = id;
		}
		protected override void SetInsertParam(SqlCommand cmd, Purchase obj)
		{
			cmd.CommandText = "InsertPurchase";
			cmd.Parameters.Add("@PurchaseId", SqlDbType.Int).Direction = ParameterDirection.Output;
		}
		protected override void SetUpdateParam(SqlCommand cmd, Purchase obj)
		{
			cmd.CommandText = "UpdatePurchase";
			cmd.Parameters.Add("@PurchaseId", SqlDbType.Int).Value = obj.PurchaseId;
		}
		protected override void SetParam(SqlCommand cmd, Purchase obj)
		{
			cmd.Parameters.Add("@StatusId", SqlDbType.Int).Value = obj.StatusId;
			cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = obj.Note;

		}
		protected override Purchase GetFromReader(SqlDataReader reader)
		{
			return new Purchase { PurchaseId = (int)reader["PurchaseId"], CreatedDate = (DateTime)reader["CreatedDate"], StatusId = (int)reader["StatusId"], Note = reader["Note"] == DBNull.Value ? null : (string)reader["Note"] };
		}
	}
}
