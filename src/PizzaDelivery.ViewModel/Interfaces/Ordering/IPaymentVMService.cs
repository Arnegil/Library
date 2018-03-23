using PizzaDelivery.ViewModel.ViewModels.Ordering;

namespace PizzaDelivery.ViewModel.Interfaces.Ordering
{
    public interface IPaymentVMService
    {
        PaymentInfoVM GetPaymentInfo();
        void SavePaymentInfo(PaymentInfoVM paymentInfoVm);
    }
}