using DTO;
using System.Data.OleDb;

namespace WebApp.Models
{
    public class ExcelUserEnroll : ExcelBase<UserEnroll>
    {
        protected override UserEnroll GetFromReader(OleDbDataReader reader)
        {
            return new UserEnroll
            {
                DepartmentId = int.Parse(reader["DepartmentId"].ToString()),
                UserNo = reader["UserNo"].ToString(),
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                Phone = reader["Phone"].ToString(),
                Email = reader["Email"].ToString()
            };
        }

        protected override void SetGetsParam(OleDbCommand cmd)
        {
            cmd.CommandText = "SELECT * FROM [Sheet1$]";
        }
    }
}