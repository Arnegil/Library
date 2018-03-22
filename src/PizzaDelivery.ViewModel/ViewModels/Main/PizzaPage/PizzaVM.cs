using System;

namespace PizzaDelivery.ViewModel.ViewModels.Main.PizzaPage
{
    public class PizzaVM
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Recipe { get; set; }
        
        public decimal Cost { get; set; }
    }
}
