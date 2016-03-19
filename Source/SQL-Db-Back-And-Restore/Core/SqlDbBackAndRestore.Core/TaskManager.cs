namespace SqlDbBackAndRestore.Core
{
    using System;
    using Contracts;
    using SQL_Db_Back_and_Restore.Logger.Contracts;
    using SQL_Db_Back_and_Restore.Logger;

    public class TaskManager : ITaskManager
    {
        private static volatile TaskManager instance;
        private static object syncLock = new object();
        private bool debugMode;
        private ILogger logger;
        private int threadCounter = 0;

        public void ProccesTask(ITask task)
        {
            throw new NotImplementedException();
        }

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
    }
}
