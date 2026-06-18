using System;
using System.IO;

namespace DigitalShop.Services
{
    public static class LoggerService
    {
        private static readonly string LogPath = Path.Combine("Logs", "app.log");

        static LoggerService()
        {
            try
            {
                string logDir = Path.GetDirectoryName(LogPath);
                if (!Directory.Exists(logDir))
                    Directory.CreateDirectory(logDir);
            }
            catch { }
        }

        public static void Log(string level, string message)
        {
            try
            {
                string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {level} - {message}";
                File.AppendAllText(LogPath, logEntry + Environment.NewLine);
            }
            catch { }
        }

        public static void Info(string message) => Log("INFO", message);
        public static void Warning(string message) => Log("WARNING", message);
        public static void Error(string message) => Log("ERROR", message);
    }
}