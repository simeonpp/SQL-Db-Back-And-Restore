namespace SqlDbBackAndRestore.Tests.Core
{
    using Moq;
    using NUnit.Framework;
    using SqlDbBackAndRestore.Core.Tasks;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    [TestFixture]
    public class SqlTaskTests
    {
        private string databaseName = "JobServiceApplication";
        private string connectionString = "";
        private string path = "C://";

        [SetUp]
        public void Init()
        {
            this.connectionString = string.Format("Data Source=.;Initial Catalog={0};Integrated Security=True;", this.databaseName);
        }

        [Test]
        public void SqlBackUpTaskGetEventNotifyFinishMessageShouldReturnCorrectResult()
        {
            SqlBackUpTask sqlBackUpTask = new SqlBackUpTask(this.connectionString, this.databaseName, this.path);
            string actual = sqlBackUpTask.GetEventNotifyFinishMessage();
            Assert.AreEqual("Backup for database " + this.databaseName + " was successfully created.", actual);
        }

        [Test]
        public void SqlRestoreTaskGetEventNotifyFinishMessageShouldReturnCorrectResult()
        {
            SqlRestoreTask sqlRestoreTask = new SqlRestoreTask(this.connectionString, this.databaseName, this.path);
            string actual = sqlRestoreTask.GetEventNotifyFinishMessage();
            Assert.AreEqual("Database " + this.databaseName + " was successfully restored", actual);
        }

        public void SqlBackUpTaskExecuteSqlCommandShouldWorkCorrect()
        {
            var mockTrx = new Mock<IDbTransaction>();
            mockTrx.Setup(x => x.Connection.CreateCommand())
                .Returns(new SqlCommand());
            
        }


        /*
        public void SqlBackUpTaskGetEventNotifyFinishMessageShouldReturnCorrectResult()
        {
            string message = "H3LL0!";
            var mockedSqlBackUpTask = new Mock<SqlBackUpTask>();
            mockedSqlBackUpTask.Setup(x => x.GetEventNotifyFinishMessage())
                .Returns(message);



        }
        */
    }
}
