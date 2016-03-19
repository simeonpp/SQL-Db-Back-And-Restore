namespace SqlDbBackAndRestore.Core.Tasks
{
    using System;
    using Contracts;

    internal abstract class BaseTask : ITask
    {
        public abstract void Execute();
    }
}
