namespace SqlDbBackAndRestore.Core.Contracts
{
    public interface ISqlTaskFactory
    {
        ITask GetSqlBackupDbTask();

        ITask GetSqlRestoreDbTast();
    }
}
