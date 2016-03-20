﻿namespace SqlDbBackAndRestore.ConsoleClient
{
    using Core;
    using Core.Contracts;
    using SQLDbBackAndRestore.Logger;
    using System;

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

        /// <summary>
        /// Here we are requesting a user to input only database name and build connection string for him 
        /// based on integrated security. 
        /// However, we can requires the full connection string the user but for testing purposes we will
        /// this like this.
        /// </summary>
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
            Console.WriteLine("Please enter database name:");
            string databaseName = Console.ReadLine();

            string envirementDirectory = Environment.CurrentDirectory;
            string connectionString = string.Format("Data Source=.;Initial Catalog={0};Integrated Security=True;MultipleActiveResultSets=true", databaseName);

            ITask backUpDbTask = sqlTaskFactory.GetSqlBackupDbTask(connectionString, envirementDirectory);
            backUpDbTask.Finished += ObservableTaskFinished;
            taskManager.ProcessTask(backUpDbTask);

            PrintImportantMessage("Your task is processing. You will be notified when you task is finished. While you are waiting you can run another process.");
        }

        private static void HandleRestoreOption()
        {
            Console.WriteLine("Please enter database name:");
            string databaseName = Console.ReadLine();

            Console.WriteLine("Please the full (absolute) path to your .bak file");
            string bakFilePath = Console.ReadLine();
            string connectionString = string.Format("Data Source=.;Initial Catalog={0};Integrated Security=True;MultipleActiveResultSets=true", databaseName);

            string lastFourChars = bakFilePath.Substring(bakFilePath.Length - 4);
            if (lastFourChars != ".bak")
            {
                Console.WriteLine("Invalid file path. The file extension should be 'bak'");
            }
            else
            {
                ITask restoreDbTask = sqlTaskFactory.GetSqlRestoreDbTast(connectionString, bakFilePath);
                taskManager.ProcessTask(restoreDbTask);
            }
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

        private static void PrintEventNotifyMessage(string message)
        {
            string spacer = new string('*', 25);
            Console.WriteLine(string.Format("{0}{1}{2}{3}{4}",
                spacer,
                Environment.NewLine,
                message,
                Environment.NewLine,
                spacer));
        }

        private static void ObservableTaskFinished(object sender, string message)
        {
            PrintEventNotifyMessage(string.Format("{0}{1}{2}{3}{4}", 
                "NOTIFICATION", 
                Environment.NewLine, 
                message, 
                Environment.NewLine, 
                "This does not affect your current actions."));
        }
    }
}
