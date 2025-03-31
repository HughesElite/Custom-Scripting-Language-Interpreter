using System;
using System.Diagnostics;
using System.IO;

namespace ASE_Assignment_Ashley_Hughes
{
    /// <summary>
    /// Singleton logger class for centralised error handling.
    /// </summary>
    public class ErrorLogger
    {
        private static ErrorLogger _instance;
        private static readonly object _lock = new object();
        private string logFilePath;

        /// <summary>
        /// Private constructor that initialises the log file path and ensures directory exists.
        /// </summary>
        private ErrorLogger()
        {
            // Set the specific path
            logFilePath = @"C:\Users\G16\source\repos\ase-boose-assignment-HughesElite\ASE Assignment Ashley Hughes\ErrorLoggerOutput\errorlog.txt";
            // Makes sure the directory exists
            string directoryPath = Path.GetDirectoryName(logFilePath);
            if (!Directory.Exists(directoryPath))
            {
                try
                {
                    Directory.CreateDirectory(directoryPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to create directory: {ex.Message}");
                }
            }
            Console.WriteLine($"Log file will be created at: {logFilePath}");
        }

        /// <summary>
        /// Gets the singleton instance of the ErrorLogger.
        /// </summary>
        public static ErrorLogger Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ErrorLogger();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// Logs an error message to the console and log file.
        /// </summary>
        /// <param name="message">The error message to log.</param>
        public void LogError(string message)
        {
            // Logs to console
            Console.WriteLine($"Error: {message}");
            // Logs to file
            try
            {
                File.AppendAllText(logFilePath, $"{DateTime.Now}: {message}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write to log file: {ex.Message}");
            }
        }
    }
}