using SqlDbBackAndRestore.Core.Tasks;

namespace SqlDbBackAndRestore.Core.Contracts
{
    public interface ITask
    {
        void Execute();

        event TaskFinished Finished;
    }
}
