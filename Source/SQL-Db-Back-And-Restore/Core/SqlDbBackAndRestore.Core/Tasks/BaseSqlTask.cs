namespace SqlDbBackAndRestore.Core.Tasks
{
    using System.Data;
    using System.Data.SqlClient;

    public abstract class BaseSqlTask : BaseTask
    {
        protected IDbConnection connection;
        protected IDbCommand command;
        protected string databaseName = "";

        public BaseSqlTask(IDbConnection connection, IDbCommand command, string databaseName)
        {
            this.connection = connection;
            this.command = command;
            this.databaseName = databaseName;
        }

        public override void Execute()
        {
            this.connection.Open();
            this.ExecuteSqlCommand();
            this.connection.Close();
            this.connection.Dispose();
            this.EventNotifyFinish();
        }

        protected abstract void ExecuteSqlCommand();
    }
}
