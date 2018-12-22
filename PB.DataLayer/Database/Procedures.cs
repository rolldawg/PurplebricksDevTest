using PB.Configuration.Interfaces;
using PB.DataLayer.Interfaces;
using PB.Models.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PB.DataLayer.Database
{
	/// <summary>
	/// Implentation of IProcedures. Store all stored procedures here.
	/// </summary>
	public class Procedures : IProcedures
	{
		private static IConfiguration _configuration;

		public Procedures(IConfiguration p_configuration)
		{
			_configuration = p_configuration;
		}

		#region Interface implementation
		public Diary FindAVLPEDiary(int advertId, int year, int month, int day)
		{
			var slots = new List<Slot>();

			using (var sqlConnection = new SqlConnection(_configuration.GetDatabaseConnectionString()))
			{
				sqlConnection.Open();

				var command = new SqlCommand(Resources.Diary.GetLpeDiary, sqlConnection) { CommandType = CommandType.StoredProcedure };

				SqlParameter[] sqlParameters = new SqlParameter[]
				{
					new SqlParameter { ParameterName = "@year", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = year},
					new SqlParameter { ParameterName = "@month", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = month},
					new SqlParameter { ParameterName = "@day", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = day}
				};

				command = SetCommandArguements(command, sqlParameters);

				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						var slot = new Slot() { IsBooked = reader.GetBoolean(0), StartTime = reader.GetDateTime(1) };

						slots.Add(slot);
					}
				}
			}
			
			return new Diary()
			{
				Slots = slots
			};
		}

		public Diary FindCustomerDiary(int propertyId, int year, int month, int day)
		{
			var slots = new List<Slot>();

			using (var sqlConnection = new SqlConnection(_configuration.GetDatabaseConnectionString()))
			{
				sqlConnection.Open();

				var command = new SqlCommand(Resources.Diary.GetCustomerDiary, sqlConnection) { CommandType = CommandType.StoredProcedure };

				SqlParameter[] sqlParameters = new SqlParameter[]
				{
					new SqlParameter { ParameterName = "@year", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = year},
					new SqlParameter { ParameterName = "@month", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = month},
					new SqlParameter { ParameterName = "@day", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = day}
				};

				command = SetCommandArguements(command, sqlParameters);

				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						var slot = new Slot() { IsBooked = reader.GetBoolean(0), StartTime = reader.GetDateTime(1) };

						slots.Add(slot);
					}
				}
			}

			return new Diary()
			{
				Slots = slots
			};
		}

		public void BookViewing(int customerId, int advertId, Slot slot, bool hasAccompanied)
		{
			using (var sqlConnection = new SqlConnection(_configuration.GetDatabaseConnectionString()))
			{
				sqlConnection.Open();

				var command = new SqlCommand(Resources.Diary.UpdateDiary, sqlConnection) { CommandType = CommandType.StoredProcedure };

				SqlParameter[] sqlParameters = new SqlParameter[]
				{
					new SqlParameter { ParameterName = "@customerId", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = customerId},
					new SqlParameter { ParameterName = "@advertId", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = advertId},
					new SqlParameter { ParameterName = "@slot", SqlDbType = SqlDbType.DateTime, Direction = ParameterDirection.Input, Value = slot.StartTime},
					new SqlParameter { ParameterName = "@hasAccompanied", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Input, Value = hasAccompanied},
				};

				command = SetCommandArguements(command, sqlParameters);

				command.ExecuteReader();
			}
		}
		#endregion

		#region Private methods
		/// <summary>
		/// Sets the SqlParameters to command
		/// </summary>
		/// <param name="p_sqlCommand"></param>
		/// <param name="p_sqlParameters"></param>
		/// <returns></returns>
		private SqlCommand SetCommandArguements(SqlCommand p_sqlCommand, SqlParameter[] p_sqlParameters)
		{
			foreach (SqlParameter parameter in p_sqlParameters)
			{
				p_sqlCommand.Parameters.Add(parameter);
			}

			return p_sqlCommand;
		}
		#endregion
	}
}
