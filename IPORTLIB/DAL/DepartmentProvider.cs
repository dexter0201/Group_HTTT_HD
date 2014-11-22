using System.Collections.Generic;
using DTO;
using System.Linq;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DepartmentProvider : BaseProvider<Department>
    {
        public List<Department> Gets()
        {
            using (SqlConnection cn = new SqlConnection(Config.ConnectString))
            {
                SqlCommand cmd = new SqlCommand("GetDepartments", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                return Gets(reader);
            }
        }
        protected override Department Get(SqlDataReader reader)
        {
            return new Department { DepartmentId = (int)reader["DepartmentId"], DepartmentName = (string)reader["DepartmentName"] };
        }

        protected override bool SetInsertParams(SqlCommand cmd, Department t)
        {
            throw new System.NotImplementedException();
        }

        protected override void SetUpdateParams(SqlCommand cmd, Department t)
        {
            throw new System.NotImplementedException();
        }

        protected override void SetDeleteParams(SqlCommand cmd, int id)
        {
            throw new System.NotImplementedException();
        }

        protected override void SetGetParams(SqlCommand cmd, int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
