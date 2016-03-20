namespace SqlDbBackAndRestore.Core.Tasks
{
    using System;
    using System.Data.SqlClient;

    public class SqlRestoreTask : BaseSqlTask
    {
        public SqlRestoreTask(string connectionString, string databaseName, string restoreFilePath)
            : base (connectionString, databaseName, restoreFilePath)
        {
        }
       
        protected override void ExecuteSqlCommand()
        {
            this.sql = "USE master;";
            this.sql += string.Format("ALTER DATABASE {0} SET SINGLE_USER WITH ROLLBACK IMMEDIATE;", this.databaseName);
            this.sql += string.Format("RESTORE DATABASE {0} FROM DISk = '{1}' WITH REPLACE", this.databaseName, this.path);
            this.command = new SqlCommand(this.sql, this.connection);

            try
            {
                this.command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

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
        }

        internal override string GetEventNotifyFinishMessage()
        {
            return string.Format("Database {0} was successfully restored", this.databaseName);
        }
    }
}
