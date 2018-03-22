using System;
using System.Collections.Generic;
using System.Text;
using PizzaDelivery.ViewModel.ViewModels.Main.PizzaPage;

namespace PizzaDelivery.ViewModel.Interfaces
{
    public interface IPizzaVMService
    {
        void SavePizza(PizzaVM pizza);
        void DeletePizza(PizzaVM pizza);
    }
}
