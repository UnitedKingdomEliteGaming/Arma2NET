using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace ExerciseStatisticService
{
    [RunInstaller(true)]
    public class ExerciseStatisticServiceInstaller : Installer
    {
        public ExerciseStatisticServiceInstaller()
        {
            ServiceProcessInstaller processInstaller = new ServiceProcessInstaller();
            ServiceInstaller serviceInstaller = new ServiceInstaller();

            //set the privileges
            processInstaller.Account = ServiceAccount.NetworkService;

            serviceInstaller.DisplayName = "ExerciseStatisticService";
            serviceInstaller.Description = "Ein Hintergrund Dienst, der eine Textdatei überwacht und dort die Übungsergebnisse von ARMA abfängt. Diese werden in einer XML zwischengespeichert und dann per FTP übertragen.";
            serviceInstaller.StartType = ServiceStartMode.Automatic;

            //must be the same as what was set in Program's constructor
            serviceInstaller.ServiceName = "ExerciseStatisticService";
            this.Installers.Add(processInstaller);
            this.Installers.Add(serviceInstaller);
        }
    }}
