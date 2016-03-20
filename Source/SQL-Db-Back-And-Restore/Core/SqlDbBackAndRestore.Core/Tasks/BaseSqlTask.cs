namespace SqlDbBackAndRestore.Core.Tasks
{
    using System.Data.SqlClient;

    public abstract class BaseSqlTask : BaseTask
    {
        protected string connectionString = "";
        protected SqlConnection connection;
        protected SqlCommand command;
        protected string sql = "";
        protected string databaseName = "";
        protected string path = "";

        public BaseSqlTask(string connectionString, string databaseName, string path)
        {
            this.connectionString = connectionString;
            this.connection = new SqlConnection(connectionString);
            this.databaseName = databaseName;
            this.path = path;
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
