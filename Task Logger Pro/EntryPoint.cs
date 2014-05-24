﻿using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Text;
using Task_Logger_Pro.Controls;
using System.Configuration;
using Task_Logger_Pro.Utils;


namespace Task_Logger_Pro
{
    public static class EntryPoint
    {
        [STAThread]
        public static void Main(string[] args)
        {
            try
            {
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                SingleInstanceManager singleInstanceApp = new SingleInstanceManager();
                singleInstanceApp.Run(args);
            }
            catch (Exception ex)
            {
                Exceptions.Logger.DumpExceptionInfo(ex);
                throw;
            }
        }

        static bool ToggleConfigEncryption(string exeConfigName)
        {
            // Takes the executable file name without the
            // .config extension.
            try
            {
                Configuration config = ConfigurationManager.
                    OpenExeConfiguration(exeConfigName);

                ConnectionStringsSection section =
                    config.GetSection("connectionStrings")
                    as ConnectionStringsSection;

                if (section.SectionInformation.IsProtected)
                {
                    return true;
                }
                else
                {
                    section.SectionInformation.ProtectSection(
                        "DataProtectionConfigurationProvider");
                }
                config.Save();

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        static void CurrentDomain_UnhandledException(object sender, System.UnhandledExceptionEventArgs e)
        {
            try
            {
                //if (App.DataLogger != null) 
                //    App.DataLogger.FinishLogging(); //no screenshots or keylogging
                Exception ex = e.ExceptionObject as Exception;
                Task_Logger_Pro.Exceptions.Logger.DumpExceptionInfo(ex);
                if (App.UzerSetting != null)
                {
                    if (!App.UzerSetting.Stealth)
                    {
                        System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            MessageWindow messageWindow = new MessageWindow("Ooops, this is awkward ... something went wrong." +
                                Environment.NewLine + "The app needs to close." + Environment.NewLine + "Error: " + ex.Message);
                            messageWindow.ShowDialog();
                        }));
                    }
                }
            }
            finally
            {
                (App.Current as App).FinishAndExit(false);
            }
        }

        public class SingleInstanceManager : WindowsFormsApplicationBase
        {
            public static event EventHandler SecondInstanceActivating;

            public SingleInstanceManager()
            {
                this.IsSingleInstance = true;
            }

            protected override bool OnStartup(StartupEventArgs eventArgs)
            {
                if (eventArgs.CommandLine.Count == 0)
                {
                    System.Windows.SplashScreen splashScreen = new System.Windows.SplashScreen("resources/appstrackersplashresized.png");
                    splashScreen.Show(true);
                }
                App app = new App(eventArgs.CommandLine);
                app.Run();
                return false;
            }

            protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
            {
                base.OnStartupNextInstance(eventArgs);
                if (SecondInstanceActivating != null) SecondInstanceActivating(this, new EventArgs());
            }
        }
    }
}