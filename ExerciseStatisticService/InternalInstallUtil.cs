using System;
using System.Reflection;
using System.Configuration.Install;
using System.ServiceProcess;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExerciseStatisticService
{
    internal class InternalInstallUtil
    {
        #region nLog instance (LOG)
        protected static readonly NLog.Logger LOG = NLog.LogManager.GetCurrentClassLogger();
        #endregion
		
        public bool IsServiceInstalled()
        {
            return ServiceController.GetServices().Any(s => s.ServiceName == "ExerciseStatisticService");
        }

        public void InstallService()
        {
            if (IsServiceInstalled())
                UninstallService();

            LOG.Info("Installing service");
            ManagedInstallerClass.InstallHelper(new string[] { Assembly.GetExecutingAssembly().Location });
        }

        public void UninstallService()
        {
            LOG.Info("Uninstalling service");
            ManagedInstallerClass.InstallHelper(new string[] { "/u", Assembly.GetExecutingAssembly().Location });
        }
    }
}
