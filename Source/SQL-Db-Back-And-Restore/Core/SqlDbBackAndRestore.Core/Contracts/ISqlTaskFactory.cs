namespace SqlDbBackAndRestore.Core.Contracts
{
    public interface ISqlTaskFactory
    {
        ITask GetSqlBackupDbTask(string connectionString, string pathToSave);

        ITask GetSqlRestoreDbTask(string connectionString, string restoreFilePath);
    }
}
