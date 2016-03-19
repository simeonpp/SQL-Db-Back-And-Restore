namespace SQL_Db_Back_and_Restore.Logger
{
    using Contracts;
    using System;

    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            DateTime now = DateTime.Now;
            string nowFormatted = now.ToString("dd/MM/yyyy HH:mm:ss:fff");
            Console.WriteLine(string.Format("LOGGER {0}: {1}", nowFormatted, message));
        }
    }
}
