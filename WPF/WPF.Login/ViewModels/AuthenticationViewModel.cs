using Haley.Abstractions;
using Haley.Models;
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
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { SetProp(ref _currentView, value); }
        }


        public ICommand CmdChangeView => new DelegateCommand<object>((o) => CurrentView = o);
        public ICommand CmdCreateAccount => new DelegateCommand(_createAccount);

        public ICommand CmdSingIn => new DelegateCommand(_singIn);

        public ICommand CmdSendEmail => new DelegateCommand(_sendEmail);

        private void _sendEmail()
        {
            //SEND EMAIL RECOVER PASSWORD
        }

        private void _singIn()
        {
            //Sing in.
            InvokeVMClosed(this, new Haley.Events.FrameClosingEventArgs(true,"Authenticated"));
        }

        private void _createAccount()
        {
            //Create account
            //DO THE METHODS

            //Changeview
            CurrentView = Views.ViewEnums.LoginPage;
        }

        public AuthenticationViewModel()
        {
            CurrentView = Views.ViewEnums.LoginPage;
        }
    }
}
