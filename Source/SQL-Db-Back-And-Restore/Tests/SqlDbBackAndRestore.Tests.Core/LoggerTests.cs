namespace SqlDbBackAndRestore.Tests.Core
{
    using Moq;
    using NUnit.Framework;
    using SqlDbBackAndRestore.Core;
    using SQLDbBackAndRestore.Logger;
    using SQLDbBackAndRestore.Logger.Contracts;
    using System;

    [TestFixture]
    public class LoggerTests
    {
        private string messageToLog = "Hell0 J0b S3rV!ce Applicat!0n";

        [Test]
        public void LogShouldLogMessageWhenInDebugMode()
        {
            var mockedLogger = new Mock<ILogger>();
            var taskManager = new TaskManager(true, mockedLogger.Object);

            taskManager.Log(this.messageToLog);
            mockedLogger.Verify(x => x.Log(It.Is<string>(s => s == this.messageToLog)));
        }
    }
}
