using System;

namespace PizzaDelivery.ViewModel.ViewModels.Ordering
{
    public class OrderPositionVM
    {
        public Guid PizzaId { get; set; }

        public string PizzaName { get; set; }

        public string PizzaRecipe { get; set; }

        public decimal Cost { get; set; }

        public int Count { get; set; }

        public decimal Sum => Count * Cost;
    }
}
