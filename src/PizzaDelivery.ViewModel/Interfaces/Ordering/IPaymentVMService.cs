﻿using PizzaDelivery.ViewModel.ViewModels.Ordering;

namespace PizzaDelivery.ViewModel.Interfaces.Ordering
{
    public interface IPaymentVMService
    {
        PaymentVM GetPaymentInfo();
        void SavePaymentInfo(PaymentVM paymentVM);
    }
}