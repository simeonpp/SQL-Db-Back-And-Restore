namespace SqlDbBackAndRestore.Core.Contracts
{
    public interface ISqlTaskFactory
    {
        ITask GetSqlBackupDbTask(string tableName);

        ITask GetSqlRestoreDbTast(string tableName);
    }
}
