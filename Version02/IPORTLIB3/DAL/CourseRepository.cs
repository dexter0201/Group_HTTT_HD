using System;
using System.Data.SqlClient;
using System.Data;
using IDAL;
using DTO;
namespace DAL
{
	public class CourseRepository : Repository<Course>, ICourseRepository
	{
		protected override void SetReturnParam(SqlCommand cmd, Course obj)
		{
			obj.CourseId = (int)cmd.Parameters["@CourseId"].Value;
		}
		protected override void SetDeleteParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "DeleteCourse";
			cmd.Parameters.Add("@CourseId", SqlDbType.Int).Value = id;
		}
		protected override void SetGetsParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "GetCourses";
		}
		protected override void SetCountParam(SqlCommand cmd, object obj)
		{
			cmd.CommandText = "CountCourses";
		}
		protected override void SetGetParam(SqlCommand cmd, object id)
		{
			cmd.CommandText = "GetCourseById";
			cmd.Parameters.Add("@CourseId", SqlDbType.Int).Value = id;
		}
		protected override void SetInsertParam(SqlCommand cmd, Course obj)
		{
			cmd.CommandText = "InsertCourse";
			cmd.Parameters.Add("@CourseId", SqlDbType.Int).Direction = ParameterDirection.Output;
		}
		protected override void SetUpdateParam(SqlCommand cmd, Course obj)
		{
			cmd.CommandText = "UpdateCourse";
			cmd.Parameters.Add("@CourseId", SqlDbType.Int).Value = obj.CourseId;
		}
		protected override void SetParam(SqlCommand cmd, Course obj)
		{
			cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = obj.Quantity;
			cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = obj.StartDate;
			cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = obj.EndDate;
			cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = obj.Note;

		}
		protected override Course GetFromReader(SqlDataReader reader)
		{
			return new Course { CourseId = (int)reader["CourseId"], Quantity = (int)reader["Quantity"], StartDate = (DateTime)reader["StartDate"], EndDate = (DateTime)reader["EndDate"], Note = reader["Note"] == DBNull.Value ? null : (string)reader["Note"] };
		}
	}
}
