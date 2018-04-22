using PizzaDelivery.ViewModel.ViewModels.PersonalPages.Client;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace PizzaDelivery.ViewModel.Interfaces.ViewModel
{
    public interface ILoginVMService
    {
        ClaimsPrincipal LogInUser(LoginVM login);
    }
}
