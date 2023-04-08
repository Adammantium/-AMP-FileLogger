using AMP.DedicatedServer;
using AMP.Logging;
using System;
using System.IO;

namespace FileLogger {
    public class FileLogger : AMP_Plugin {

        public override string NAME    => "FileLogger";
        public override string AUTHOR  => "Adammantium";
        public override string VERSION => "1.0.0";

        private string folder  = "logs";
        private string logFile = "server.{0}.log";

        public override void OnStart() {
            if(!Directory.Exists(folder)) Directory.CreateDirectory(folder);

            logFile = string.Format(logFile, ServerInit.port);

            logFile = folder + "/" + logFile;

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
