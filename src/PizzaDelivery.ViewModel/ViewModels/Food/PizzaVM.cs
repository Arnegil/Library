using System;

namespace PizzaDelivery.ViewModel.ViewModels.Food
{
    public class PizzaVM
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public decimal Cost { get; set; }
    }
}
