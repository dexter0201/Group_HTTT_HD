using System;
using System.Data.SqlClient;
using System.Data;
using IDAL;
using DTO;
namespace DAL
{
	public class LoanRepository : Repository<Loan>, ILoanRepository
	{
		protected override void SetReturnParam(SqlCommand cmd, Loan obj)
		{
			obj.LoanId = (int)cmd.Parameters["@LoanId"].Value;
		}
		protected override void SetDeleteParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "DeleteLoan";
			cmd.Parameters.Add("@LoanId", SqlDbType.Int).Value = id;
		}
		protected override void SetGetsParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "GetLoans";
		}
		protected override void SetCountParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "CountLoans";
		}
		protected override void SetGetParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "GetLoanById";
			cmd.Parameters.Add("@LoanId", SqlDbType.Int).Value = id;
		}
		protected override void SetInsertParam(SqlCommand cmd, Loan obj)
		{
			cmd.CommandText = "InsertLoan";
			cmd.Parameters.Add("@LoanId", SqlDbType.Int).Direction = ParameterDirection.Output;
		}
		protected override void SetUpdateParam(SqlCommand cmd, Loan obj)
		{
			cmd.CommandText = "UpdateLoan";
			cmd.Parameters.Add("@LoanId", SqlDbType.Int).Value = obj.LoanId;
		}
		protected override void SetParam(SqlCommand cmd, Loan obj)
		{
			cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = obj.UserId;

		}
		protected override Loan GetFromReader(SqlDataReader reader)
		{
			return new Loan { LoanId = (int)reader["LoanId"], DateCreated = (DateTime)reader["DateCreated"], UserId = (int)reader["UserId"] };
		}
	}
}
