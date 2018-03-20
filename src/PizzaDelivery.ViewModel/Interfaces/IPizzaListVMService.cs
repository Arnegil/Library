using System;
using System.Collections.Generic;
using System.Text;
using PizzaDelivery.ViewModel.ViewModels.Food;

namespace PizzaDelivery.ViewModel.Interfaces
{
    public interface IPizzaListVMService
    {
        PizzaListVM GetPizzaList(int page);
    }
}
