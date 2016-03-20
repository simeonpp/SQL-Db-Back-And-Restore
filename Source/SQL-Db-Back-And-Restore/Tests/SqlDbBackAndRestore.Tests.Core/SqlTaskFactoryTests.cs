namespace SqlDbBackAndRestore.Tests.Core
{
    using NUnit.Framework;
    using SqlDbBackAndRestore.Core;
    using SqlDbBackAndRestore.Core.Tasks;

    [TestFixture]
    public class SqlTaskFactoryTests
    {
        private SqlTaskFactory sqlTaskFactory;
        private string databaseName = "JobServiceApplication";
        private string connectionString = "";
        private string path = "C://";

        [SetUp]
        public void Init()
        {
            this.sqlTaskFactory = new SqlTaskFactory();
            this.connectionString = string.Format("Data Source=.;Initial Catalog={0};Integrated Security=True;", this.databaseName);
        }

        [Test]
        public void GetDbNameFromConnectionStringShouldReuturnRightResult()
        {
            
            
            
            string actual = this.sqlTaskFactory.GetDatabaseNameFromConnectionString(connectionString);
            Assert.AreEqual(databaseName, actual);
        }

        [Test]
        public void GetSqlBackupDbTaskShouldReturnSqlBackUpTaskInstance()
        {
            var backUpDbTask = this.sqlTaskFactory.GetSqlBackupDbTask(this.connectionString, path);
            Assert.IsInstanceOf(typeof(SqlBackUpTask), backUpDbTask);
        }

        [Test]
        public void GetSqlRestoreDbTastShouldReturnSqlRestoreTaskInstance()
        {
            var restoreTask = this.sqlTaskFactory.GetSqlRestoreDbTask(this.connectionString, path);
            Assert.IsInstanceOf(typeof(SqlRestoreTask), restoreTask);
        }
    }
}
