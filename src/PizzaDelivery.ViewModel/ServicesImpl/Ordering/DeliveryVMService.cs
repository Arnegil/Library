using System;
using PizzaDelivery.Services.Extensions;
using PizzaDelivery.Services.Interfaces;
using PizzaDelivery.ViewModel.Interfaces.Ordering;
using PizzaDelivery.ViewModel.ViewModels.Ordering;

namespace PizzaDelivery.ViewModel.ServicesImpl.Ordering
{
    public class DeliveryVMService : IDeliveryVMService
    {
        private readonly Cache _cache;
        private readonly IClientService _clientService;
        
        public DeliveryVMService(IClientService clientService, Cache cache)
        {
            if (clientService == null)
                throw new ArgumentNullException(nameof(clientService));

            _clientService = clientService;
            _cache = cache;
        }

        public DeliveryInfoVM GetDeliveryInformation()
        {
            var orderDeliver = _cache.OderDeliveryInfoOfCurrentUser;

            if (orderDeliver.IsEmpty)
            {
                Guid clientId = Guid.Empty;
                var client = _clientService.GetClientById(clientId);
                if (client != null)
                {
                    orderDeliver.ClientName = client.GetFullName();
                    orderDeliver.ClientPhoneNumber = client.Person.PhoneNumber;
                }
            }

            return orderDeliver;
        }

        public void SaveDeliveryInfo(DeliveryInfoVM deliveryInfo)
        {
            _cache.OderDeliveryInfoOfCurrentUser.ClientName = deliveryInfo.ClientName;
            _cache.OderDeliveryInfoOfCurrentUser.ClientPhoneNumber = deliveryInfo.ClientPhoneNumber;
            _cache.OderDeliveryInfoOfCurrentUser.DeliveryAddress = deliveryInfo.DeliveryAddress;
            _cache.OderDeliveryInfoOfCurrentUser.ShipmenAtOwnExpense = deliveryInfo.ShipmenAtOwnExpense;
        }
    }
}