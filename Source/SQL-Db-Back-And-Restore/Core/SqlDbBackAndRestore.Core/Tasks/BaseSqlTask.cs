namespace SqlDbBackAndRestore.Core.Tasks
{
    using System.Data.SqlClient;

    abstract class BaseSqlTask : BaseTask
    {
        private SqlConnection conn;
        private SqlCommand command;
        private string sql = "";
        private string connectionString = "";

        public BaseSqlTask()
        {

        }
    }
}
