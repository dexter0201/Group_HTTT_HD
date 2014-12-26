using System;
using System.Data.SqlClient;
using System.Data;
using IDAL;
using DTO;
namespace DAL
{
	public class OrderRepository : Repository<Order>, IOrderRepository
	{
		protected override void SetReturnParam(SqlCommand cmd, Order obj)
		{
			obj.OrderId = (int)cmd.Parameters["@OrderId"].Value;
		}
		protected override void SetDeleteParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "DeleteOrder";
			cmd.Parameters.Add("@OrderId", SqlDbType.Int).Value = id;
		}
		protected override void SetGetsParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "GetOrders";
		}
		protected override void SetCountParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "CountOrders";
		}
		protected override void SetGetParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "GetOrderById";
			cmd.Parameters.Add("@OrderId", SqlDbType.Int).Value = id;
		}
		protected override void SetInsertParam(SqlCommand cmd, Order obj)
		{
			cmd.CommandText = "InsertOrder";
			cmd.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.Output;
		}
		protected override void SetUpdateParam(SqlCommand cmd, Order obj)
		{
			cmd.CommandText = "UpdateOrder";
			cmd.Parameters.Add("@OrderId", SqlDbType.Int).Value = obj.OrderId;
		}
		protected override void SetParam(SqlCommand cmd, Order obj)
		{
			cmd.Parameters.Add("@SupplierId", SqlDbType.Int).Value = obj.SupplierId;
			cmd.Parameters.Add("@StatusId", SqlDbType.Int).Value = obj.StatusId;

		}
		protected override Order GetFromReader(SqlDataReader reader)
		{
			return new Order { OrderId = (int)reader["OrderId"], CreatedDate = (DateTime)reader["CreatedDate"], SupplierId = (int)reader["SupplierId"], StatusId = (int)reader["StatusId"] };
		}
	}
}
