using System;
using PizzaDelivery.Services.Interfaces;
using PizzaDelivery.ViewModel.Interfaces.Ordering;
using PizzaDelivery.ViewModel.ViewModels.Ordering;

namespace PizzaDelivery.ViewModel.ServicesImpl.Ordering
{
    public class PaymentVMService : IPaymentVMService
    {
        private readonly IClientService _clientService;
        
        public PaymentVMService(IClientService clientService)
        {
            if (clientService == null)
                throw new ArgumentNullException(nameof(clientService));

            _clientService = clientService;
        }

        public PaymentInfoVM GetPartOfPaymentInfo()
        {
            var payment = new PaymentInfoVM();
            
            Guid clientId = Guid.Empty;
            var client = _clientService.GetClientById(clientId);

            if (client != null && client.HaveCardInfo)
            {
                payment.CardNumber = client.CardNumber;
                payment.CardOwnerName = client.CardOwnerName;
                payment.DateTo = client.DateTo.Value;
            }

            return payment;
        }
    }
}