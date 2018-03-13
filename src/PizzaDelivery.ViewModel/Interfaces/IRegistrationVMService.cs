using System;
using System.Collections.Generic;
using System.Text;
using PizzaDelivery.ViewModel.ViewModels.Client;

namespace PizzaDelivery.ViewModel.Interfaces
{
    public interface IRegistrationVMService
    {
        void RegisterNewClient(RegistrationVM registrationVm);
    }
}
