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
            // TODO put it in try cath
            this.sql = "BACKUP DATABASE JobServiceApplication TO DISK = 'D:\\kolio.bak'";
            this.command = new SqlCommand(this.sql, this.connection);
            this.command.ExecuteNonQuery();

            Console.WriteLine("Backup Done.");
        }
    }
}
