using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaDelivery.ViewModel.ViewModels.Main.PizzaPage
{
    public class PizzaVM
    {
        public Guid Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Состав")]
        public string Recipe { get; set; }

        [Display(Name = "Цена")]
        public decimal Cost { get; set; }

        private sealed class IdEqualityComparer : IEqualityComparer<PizzaVM>
        {
            public bool Equals(PizzaVM x, PizzaVM y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id.Equals(y.Id);
            }

            public int GetHashCode(PizzaVM obj)
            {
                return obj.Id.GetHashCode();
            }
        }

        public static IEqualityComparer<PizzaVM> IdComparer { get; } = new IdEqualityComparer();
    }
}
