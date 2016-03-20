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

        private Mock<IDbConnection> connectionMock;
        private Mock<IDbCommand> commandMock;

        [SetUp]
        public void Init()
        {
            this.connectionString = string.Format("Data Source=.;Initial Catalog={0};Integrated Security=True;", this.databaseName);
            this.connectionMock = new Mock<IDbConnection>();
            this.commandMock = new Mock<IDbCommand>();
        }
                
        [Test]
        public void SqlBackUpTaskGetEventNotifyFinishMessageShouldReturnCorrectResult()
        {
            SqlBackUpTask sqlBackUpTask = new SqlBackUpTask(this.connectionMock.Object, this.commandMock.Object, this.databaseName);
            string actual = sqlBackUpTask.GetEventNotifyFinishMessage();
            Assert.AreEqual("Backup for database " + this.databaseName + " was successfully created.", actual);
        }

        [Test]
        public void SqlRestoreTaskGetEventNotifyFinishMessageShouldReturnCorrectResult()
        {
            SqlRestoreTask sqlRestoreTask = new SqlRestoreTask(this.connectionMock.Object, this.commandMock.Object, this.databaseName);
            string actual = sqlRestoreTask.GetEventNotifyFinishMessage();
            Assert.AreEqual("Database " + this.databaseName + " was successfully restored", actual);
        }

        [Test]
        public void SqlBackUpTaskExecuteShouldWorkCorrectly()
        {
            SqlBackUpTask sqlBackUpTask = new SqlBackUpTask(this.connectionMock.Object, this.commandMock.Object, this.databaseName);
            sqlBackUpTask.Execute();

            this.connectionMock.Verify(x => x.Open(), Times.Once);
            this.connectionMock.Verify(x => x.Close(), Times.Once);
            this.commandMock.Verify(x => x.ExecuteNonQuery(), Times.Once);
            this.connectionMock.Verify(x => x.Dispose(), Times.Once);
        }

        public void SqlRestoreTaskExecuteSouldWorkCorrectly()
        {
            SqlRestoreTask sqlRestoreTask = new SqlRestoreTask(this.connectionMock.Object, this.commandMock.Object, this.databaseName);
            sqlRestoreTask.Execute();

            this.connectionMock.Verify(x => x.Open(), Times.Once);
            this.connectionMock.Verify(x => x.Close(), Times.Once);
            this.commandMock.Verify(x => x.ExecuteNonQuery(), Times.Once);
            this.connectionMock.Verify(x => x.Dispose(), Times.Once);
        }
    }
}
