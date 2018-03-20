using PizzaDelivery.ViewModel.ViewModels;

namespace PizzaDelivery.ViewModel.Interfaces
{
    public interface IDeliveryVMService
    {
        OrderDeliveryVM GetDeliveryInformation();
    }
}