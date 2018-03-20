using System;
using System.ComponentModel.DataAnnotations;
using PizzaDelivery.ViewModel.ViewModels.Food;

namespace PizzaDelivery.ViewModel.ViewModels.Client
{
    public class OrderPositionVM
    {
        public PizzaVM Pizza { get; set; }
        
        public int Count { get; set; }
    }
}
