namespace SqlDbBackAndRestore.Core.Tasks
{
    using System;
    using System.Data.SqlClient;

    public class SqlRestoreTask : BaseSqlTask
    {
        public SqlRestoreTask(string tableName)
            : base (tableName)
        {
        }

        protected override void ExecuteSqlCommand()
        {
            // TODO put it in try cath
            this.sql = "USE master;";
            this.sql += string.Format("ALTER DATABASE {0} SET SINGLE_USER WITH ROLLBACK IMMEDIATE;", this.tableName);
            this.sql += string.Format("RESTORE DATABASE {0} FROM DISk = '{1}' WITH REPLACE", this.tableName, "D:\\kolio.bak");
            this.command = new SqlCommand(this.sql, this.connection);

            try
            {
                this.command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            Console.WriteLine("Restore done");

            // Once you've finished restoring and the database is ready for use again:
            // ALTER DATABASE AMOD SET MULTI_USER;
        }
    }
}
