using PB.Configuration.Interfaces;
using PB.DataLayer.DiaryDatabase;
using PB.DataLayer.Interfaces;
using System;
using System.Data;
using System.Data.Common;

namespace PB.DataLayer.Database
{
	/// <summary>
	/// Implentation of IDataLayer. Anything DB related goes here.
	/// </summary>
	public class DatabaseLayer : DbConnection, IDataLayer
	{
		IConfiguration Configuration;

		public IProcedures Procedures { get; set; }

		public IDiary Diary { get; set; }

		public override string ConnectionString { get; set; }

		public DatabaseLayer(IConfiguration p_configuration)
		{
			Configuration = p_configuration;
			Procedures = new Procedures(p_configuration);
			Diary = new Diary();
		}

		#region Not Implemented overrides
		public override string Database => throw new NotImplementedException();

		public override string DataSource => throw new NotImplementedException();

		public override string ServerVersion => throw new NotImplementedException();

		public override ConnectionState State => throw new NotImplementedException();

		public override void ChangeDatabase(string databaseName)
		{
			throw new NotImplementedException();
		}

		public override void Close()
		{
			throw new NotImplementedException();
		}

		public override void Open()
		{
			throw new NotImplementedException();
		}

		protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
		{
			throw new NotImplementedException();
		}

		protected override DbCommand CreateDbCommand()
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
