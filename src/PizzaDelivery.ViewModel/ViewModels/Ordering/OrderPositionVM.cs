using System;
using System.ComponentModel.DataAnnotations;
using PizzaDelivery.ViewModel.ViewModels.Main.PizzaPage;

namespace PizzaDelivery.ViewModel.ViewModels.Ordering
{
    public class OrderPositionVM
    {
        public PizzaVM Pizza { get; set; }

        [Display(Name = "Количество")]
        public int Count { get; set; }

        [Display(Name = "Сумма")]
        public decimal Sum => Count * (Pizza?.Cost ?? 0);
    }
}
