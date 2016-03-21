namespace SqlDbBackAndRestore.Core
{
    using System.Threading;
    using Contracts;
    using SQLDbBackAndRestore.Logger;
    using SQLDbBackAndRestore.Logger.Contracts;

    public class TaskManager : ITaskManager
    {
        private bool debugMode;
        private ILogger logger;
        private int threadCounter = 0;

        public TaskManager(ILogger logger, bool debugMode = false)
        {
            this.debugMode = debugMode;
            this.logger = logger;
        }

        public void ProcessTask(ITask task)
        {
            Thread thread = this.GetThread(task);
            this.Log(string.Format("Executing task on Thred: {0}", thread.Name));
            thread.Start();
        }

        internal Thread GetThread(ITask task)
        {
            Thread thread = new Thread(new ThreadStart(task.Execute));
            thread.Name = string.Format("Task manager thread #{0}", ++this.threadCounter);
            return thread;
        }

        internal void Log(string message)
        {
            if (this.debugMode)
            {
                this.logger.Log(message);
            }
        }
    }
}
