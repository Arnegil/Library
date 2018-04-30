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

        public PaymentInfoVM GetPartOfPaymentInfo(string login)
        {
            var payment = new PaymentInfoVM();
            
            var client = _clientService.GetClientByLogin(login);
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