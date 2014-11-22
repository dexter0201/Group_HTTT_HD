using System.Collections.Generic;
using System.Linq;
using DTO;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class ProvinceProvider : BaseProvider<Province>
    {
        public List<Province> Gets(int countryId)
        {
            using (SqlConnection cn = new SqlConnection(Config.ConnectString))
            {
                SqlCommand cmd = new SqlCommand("GetProvinces", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = countryId;
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                return Gets(reader);
            }
        }
        protected override Province Get(SqlDataReader reader)
        {
            return new Province { ProvinceId = (int)reader["ProvinceId"], ProvinceName = (string)reader["ProvinceName"], ProvinceNo = (string)reader["ProvinceNo"] };
        }

        protected override bool SetInsertParams(SqlCommand cmd, Province t)
        {
            throw new System.NotImplementedException();
        }

        protected override void SetUpdateParams(SqlCommand cmd, Province t)
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
