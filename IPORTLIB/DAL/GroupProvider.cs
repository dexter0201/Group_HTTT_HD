using System.Collections.Generic;
using DTO;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class GroupProvider : BaseProvider<Group>
    {
        protected override Group Get(SqlDataReader reader)
        {
            return new Group { GroupId = (int)reader["GroupId"], GroupName = (string)reader["GroupName"] };
        }
        public List<Group> Gets()
        {
            using (SqlConnection cn = new SqlConnection(Config.ConnectString))
            {
                SqlCommand cmd = new SqlCommand("GetGroups", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                return Gets(reader);
            }
        }

        protected override bool SetInsertParams(SqlCommand cmd, Group t)
        {
            throw new System.NotImplementedException();
        }

        protected override void SetUpdateParams(SqlCommand cmd, Group t)
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
