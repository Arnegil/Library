using System;
using PizzaDelivery.Services.Interfaces;
using PizzaDelivery.ViewModel.Interfaces.Ordering;
using PizzaDelivery.ViewModel.ViewModels.Ordering;

namespace PizzaDelivery.ViewModel.ServicesImpl.Ordering
{
    public class PaymentVMService : IPaymentVMService
    {
        private readonly Cache _cache;
        private readonly IClientService _clientService;
        
        public PaymentVMService(IClientService clientService, Cache cache)
        {
            if (clientService == null)
                throw new ArgumentNullException(nameof(clientService));

            _clientService = clientService;
            _cache = cache;
        }

        public PaymentInfoVM GetPaymentInfo()
        {
            var payment = _cache.PaymentInfoOfCurrentUser;

            if (payment.IsEmpty)
            {
                Guid clientId = Guid.Empty;
                var client = _clientService.GetClientById(clientId);

                if (client != null && client.HaveCardInfo)
                {
                    payment.CardNumber = client.CardNumber;
                    payment.CardOwnerName = client.CardOwnerName;
                    payment.DateTo = client.DateTo.Value;
                }
            }

            return payment;
        }

        public void SavePaymentInfo(PaymentInfoVM paymentInfo)
        {
            _cache.PaymentInfoOfCurrentUser.CardNumber = paymentInfo.CardNumber;
            _cache.PaymentInfoOfCurrentUser.CardOwnerName = paymentInfo.CardOwnerName;
            _cache.PaymentInfoOfCurrentUser.DateTo = paymentInfo.DateTo;
            _cache.PaymentInfoOfCurrentUser.PaymentType = paymentInfo.PaymentType;
        }
    }
}