namespace SqlDbBackAndRestore.Core.Tasks
{
    using System;
    using System.Data.SqlClient;
    
    public class SqlBackUpTask : BaseSqlTask
    {
        public SqlBackUpTask(string connectionString, string databaseName, string pathToSave)
            : base (connectionString, databaseName, pathToSave)
        {
        }

        protected override void ExecuteSqlCommand()
        {
            string nowTimestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string filePath = string.Format("{0}\\{1}-{2}.bak", this.path, this.databaseName, nowTimestamp);

            this.sql = string.Format("BACKUP DATABASE {0} TO DISK = '{1}'", this.databaseName, filePath);
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

        protected override string GetEventNotifyFinishMessage()
        {
            return string.Format("Backup for database {0} was successfully created.", this.databaseName);
        }
    }
}
