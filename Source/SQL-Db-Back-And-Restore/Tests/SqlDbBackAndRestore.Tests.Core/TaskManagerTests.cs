namespace SqlDbBackAndRestore.Tests.Core
{
    using System.Threading;
    using NUnit.Framework;
    using SqlDbBackAndRestore.Core;
    using SqlDbBackAndRestore.Core.Tasks;
    using Moq;
    using SqlDbBackAndRestore.Core.Contracts;
    using SQLDbBackAndRestore.Logger.Contracts;

    [TestFixture]
    public class TaskManagerTests
    {

        private TaskManager taskManager;

        private string databaseName = "JobServiceApplication";
        private string connectionString = "";
        private string path = "C://";

        [SetUp]
        public void Init()
        {
            this.taskManager = new TaskManager();
            this.connectionString = string.Format("Data Source=.;Initial Catalog={0};Integrated Security=True;", this.databaseName);
        }

        [Test]
        public void GetThreadShouldReturnThreadWithCorrectTask()
        {
            SqlTaskFactory sqlTaskFactory = new SqlTaskFactory();
            ITask sqlBackUpTask = sqlTaskFactory.GetSqlBackupDbTask(this.connectionString, this.path);

            Thread thread = this.taskManager.GetThread(sqlBackUpTask);
            Assert.AreEqual(thread.Name, "Task manager thread #1");
        }

        [Test]
        public void ProcessTaskShouldCallTaskExecuteMethod()
        {
            var mockedTask = new Mock<ITask>();
            this.taskManager.ProcessTask(mockedTask.Object);
            mockedTask.Verify(x => x.Execute());
        }
    }
}
