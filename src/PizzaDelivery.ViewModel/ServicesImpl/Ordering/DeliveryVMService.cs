using System;
using PizzaDelivery.Services.Extensions;
using PizzaDelivery.Services.Interfaces;
using PizzaDelivery.ViewModel.Interfaces.Ordering;
using PizzaDelivery.ViewModel.ViewModels.Ordering;

namespace PizzaDelivery.ViewModel.ServicesImpl.Ordering
{
    public class DeliveryVMService : IDeliveryVMService
    {
        private readonly IClientService _clientService;
        
        public DeliveryVMService(IClientService clientService)
        {
            if (clientService == null)
                throw new ArgumentNullException(nameof(clientService));

            _clientService = clientService;
        }

        public DeliveryInfoVM GetPartOfDeliveryInformation()
        {
            var orderDeliver = new DeliveryInfoVM();
            
            Guid clientId = Guid.Empty;
            var client = _clientService.GetClientById(clientId);
            if (client != null)
            {
                orderDeliver.ClientName = client.GetFullName();
                orderDeliver.ClientPhoneNumber = client.Person.PhoneNumber;
            }

            return orderDeliver;
        }
    }
}