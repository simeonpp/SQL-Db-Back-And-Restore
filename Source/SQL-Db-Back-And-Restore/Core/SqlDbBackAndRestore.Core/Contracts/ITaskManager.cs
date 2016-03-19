namespace SqlDbBackAndRestore.Core.Contracts
{
    public interface ITaskManager
    {
        void ProcessTask(ITask task);
    }
}
