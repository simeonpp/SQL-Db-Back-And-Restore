namespace SqlDbBackAndRestore.Core.Tasks
{
    using System;
    using Contracts;

    public abstract class BaseTask : ITask
    {
        public abstract void Execute();
    }
}
