using PizzaDelivery.ViewModel.ViewModels.Ordering;

namespace PizzaDelivery.ViewModel.Interfaces.Ordering
{
    public interface IDeliveryVMService
    {
        DeliveryInfoVM GetPartOfDeliveryInformation(string login);
    }
}