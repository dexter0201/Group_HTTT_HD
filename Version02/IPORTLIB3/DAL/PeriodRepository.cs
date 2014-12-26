using System;
using System.Data.SqlClient;
using System.Data;
using IDAL;
using DTO;
namespace DAL
{
	public class PeriodRepository : Repository<Period>, IPeriodRepository
	{
		protected override void SetReturnParam(SqlCommand cmd, Period obj)
		{
			obj.PeriodId = (int)cmd.Parameters["@PeriodId"].Value;
		}
		protected override void SetDeleteParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "DeletePeriod";
			cmd.Parameters.Add("@PeriodId", SqlDbType.Int).Value = id;
		}
		protected override void SetGetsParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "GetPeriods";
		}
		protected override void SetCountParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "CountPeriods";
		}
		protected override void SetGetParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "GetPeriodById";
			cmd.Parameters.Add("@PeriodId", SqlDbType.Int).Value = id;
		}
		protected override void SetInsertParam(SqlCommand cmd, Period obj)
		{
			cmd.CommandText = "InsertPeriod";
			cmd.Parameters.Add("@PeriodId", SqlDbType.Int).Direction = ParameterDirection.Output;
		}
		protected override void SetUpdateParam(SqlCommand cmd, Period obj)
		{
			cmd.CommandText = "UpdatePeriod";
			cmd.Parameters.Add("@PeriodId", SqlDbType.Int).Value = obj.PeriodId;
		}
		protected override void SetParam(SqlCommand cmd, Period obj)
		{
			cmd.Parameters.Add("@PublicationId", SqlDbType.Int).Value = obj.PublicationId;
			cmd.Parameters.Add("@PeriodName", SqlDbType.NVarChar).Value = obj.PeriodName;
			cmd.Parameters.Add("@Chapter", SqlDbType.NVarChar).Value = obj.Chapter;

		}
		protected override Period GetFromReader(SqlDataReader reader)
		{
			return new Period { PeriodId = (int)reader["PeriodId"], PublicationId = (int)reader["PublicationId"], PeriodName = (string)reader["PeriodName"], Chapter = (string)reader["Chapter"] };
		}
	}
}
