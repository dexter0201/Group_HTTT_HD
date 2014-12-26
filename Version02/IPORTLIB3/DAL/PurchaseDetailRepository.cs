using System;
using System.Data.SqlClient;
using System.Data;
using IDAL;
using DTO;
namespace DAL
{
	public class PurchaseDetailRepository : Repository<PurchaseDetail>, IPurchaseDetailRepository
	{
		protected override void SetReturnParam(SqlCommand cmd, PurchaseDetail obj)
		{
			obj.PurchaseDetailId = (int)cmd.Parameters["@PurchaseDetailId"].Value;
		}
		protected override void SetDeleteParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "DeletePurchaseDetail";
			cmd.Parameters.Add("@PurchaseDetailId", SqlDbType.Int).Value = id;
		}
		protected override void SetGetsParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "GetPurchaseDetails";
		}
		protected override void SetCountParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "CountPurchaseDetails";
		}
		protected override void SetGetParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "GetPurchaseDetailById";
			cmd.Parameters.Add("@PurchaseDetailId", SqlDbType.Int).Value = id;
		}
		protected override void SetInsertParam(SqlCommand cmd, PurchaseDetail obj)
		{
			cmd.CommandText = "InsertPurchaseDetail";
			cmd.Parameters.Add("@PurchaseDetailId", SqlDbType.Int).Direction = ParameterDirection.Output;
		}
		protected override void SetUpdateParam(SqlCommand cmd, PurchaseDetail obj)
		{
			cmd.CommandText = "UpdatePurchaseDetail";
			cmd.Parameters.Add("@PurchaseDetailId", SqlDbType.Int).Value = obj.PurchaseDetailId;
		}
		protected override void SetParam(SqlCommand cmd, PurchaseDetail obj)
		{
			cmd.Parameters.Add("@PurchaseId", SqlDbType.Int).Value = obj.PurchaseId;
			cmd.Parameters.Add("@StatusId", SqlDbType.Int).Value = obj.StatusId;
			cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = obj.Title;
			cmd.Parameters.Add("@AuthorName", SqlDbType.NVarChar).Value = obj.AuthorName;
			cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = obj.Quantity;
			cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = obj.Note;

		}
		protected override PurchaseDetail GetFromReader(SqlDataReader reader)
		{
			return new PurchaseDetail { PurchaseDetailId = (int)reader["PurchaseDetailId"], PurchaseId = (int)reader["PurchaseId"], StatusId = (int)reader["StatusId"], Title = (string)reader["Title"], AuthorName = reader["AuthorName"] == DBNull.Value ? null : (string)reader["AuthorName"], Quantity = (int)reader["Quantity"], Note = reader["Note"] == DBNull.Value ? null : (string)reader["Note"] };
		}
	}
}
