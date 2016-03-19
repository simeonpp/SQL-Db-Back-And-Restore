namespace SqlDbBackAndRestore.Core.Contracts
{
    public interface ISqlTaskFactory
    {
        ITask GetSqlBackupDbTask(string databaseName, string pathToSave);

        ITask GetSqlRestoreDbTast(string databaseName, string restoreFilePath);
    }
}
