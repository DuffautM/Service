using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;

namespace Service
{
    public partial class Service1 : ServiceBase
    {

        private System.Timers.Timer t;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            this.t = new Timer(60000);
            this.t.AutoReset = true;
            this.t.Elapsed += new System.Timers.ElapsedEventHandler(WriteLog);
            this.t.Start();

        }

        protected override void OnStop()
        {
            this.t.Enabled = false;
        }

        private static void WriteLog(Object sender, ElapsedEventArgs e)
        {
            if (!System.Diagnostics.EventLog.SourceExists("Application"))
            {
                System.Diagnostics.EventLog.CreateEventSource("Application", "Application");

                using (EventLog log = new EventLog("Application")) {

                    log.Source = "Application";
                    log.WriteEntry("Coucou");

                }
            }

            else
            {
                using (EventLog log = new EventLog("Application"))
                {

                    log.Source = "Application";
                    log.WriteEntry("Coucou");

                }
            }
        }
    }
}
