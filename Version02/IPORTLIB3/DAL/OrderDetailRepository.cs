using System;
using System.Data.SqlClient;
using System.Data;
using IDAL;
using DTO;
namespace DAL
{
	public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
	{
		protected override void SetReturnParam(SqlCommand cmd, OrderDetail obj)
		{
			obj.OrderDetailId = (int)cmd.Parameters["@OrderDetailId"].Value;
		}
		protected override void SetDeleteParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "DeleteOrderDetail";
			cmd.Parameters.Add("@OrderDetailId", SqlDbType.Int).Value = id;
		}
		protected override void SetGetsParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "GetOrderDetails";
		}
		protected override void SetCountParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "CountOrderDetails";
		}
		protected override void SetGetParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "GetOrderDetailById";
			cmd.Parameters.Add("@OrderDetailId", SqlDbType.Int).Value = id;
		}
		protected override void SetInsertParam(SqlCommand cmd, OrderDetail obj)
		{
			cmd.CommandText = "InsertOrderDetail";
			cmd.Parameters.Add("@OrderDetailId", SqlDbType.Int).Direction = ParameterDirection.Output;
		}
		protected override void SetUpdateParam(SqlCommand cmd, OrderDetail obj)
		{
			cmd.CommandText = "UpdateOrderDetail";
			cmd.Parameters.Add("@OrderDetailId", SqlDbType.Int).Value = obj.OrderDetailId;
		}
		protected override void SetParam(SqlCommand cmd, OrderDetail obj)
		{
			cmd.Parameters.Add("@OrderId", SqlDbType.Int).Value = obj.OrderId;
			cmd.Parameters.Add("@PurchaseDetailId", SqlDbType.Int).Value = obj.PurchaseDetailId;
			cmd.Parameters.Add("@Price", SqlDbType.Int).Value = obj.Price;
			cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = obj.Quantity;
			cmd.Parameters.Add("@StatusId", SqlDbType.Int).Value = obj.StatusId;

		}
		protected override OrderDetail GetFromReader(SqlDataReader reader)
		{
			return new OrderDetail { OrderDetailId = (int)reader["OrderDetailId"], OrderId = (int)reader["OrderId"], PurchaseDetailId = (int)reader["PurchaseDetailId"], Price = reader["Price"] == DBNull.Value ? null : (int?)reader["Price"], Quantity = (int)reader["Quantity"], StatusId = (int)reader["StatusId"] };
		}
	}
}
