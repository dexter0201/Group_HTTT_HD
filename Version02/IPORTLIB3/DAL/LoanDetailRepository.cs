using System;
using System.Data.SqlClient;
using System.Data;
using IDAL;
using DTO;
namespace DAL
{
	public class LoanDetailRepository : Repository<LoanDetail>, ILoanDetailRepository
	{
		protected override void SetReturnParam(SqlCommand cmd, LoanDetail obj)
		{
			obj.LoanDetailId = (int)cmd.Parameters["@LoanDetailId"].Value;
		}
		protected override void SetDeleteParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "DeleteLoanDetail";
			cmd.Parameters.Add("@LoanDetailId", SqlDbType.Int).Value = id;
		}
		protected override void SetGetsParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "GetLoanDetails";
		}
		protected override void SetCountParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "CountLoanDetails";
		}
		protected override void SetGetParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "GetLoanDetailById";
			cmd.Parameters.Add("@LoanDetailId", SqlDbType.Int).Value = id;
		}
		protected override void SetInsertParam(SqlCommand cmd, LoanDetail obj)
		{
			cmd.CommandText = "InsertLoanDetail";
			cmd.Parameters.Add("@LoanDetailId", SqlDbType.Int).Direction = ParameterDirection.Output;
		}
		protected override void SetUpdateParam(SqlCommand cmd, LoanDetail obj)
		{
			cmd.CommandText = "UpdateLoanDetail";
			cmd.Parameters.Add("@LoanDetailId", SqlDbType.Int).Value = obj.LoanDetailId;
		}
		protected override void SetParam(SqlCommand cmd, LoanDetail obj)
		{
			cmd.Parameters.Add("@LoanId", SqlDbType.Int).Value = obj.LoanId;
			cmd.Parameters.Add("@BookId", SqlDbType.Int).Value = obj.BookId;
			cmd.Parameters.Add("@DatePay", SqlDbType.DateTime).Value = obj.DatePay;

		}
		protected override LoanDetail GetFromReader(SqlDataReader reader)
		{
			return new LoanDetail { LoanDetailId = (int)reader["LoanDetailId"], LoanId = (int)reader["LoanId"], BookId = (int)reader["BookId"], DateLoan = (DateTime)reader["DateLoan"], DatePay = reader["DatePay"] == DBNull.Value ? DateTime.Now : (DateTime)reader["DatePay"] };
		}
	}
}
