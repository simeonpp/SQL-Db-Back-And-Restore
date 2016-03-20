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
        private SqlBackUpTask sqlBackUpTask;

        private string databaseName = "JobServiceApplication";
        private string connectionString = "";
        private string path = "C://";

        [SetUp]
        public void Init()
        {
            this.taskManager = TaskManager.GetInstance();
            this.connectionString = string.Format("Data Source=.;Initial Catalog={0};Integrated Security=True;", this.databaseName);
            this.sqlBackUpTask = new SqlBackUpTask(this.connectionString, this.databaseName, this.path);
        }

        [Test]
        public void GetThreadShouldReturnThreadWithCorrectTask()
        {            
            Thread thread = this.taskManager.GetThread(this.sqlBackUpTask);
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
