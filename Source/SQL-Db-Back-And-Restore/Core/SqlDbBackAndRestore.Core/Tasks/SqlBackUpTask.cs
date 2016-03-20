namespace SqlDbBackAndRestore.Core.Tasks
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class SqlBackUpTask : BaseSqlTask
    {
        public SqlBackUpTask(IDbConnection connection, IDbCommand command, string databaseName)
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
        }

        internal override string GetEventNotifyFinishMessage()
        {
            return string.Format("Backup for database {0} was successfully created.", this.databaseName);
        }
    }
}
