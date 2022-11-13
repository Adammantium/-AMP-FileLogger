using AMP.DedicatedServer;
using AMP.Logging;
using System;
using System.IO;

namespace FileLogger {
    public class FileLogger : AMP_Plugin {

        public override string NAME    => "FileLogger";
        public override string AUTHOR  => "Adammantium";
        public override string VERSION => "1.0.0";

        private string logFile = "server.log";
        public override void OnStart() {
            File.AppendAllLines(logFile, new string[] {"","",""});
            Log.onLogMessage += OnLogMessage;
        }

        private void OnLogMessage(Log.Type type, string message) {
            File.AppendAllLines(logFile, new string[] { 
                                                       $"[{ DateTime.Now.ToString("MM/dd/yyyy HH:mm") }] { type } { message }"
                                                      }
                               );
        }
    }
}
