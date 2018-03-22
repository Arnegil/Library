using PizzaDelivery.ViewModel.ViewModels.Ordering;

namespace PizzaDelivery.ViewModel.Interfaces.Ordering
{
    public interface IDeliveryVMService
    {
        OrderDeliveryVM GetDeliveryInformation();
        void SaveDeliveryInfo(OrderDeliveryVM orderDelivery);
    }
}