namespace SqlDbBackAndRestore.Core.Tasks
{
    using System;
    using System.Data.SqlClient;
    
    public class SqlBackUpTask : BaseSqlTask
    {
        public SqlBackUpTask(string databaseName, string pathToSave)
            : base (databaseName, pathToSave)
        {
        }

        public new event TaskFinished Finished;

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

        protected override void NotifyFinish()
        {
            if (this.Finished != null)
            {
                this.Finished(this, string.Format("Backup for database {0} was successfully created.", this.databaseName));
            }
        }
    }
}
