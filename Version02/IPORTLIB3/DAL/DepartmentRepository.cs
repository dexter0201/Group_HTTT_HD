using System;
using System.Data.SqlClient;
using System.Data;
using IDAL;
using DTO;
using System.Collections.Generic;
namespace DAL
{
	public class DepartmentRepository : Repository<Department>, IDepartmentRepository
	{
		protected override void SetReturnParam(SqlCommand cmd, Department obj)
		{
			obj.DepartmentId = (int)cmd.Parameters["@DepartmentId"].Value;
		}
		protected override void SetDeleteParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "DeleteDepartment";
			cmd.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = id;
		}
		protected override void SetGetsParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "GetDepartments";
		}
		protected override void SetCountParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "CountDepartments";
		}
		protected override void SetGetParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "GetDepartmentById";
			cmd.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = id;
		}
		protected override void SetInsertParam(SqlCommand cmd, Department obj)
		{
			cmd.CommandText = "InsertDepartment";
			cmd.Parameters.Add("@DepartmentId", SqlDbType.Int).Direction = ParameterDirection.Output;
		}
		protected override void SetUpdateParam(SqlCommand cmd, Department obj)
		{
			cmd.CommandText = "UpdateDepartment";
			cmd.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = obj.DepartmentId;
		}
		protected override void SetParam(SqlCommand cmd, Department obj)
		{
			cmd.Parameters.Add("@DepartmentName", SqlDbType.NVarChar).Value = obj.DepartmentName;

		}
		protected override Department GetFromReader(SqlDataReader reader)
		{
			return new Department { DepartmentId = (int)reader["DepartmentId"], DepartmentName = (string)reader["DepartmentName"] };
		}
        public List<ReportUsersDepartments> ReportUsersDepartments()
        {
            using (SqlConnection cn = new SqlConnection(Setting.ConnString))
            {
                SqlCommand cmd = new SqlCommand("ReportUsersDepartments", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<ReportUsersDepartments> list = new List<ReportUsersDepartments>();
                while (reader.Read())
                    list.Add(new ReportUsersDepartments
                    {
                        DepartmentName = (string)reader["DepartmentName"],
                        CountUsers = (int)reader["CountUsers"]
                    });
                return list;
            }
        }
	}
}
