using System;
using System.Collections.Generic;
using System.Text;
using PizzaDelivery.ViewModel.ViewModels.PersonalPages.Client;

namespace PizzaDelivery.ViewModel.Interfaces
{
    public interface IRegistrationVMService
    {
        void RegisterNewClient(RegistrationVM registrationVm);
    }
}
