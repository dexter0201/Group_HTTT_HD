using System;
using System.Data.SqlClient;
using System.Data;
using IDAL;
using DTO;
namespace DAL
{
	public class ProvinceRepository : Repository<Province>, IProvinceRepository
	{
		protected override void SetReturnParam(SqlCommand cmd, Province obj)
		{
			obj.ProvinceId = (int)cmd.Parameters["@ProvinceId"].Value;
		}
		protected override void SetDeleteParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "DeleteProvince";
			cmd.Parameters.Add("@ProvinceId", SqlDbType.Int).Value = id;
		}
		protected override void SetGetsParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "GetProvinces";
		}
		protected override void SetCountParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "CountProvinces";
		}
		protected override void SetGetParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "GetProvinceById";
			cmd.Parameters.Add("@ProvinceId", SqlDbType.Int).Value = id;
		}
		protected override void SetInsertParam(SqlCommand cmd, Province obj)
		{
			cmd.CommandText = "InsertProvince";
			cmd.Parameters.Add("@ProvinceId", SqlDbType.Int).Direction = ParameterDirection.Output;
		}
		protected override void SetUpdateParam(SqlCommand cmd, Province obj)
		{
			cmd.CommandText = "UpdateProvince";
			cmd.Parameters.Add("@ProvinceId", SqlDbType.Int).Value = obj.ProvinceId;
		}
		protected override void SetParam(SqlCommand cmd, Province obj)
		{
			cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = obj.CountryId;
			cmd.Parameters.Add("@ProvinceNo", SqlDbType.VarChar).Value = obj.ProvinceNo;
			cmd.Parameters.Add("@ProvinceName", SqlDbType.NVarChar).Value = obj.ProvinceName;

		}
		protected override Province GetFromReader(SqlDataReader reader)
		{
			return new Province { ProvinceId = (int)reader["ProvinceId"], CountryId = (int)reader["CountryId"], ProvinceNo = reader["ProvinceNo"] == DBNull.Value ? null : (string)reader["ProvinceNo"], ProvinceName = (string)reader["ProvinceName"] };
		}
	}
}
