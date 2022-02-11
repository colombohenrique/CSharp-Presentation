using Haley.Abstractions;
using Haley.Models;
using Haley.WPF.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF.Login.ViewModels
{
    public class AuthenticationViewModel : BaseVM
    {
        private IDialogService ds;

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { SetProp(ref _currentView, value); }
        }

        private string _login;
        public string Login
        {
            get { return _login; }
            set { SetProp(ref _login, value); }
        }


        public ICommand CmdChangeView => new DelegateCommand<object>((o) => CurrentView = o);


        public ICommand CmdSingIn => new DelegateCommand<object>(_singIn);
        private void _singIn(object obj)
        {
            //Sing in.

            var _lgn = Login;
            if(obj is PlainPasswordBox passwordBox)
            {
                var _password = passwordBox.GetPassword();
                string pass = "test";
                if (string.IsNullOrWhiteSpace(_password) || !_password.Equals(pass)) 
                {
                    ds?.SendToast("Error", "Password doesn't match!", Haley.Enums.NotificationIcon.Error);
                    return;
                }

            }
            InvokeVMClosed(this, new Haley.Events.FrameClosingEventArgs(true, "Authenticated"));
        }


        public ICommand CmdCreateAccount => new DelegateCommand(_createAccount);
        private void _createAccount()
        {
            //Create account
            //DO THE METHODS

            //Changeview
            CurrentView = Views.ViewEnums.LoginPage;
        }



        public ICommand CmdSendEmail => new DelegateCommand(_sendEmail);
        private void _sendEmail()
        {
            //SEND EMAIL RECOVER PASSWORD
        }
       

        public AuthenticationViewModel(IDialogService dialogService)
        {
            CurrentView = Views.ViewEnums.LoginPage;
            ds = dialogService;
        }
    }
}
