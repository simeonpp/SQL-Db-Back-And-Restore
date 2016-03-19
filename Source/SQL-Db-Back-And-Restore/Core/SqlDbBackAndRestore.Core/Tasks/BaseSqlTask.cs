﻿namespace SqlDbBackAndRestore.Core.Tasks
{
    using System.Data.SqlClient;

    public abstract class BaseSqlTask : BaseTask
    {
        protected string connectionString = "";
        protected SqlConnection connection;
        protected SqlCommand command;
        protected string sql = "";        

        public BaseSqlTask(string tableName)
        {
            this.connectionString = string.Format("Data Source=.;Initial Catalog={0};Integrated Security=True;MultipleActiveResultSets=true", tableName);
            this.connection = new SqlConnection(connectionString);
        }

        public override void Execute()
        {
            this.connection.Open();
            this.ExecuteSqlCommand();
            this.connection.Close();
            this.connection.Dispose();
        }

        protected abstract void ExecuteSqlCommand();
    }
}
