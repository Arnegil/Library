using System;
using System.Collections.Generic;
using System.Text;
using PizzaDelivery.Domain.Models.Orders;
using PizzaDelivery.ViewModel.Interfaces.Converiton;
using PizzaDelivery.ViewModel.ServicesImpl.Converiton;
using PizzaDelivery.ViewModel.ViewModels.Main.PizzaPage;

namespace PizzaDelivery.ViewModel.Factories
{
    public class MapperFactory
    {
        public IMapper GetMapper()
        {
            var mapper =  new Mapper();
            mapper.SetAutoMap<Pizza, PizzaVM>();

            return mapper;
        }
    }
}
