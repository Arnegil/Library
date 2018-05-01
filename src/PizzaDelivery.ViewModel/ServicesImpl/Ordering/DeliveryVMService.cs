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

        public DeliveryInfoVM GetPartOfDeliveryInformation(string login)
        {
            var orderDeliver = new DeliveryInfoVM();
            
            var client = _clientService.GetClientByLogin(login);
            if (client != null)
            {
                orderDeliver.ClientName = client.GetFullName();
                orderDeliver.ClientPhoneNumber = client.Person.PhoneNumber;
                orderDeliver.DeliveryAddress = client.Person.Address;
            }

            return orderDeliver;
        }
    }
}