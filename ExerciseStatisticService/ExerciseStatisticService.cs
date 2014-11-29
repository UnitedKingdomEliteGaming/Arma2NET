using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace ExerciseStatisticService
{
    public partial class ExerciseStatisticService : ServiceBase
    {
        #region static void Main(string[] args)
        //static void Main(string[] args)
        static void Main(string[] args)
        {
            #region CurrentDirectory zum Installationspfad verlegen
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            path = System.IO.Path.GetDirectoryName(path);
            System.IO.Directory.SetCurrentDirectory(path);
            #endregion

            #region Service installieren/deinstallieren/debuggen
            if (args.Length > 0)
            {
                InternalInstallUtil installUtil = new InternalInstallUtil();
                for (int i = 0; i < args.Length; i++)
                {
                    switch (args[i].ToUpper())
                    {
                        case "/I":
                            {
                                installUtil.InstallService();
                                return;
                            }
                        case "/U":
                            {
                                installUtil.UninstallService();
                                return;
                            }
                        case "/D":
                            {
                                #region NLog konfigurieren ExerciseStatisticService
                                {
                                    NLog.Config.LoggingConfiguration configuration;
                                    NLog.Targets.ColoredConsoleTarget consoleTarget = new NLog.Targets.ColoredConsoleTarget();
                                    consoleTarget.Name = "console";
                                    consoleTarget.Layout = "[${level}] ${longdate}: ${callsite} ||| ${message} ${Exception}";
                                    configuration = new NLog.Config.LoggingConfiguration();
                                    configuration.AddTarget("console", consoleTarget);
                                    configuration.LoggingRules.Add(new NLog.Config.LoggingRule("*", NLog.LogLevel.Trace, consoleTarget));

                                    NLog.LogManager.Configuration = configuration;
                                }
                                #endregion

                                ExerciseStatisticService service = new ExerciseStatisticService();
                                service.OnStart(null);
                                Console.WriteLine("Service Started...");
                                Console.WriteLine("<press any key to exit...>");
                                while (Console.Read() == -1) { System.Threading.Thread.Sleep(100); };
                                service.OnStop();
                                return;
                            }
                        default:
                            break;
                    }
                }
            }
            #endregion

            #region NLog konfigurieren ExerciseStatisticService
            {
                NLog.Config.LoggingConfiguration configuration;
                string configFile = System.IO.Path.Combine(Environment.CurrentDirectory, "ExerciseStatisticService.NLog.config");
                if (System.IO.File.Exists(configFile))
                    configuration = new NLog.Config.XmlLoggingConfiguration(configFile);
                else
                {
                    NLog.Targets.ColoredConsoleTarget consoleTarget = new NLog.Targets.ColoredConsoleTarget();
                    consoleTarget.Name = "console";
                    consoleTarget.Layout = "[${level}] ${longdate}: ${callsite} ||| ${message} ${Exception}";
                    configuration = new NLog.Config.LoggingConfiguration();
                    configuration.AddTarget("console", consoleTarget);
                    configuration.LoggingRules.Add(new NLog.Config.LoggingRule("*", NLog.LogLevel.Trace, consoleTarget));
                }

                NLog.LogManager.Configuration = configuration;
            }
            #endregion

            // Wenn wir bis hierher kommen, dann kann der Service normal gestartet werden.
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new ExerciseStatisticService() 
			};
            ServiceBase.Run(ServicesToRun);
        }
        #endregion

        private DatabaseManager _DatabaseManager; 

        public ExerciseStatisticService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _DatabaseManager = new DatabaseManager(ConfigurationXml.Load());
        }

        protected override void OnStop()
        {
            _DatabaseManager.Dispose();
            _DatabaseManager = null;
        }
    }
}
