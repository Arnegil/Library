using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaDelivery.ViewModel.ViewModels
{
    public class OrderResultVM
    {
        public OrderVM Order { get; set; }

        public bool SuccessOrdered { get; set; }
    }
}
