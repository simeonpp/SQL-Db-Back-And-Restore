namespace SqlDbBackAndRestore.Core.Tasks
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class SqlRestoreTask : BaseSqlTask
    {
        public SqlRestoreTask(IDbConnection connection, IDbCommand command, string databaseName)
            : base (connection, command, databaseName)
        {
        }

        protected override void ExecuteSqlCommand()
        {
            try
            {
                this.command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            /*
            // When restoring is finished the database is ready for use again
            this.sql = string.Format("ALTER DATABASE {0} SET MULTI_USER", this.databaseName);
            this.command = new SqlCommand(this.sql, this.connection);
            try
            {
                this.command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            */
        }

        internal override string GetEventNotifyFinishMessage()
        {
            return string.Format("Database {0} was successfully restored", this.databaseName);
        }
    }
}
