using System;
using System.Data.SqlClient;
using System.Data;
using IDAL;
using DTO;
namespace DAL
{
	public class SupplierRepository : Repository<Supplier>, ISupplierRepository
	{
		protected override void SetReturnParam(SqlCommand cmd, Supplier obj)
		{
			obj.SupplierId = (int)cmd.Parameters["@SupplierId"].Value;
		}
		protected override void SetDeleteParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "DeleteSupplier";
			cmd.Parameters.Add("@SupplierId", SqlDbType.Int).Value = id;
		}
		protected override void SetGetsParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "GetSuppliers";
		}
		protected override void SetCountParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "CountSuppliers";
		}
		protected override void SetGetParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "GetSupplierById";
			cmd.Parameters.Add("@SupplierId", SqlDbType.Int).Value = id;
		}
		protected override void SetInsertParam(SqlCommand cmd, Supplier obj)
		{
			cmd.CommandText = "InsertSupplier";
			cmd.Parameters.Add("@SupplierId", SqlDbType.Int).Direction = ParameterDirection.Output;
		}
		protected override void SetUpdateParam(SqlCommand cmd, Supplier obj)
		{
			cmd.CommandText = "UpdateSupplier";
			cmd.Parameters.Add("@SupplierId", SqlDbType.Int).Value = obj.SupplierId;
		}
		protected override void SetParam(SqlCommand cmd, Supplier obj)
		{
			cmd.Parameters.Add("@SupplierName", SqlDbType.NVarChar).Value = obj.SupplierName;
			cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = obj.Address;
			cmd.Parameters.Add("@ProvinceId", SqlDbType.Int).Value = obj.ProvinceId;
			cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = obj.Email;
			cmd.Parameters.Add("@WebPage", SqlDbType.VarChar).Value = obj.WebPage;
			cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = obj.Phone;
			cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar).Value = obj.AccountName;
			cmd.Parameters.Add("@BankName", SqlDbType.VarChar).Value = obj.BankName;
			cmd.Parameters.Add("@TaxCode", SqlDbType.VarChar).Value = obj.TaxCode;

		}
		protected override Supplier GetFromReader(SqlDataReader reader)
		{
			return new Supplier { SupplierId = (int)reader["SupplierId"], SupplierName = (string)reader["SupplierName"], Address = reader["Address"] == DBNull.Value ? null : (string)reader["Address"], ProvinceId = (int)reader["ProvinceId"], Email = reader["Email"] == DBNull.Value ? null : (string)reader["Email"], WebPage = reader["WebPage"] == DBNull.Value ? null : (string)reader["WebPage"], Phone = reader["Phone"] == DBNull.Value ? null : (string)reader["Phone"], AccountName = reader["AccountName"] == DBNull.Value ? null : (string)reader["AccountName"], BankName = reader["BankName"] == DBNull.Value ? null : (string)reader["BankName"], TaxCode = reader["TaxCode"] == DBNull.Value ? null : (string)reader["TaxCode"] };
		}
	}
}
