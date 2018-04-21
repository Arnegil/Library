using PizzaDelivery.ViewModel.ViewModels.PersonalPages.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaDelivery.ViewModel.Interfaces.ViewModel
{
    public interface ILoginVMService
    {
        void LogInUser(LoginVM login);
    }
}
