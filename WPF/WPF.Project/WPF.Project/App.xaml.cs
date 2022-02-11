using Haley.Abstractions;
using Haley.MVVM;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPF.Login.Views;
using WPF.Login;
using Haley.IOC;

namespace WPF.Project
{
    /// <summary>
    /// Interação lógica para App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IDialogService _ds;

        protected override void OnStartup(StartupEventArgs e)
        {
            _ds = ContainerStore.Singleton.DI.Resolve<IDialogService>();
            Entry.Initialize(ContainerStore.Singleton.GetFactory());
            base.OnStartup(e);
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var _actualMainWindow = new MainWindow();

            int maxTries = 5;
            int tryCount = 0;
            while (!CredentialHolder.Singleton.IsAuthenticated)
            {
                var _result =ContainerStore.Singleton.Windows.ShowDialog("authMainWindow");
                if (_result.HasValue && _result.Value)
                {
                    CredentialHolder.Singleton.IsAuthenticated = true;
                    break;
                }
                tryCount++;
                if (tryCount >= maxTries) break;
            }

            if (CredentialHolder.Singleton.IsAuthenticated)
            {
                //SHOW MAIN WINDOW
                _actualMainWindow.Show();
            }
            else
            {
                _ds?.Error("Failure","Unable to authenticate! The Application will close.");
                if (Application.Current.MainWindow != null)
                {
                    Application.Current.MainWindow.Close();
                }
            }
        }

        private void ContainerRegistration()
        {

        }
    }
}
