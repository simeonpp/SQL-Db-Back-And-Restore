namespace SqlDbBackAndRestore.Core.Contracts
{
    public interface ISqlTaskFactory
    {
        ITask GetSqlBackupDbTask(string connectionString, string pathToSave);

        ITask GetSqlRestoreDbTast(string connectionString, string restoreFilePath);
    }
}
