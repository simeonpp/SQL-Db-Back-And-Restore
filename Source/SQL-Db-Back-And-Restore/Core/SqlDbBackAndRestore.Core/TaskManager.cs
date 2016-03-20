namespace SqlDbBackAndRestore.Core
{
    using System.Threading;
    using Contracts;
    using SQLDbBackAndRestore.Logger;
    using SQLDbBackAndRestore.Logger.Contracts;

    public class TaskManager : ITaskManager
    {
        private static volatile TaskManager instance;
        private static object syncLock = new object();
        private bool debugMode;
        private ILogger logger;
        private int threadCounter = 0;
        
        /*
            Poor man's dependancy.
            Alternative solution would be use dependency injection, but because this
            class is Singleton the constructors are private therefore this approache
            is used
        */
        private TaskManager()
            : this(false, new ConsoleLogger())
        {
        }

        private TaskManager(bool debugMode, ILogger logger)
        {
            this.debugMode = debugMode;
            this.logger = logger;
        }

        public static TaskManager GetInstance(bool debugMode = false, ILogger logger = null)
        {
            if (instance == null)
            {
                lock (syncLock)
                {
                    if (instance == null)
                    {
                        if (debugMode && logger != null)
                        {
                            instance = new TaskManager(debugMode, logger);
                        }
                        else
                        {
                            instance = new TaskManager();
                        }
                    }
                }
            }

            return instance;
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

        private void Log(string message)
        {
            if (this.debugMode)
            {
                this.logger.Log(message);
            }
        }
    }
}
