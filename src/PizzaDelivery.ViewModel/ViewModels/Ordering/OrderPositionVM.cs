using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaDelivery.ViewModel.ViewModels.Ordering
{
    public class OrderPositionVM
    {
        public Guid PizzaId { get; set; }

        [Display(Name = "Название")]
        public string PizzaName { get; set; }

        [Display(Name = "Состав")]
        public string PizzaRecipe { get; set; }

        [Display(Name = "Цена")]
        public decimal Cost { get; set; }

        [Display(Name = "Количество")]
        public int Count { get; set; }

        [Display(Name = "Сумма")]
        public decimal Sum => Count * Cost;
    }
}
