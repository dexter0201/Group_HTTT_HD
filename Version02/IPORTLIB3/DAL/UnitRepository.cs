using System;
using System.Data.SqlClient;
using System.Data;
using IDAL;
using DTO;
namespace DAL
{
	public class UnitRepository : Repository<Unit>, IUnitRepository
	{
		protected override void SetReturnParam(SqlCommand cmd, Unit obj)
		{
			obj.UnitId = (int)cmd.Parameters["@UnitId"].Value;
		}
		protected override void SetDeleteParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "DeleteUnit";
			cmd.Parameters.Add("@UnitId", SqlDbType.Int).Value = id;
		}
		protected override void SetGetsParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "GetUnits";
		}
		protected override void SetCountParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "CountUnits";
		}
		protected override void SetGetParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "GetUnitById";
			cmd.Parameters.Add("@UnitId", SqlDbType.Int).Value = id;
		}
		protected override void SetInsertParam(SqlCommand cmd, Unit obj)
		{
			cmd.CommandText = "InsertUnit";
			cmd.Parameters.Add("@UnitId", SqlDbType.Int).Direction = ParameterDirection.Output;
		}
		protected override void SetUpdateParam(SqlCommand cmd, Unit obj)
		{
			cmd.CommandText = "UpdateUnit";
			cmd.Parameters.Add("@UnitId", SqlDbType.Int).Value = obj.UnitId;
		}
		protected override void SetParam(SqlCommand cmd, Unit obj)
		{
			cmd.Parameters.Add("@UnitName", SqlDbType.NVarChar).Value = obj.UnitName;

		}
		protected override Unit GetFromReader(SqlDataReader reader)
		{
			return new Unit { UnitId = (int)reader["UnitId"], UnitName = (string)reader["UnitName"] };
		}
	}
}
