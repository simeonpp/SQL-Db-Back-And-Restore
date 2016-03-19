namespace SqlDbBackAndRestore.Core.Tasks
{
    using Contracts;
    
    public delegate void TaskFinished(object sender, string message);

    public abstract class BaseTask : ITask
    {
        public event TaskFinished Finished;

        public abstract void Execute();

        protected abstract void NotifyFinish();
    }
}
