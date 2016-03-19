namespace SqlDbBackAndRestore.Core.Tasks
{
    using System;
    using System.Data.SqlClient;

    public class SqlBackUpTask : BaseSqlTask
    {
        public SqlBackUpTask(string tableName, string pathToSave)
            : base (tableName, pathToSave)
        {
        }

        protected override void ExecuteSqlCommand()
        {
            string nowTimestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string filePath = string.Format("{0}\\{1}-{2}.bak", this.pathToSave, this.tableName, nowTimestamp);

            this.sql = string.Format("BACKUP DATABASE {0} TO DISK = '{1}'", this.tableName, filePath);
            this.command = new SqlCommand(this.sql, this.connection);

            try
            {
                this.command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
               throw new Exception(ex.Message);
            }

            Console.WriteLine("Backup Done.");
        }
    }
}
