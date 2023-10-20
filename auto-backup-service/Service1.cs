    using Microsoft.Win32;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.ServiceProcess;
    using System.Text;
    using System.Threading.Tasks;

    namespace auto_backup_service
    {
        public partial class Service1 : ServiceBase
        {
            
            private const string logFilePath = "D:\\logs.txt";
            public Service1()
            {
                InitializeComponent();
            Microsoft.Win32.SystemEvents.SessionEnding += new SessionEndingEventHandler(SystemEvents_SessionEnding);
        }
            void SystemEvents_SessionEnding(object sender, SessionEndingEventArgs e)
            {
                File.AppendAllText(logFilePath, "System Shutdown at " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + Environment.NewLine);
            }
            protected override void OnStart(string[] args)

            {
            
                File.AppendAllText(logFilePath, "Service Started at " + DateTime.Now.ToString("dd-mm-yyyy HH:mm:ss")+ Environment.NewLine);
            }

            protected override void OnStop()
            {
                File.AppendAllText(logFilePath,"[" + DateTime.Now.ToString("dd-mm-yyyy HH:mm:ss") + "]" + "Service Stoped " +  Environment.NewLine);
              //  File.AppendAllText(logFilePath, "Service Stoped at " + DateTime.Now.ToString("dd-mm-yyyy HH:mm:ss") + Environment.NewLine);
            }

            protected override void OnShutdown()
            {
                File.AppendAllText("D:\\shutdown-logs.txt", "Shutted Down" + Environment.NewLine);
                File.AppendAllText(logFilePath, "System Shutdown at " + DateTime.Now.ToString("dd-mm-yyyy HH:mm:ss") + Environment.NewLine);

                base.OnShutdown();
            }
        }
    }
