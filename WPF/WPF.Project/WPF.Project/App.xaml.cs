using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPF.Login;
using WPF.Login.Controls;

namespace WPF.Project
{
    /// <summary>
    /// Interação lógica para App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var _actualMainWindow = new MainWindow();  
            while (!CredentialHolder.Singleton.IsAuthenticated)
            {
                var _authWindow = new AuthenticationWindow();
                _authWindow.ShowDialog();
            }

            if (CredentialHolder.Singleton.IsAuthenticated)
            {
                //SHOW MAIN WINDOW
                _actualMainWindow.Show();
            }
        }

        private void ContainerRegistration()
        {

        }
    }
}
