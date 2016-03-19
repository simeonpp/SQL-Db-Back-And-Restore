namespace SqlDbBackAndRestore.ConsoleClient
{
    using Core;
    using Core.Contracts;
    using SQL_Db_Back_and_Restore.Logger;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class StartUp
    {
        private static ITaskManager taskManager;
        private static ISqlTaskFactory sqlTaskFactory;

        static void Main()
        {
            taskManager = TaskManager.GetInstance(true, new ConsoleLogger());
            sqlTaskFactory = new SqlTaskFactory();

            AskForUserInput();
        }

        private static void AskForUserInput()
        {
            PrintImportantMessage("Welcome to Job Service Application", true);

            int userInputOption = 1;
            do
            {
                Console.WriteLine("Please choose what you like to do (Enter a number and then enter:");
                Console.WriteLine("Available options:");
                Console.WriteLine(string.Format("{0}[1]: Back up a database", '\t'));
                Console.WriteLine(string.Format("{0}[2]: Restore database from back up", '\t'));
                Console.WriteLine(string.Format("{0}[0]: Exit", '\t'));

                string userInput = Console.ReadLine();
                int.TryParse(userInput, out userInputOption);

                switch (userInputOption)
                {
                    case 1:
                        HandleBackUpOption();
                        break;
                    case 2:
                        HandleRestoreOption();
                        break;
                    case 0:
                        PrintImportantMessage("Thank you for using Job Service Application.", true);
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please choose one of the available options.");
                        break;
                }
            }
            while (userInputOption != 0);
        }

        private static void HandleBackUpOption()
        {
            Console.WriteLine("Please enter table name:");
            string tableName = Console.ReadLine();

            string envirementDirectory = Environment.CurrentDirectory;
            ITask backUpDbTask = sqlTaskFactory.GetSqlBackupDbTask(tableName, envirementDirectory);
            taskManager.ProcessTask(backUpDbTask);

            PrintImportantMessage("Your task is processing. You will be notified when you task is finished. While you are waiting you can run another process.");
        }

        private static void HandleRestoreOption()
        {
            Console.WriteLine("HandleResoreOption");
        }

        private static void PrintImportantMessage(string message, bool uppercase = false)
        {
            if (uppercase)
            {
                message = message.ToUpper();
            }

            string spacer = new string('=', 50);
            Console.WriteLine(string.Format("{0}{1}{2}{3}{4}",
                spacer,
                Environment.NewLine,
                message,
                Environment.NewLine,
                spacer));
        }
    }
}
