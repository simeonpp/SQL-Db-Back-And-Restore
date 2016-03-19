namespace SqlDbBackAndRestore.Core.Contracts
{
    public interface ISqlTaskFactory
    {
        ITask GetSqlBackupDbTask(string tableName, string pathToSave);

        ITask GetSqlRestoreDbTast(string tableName, string restoreFilePath);
    }
}
