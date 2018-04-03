using System;
using System.Collections.Generic;
using ArhitectureConcept.Interfaces.Services;

namespace ArhitectureConcept.Services
{
    public class TextFileLoggerService : ILoggerService
    {
        private readonly string currentTextFileName;
        public TextFileLoggerService()
        {
            currentTextFileName = $"LoggerService-{DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year}.txt";
            System.IO.File.AppendAllText(currentTextFileName, "### Start app ###" + Environment.NewLine);
        }
        public void Log(string text)
        {
            System.IO.File.AppendAllText(currentTextFileName, text);
        }

        public void LogLine(string text)
        {
            System.IO.File.AppendAllLines(currentTextFileName, new List<string>() {text});
        }
    }
}
