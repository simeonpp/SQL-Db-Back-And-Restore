namespace SqlDbBackAndRestore.Core.Tasks
{
    using System;

    public class SqlRestoreTask : BaseSqlTask
    {
        public SqlRestoreTask(string tableName)
            : base (tableName)
        {
        }

        protected override void ExecuteSqlCommand()
        {
            // TODO put it in try cath
            sql = "USE master;";
            sql += "ALTER DATABASE JobServiceApplication SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
            sql += "RESTORE DATABASE JobServiceApplication FROM DISk = 'D:\\kolio.bak' WITH REPLACE";
            command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();

            Console.WriteLine("Restore done");

            // Once you've finished restoring and the database is ready for use again:
            // ALTER DATABASE AMOD SET MULTI_USER;
        }
    }
}
