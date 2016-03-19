namespace SqlDbBackAndRestore.Core.Tasks
{
    using System;
    using System.Data.SqlClient;

    public class SqlBackUpTask : BaseSqlTask
    {
        public SqlBackUpTask(string tableName)
            : base (tableName)
        {
        }

        protected override void ExecuteSqlCommand()
        {
            this.sql = string.Format("BACKUP DATABASE {0} TO DISK = '{1}'", this.tableName, "D:\\kolio.bak");
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
