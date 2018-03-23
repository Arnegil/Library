using PizzaDelivery.ViewModel.ViewModels.Ordering;

namespace PizzaDelivery.ViewModel.Interfaces.Ordering
{
    public interface IDeliveryVMService
    {
        DeliveryInfoVM GetDeliveryInformation();
        void SaveDeliveryInfo(DeliveryInfoVM deliveryInfo);
    }
}