using ArhitectureConcept.Interfaces.Services;

namespace ArhitectureConcept.Services
{
    public class ConsoleLoggerService : ILoggerService
    {
        public void Log(string text)
        {
            System.Diagnostics.Debug.Write(text);
        }

        public void LogLine(string text)
        {
            System.Diagnostics.Debug.WriteLine(text);
        }
    }
}
