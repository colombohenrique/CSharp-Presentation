using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haley.Abstractions;
using Haley.Enums;
using Haley.Events;
using Haley.Models;
using Haley.MVVM;
using Haley.Utils;
using WPF.Login.ViewModels;
using WPF.Login.Views;
using Haley.IOC;

namespace WPF.Login
{
    public class Entry
    {

        public static void Initialize(IContainerFactory containerFactory)
        {
            //Base Registration
            if (containerFactory.Services is IBaseContainer baseContainer)
            {
                //Lidando apenas com o haley
                baseContainer.Register<AuthenticationViewModel>();
            }

            //UI Registration
            containerFactory.Controls.Register<AuthenticationViewModel,LoginPage>(Views.ViewEnums.LoginPage);
            containerFactory.Controls.Register<AuthenticationViewModel,LoginHelperPage>(Views.ViewEnums.LoginHelperPage);
            containerFactory.Controls.Register<AuthenticationViewModel,SignupPage>(Views.ViewEnums.SignupPage);

            //WindowRegistrations
            containerFactory.Windows.Register<AuthenticationViewModel, AuthenticationWindow>("authMainWindow");

        }
    }
}
