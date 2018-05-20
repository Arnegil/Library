using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaDelivery.Domain.Models;
using PizzaDelivery.Domain.Models.Orders;
using PizzaDelivery.Domain.Models.Persons;

namespace PizzaDelivery.Domain
{
    internal class DBInitializer
    {
        private static bool _isInit = false;

        public static void Initialize(PizzaDeliveryDBContext context)
        {
            if (!_isInit)
            {
                InitPizzas(context);
                InitClients(context);
                InitEmployees(context);
                InitAdmins(context);
                context.SaveChanges();
                InitOrders(context);
                context.SaveChanges();
                _isInit = true;
            }
        }

        private static void InitPizzas(PizzaDeliveryDBContext context)
        {
            context.Add(new Pizza()
            {
                Id = Guid.Parse("00000000-0000-1111-0000-000000000001"),
                Name = "Барбекю",
                Recipe = "Пицца с ветчиной, беконом, пепперони, болгарским перцем и томатным соусом для ценителей мясных деликатесов",
                Cost = 410
            });
            context.Add(new Pizza()
            {
                Id = Guid.Parse("00000000-0000-1111-0000-000000000002"),
                Name = "Гавайская",
                Recipe = "Волшебное сочетание нежного куриного мяса, ананасов и спелой груши.",
                Cost = 335
            });
            context.Add(new Pizza()
            {
                Id = Guid.Parse("00000000-0000-1111-0000-000000000003"),
                Name = "Карбонара",
                Recipe = "Итальянский колорит бекона, сыра, грибов и красного лука",
                Cost = 340
            });
            context.Add(new Pizza()
            {
                Id = Guid.Parse("00000000-0000-1111-0000-000000000004"),
                Name = "Маргарита",
                Recipe = "Пицца с классическим сочетанием томатов и сыра",
                Cost = 255
            });
            context.Add(new Pizza()
            {
                Id = Guid.Parse("00000000-0000-1111-0000-000000000005"),
                Name = "Мексиканская",
                Recipe = "Острая мексиканская пицца с куриной грудкой, кукурузой, сыром, вялеными томатами и перчиком халапеньо",
                Cost = 330
            });
            context.Add(new Pizza()
            {
                Id = Guid.Parse("00000000-0000-1111-0000-000000000006"),
                Name = "Филадельфия",
                Recipe = "Лосось,сливочный сыр,икра.",
                Cost = 600
            });
        }

        private static void InitClients(PizzaDeliveryDBContext context)
        {
            context.Add(new Client()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Person = new Person
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                    FIO = "Alexander",
                    Birthday = new DateTime(1990, 3, 13),
                    Email = "email1@mail.ru",
                    PhoneNumber = "+7(123) 123-1231",
                    Address = "Street 21"
                },
                Account = new Account
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                    Login = "client1",
                    Password = @" ,�b�Y[�K-#Kp",
                    Type = AccountType.Client
                },
                BonusCount = 10
            });
        }

        private static void InitEmployees(PizzaDeliveryDBContext context)
        {
            context.Add(new Employee()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                Person = new Person
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    FIO = "Vladislav",
                    Birthday = new DateTime(1995, 5, 13),
                    Email = "email3@mail.ru",
                    PhoneNumber = "563-23-32"
                },
                Account = new Account
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    Login = "operator1",
                    Password = @" ,�b�Y[�K-#Kp",
                    Type = AccountType.Employee
                },
                HireDate = new DateTime(2010, 2, 1),
                PostName = PostNames.Operator
            });
            context.Add(new Employee()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                Person = new Person
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                    FIO = "Alexander",
                    Birthday = new DateTime(1998, 1, 9),
                    Email = "email4@mail.ru",
                    PhoneNumber = "123-54-65"
                },
                Account = new Account
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                    Login = "deliveryman1",
                    Password = @" ,�b�Y[�K-#Kp",
                    Type = AccountType.Employee
                },
                HireDate = new DateTime(2012, 12, 1),
                PostName = PostNames.Deliveryman
            });
        }

        private static void InitAdmins(PizzaDeliveryDBContext context)
        {
            context.Add(new Employee()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                Person = new Person
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000020"),
                    FIO = "Ivan Ivanovich",
                    Birthday = new DateTime(1991, 1, 19),
                    Email = "adminsaita@mail.ru",
                    PhoneNumber = "555-35-35"
                },
                Account = new Account
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000030"),
                    Login = "Admin1",
                    Password = @" ,�b�Y[�K-#Kp",
                    Type = AccountType.Admin
                },
                HireDate = new DateTime(2010, 2, 1),
                PostName = PostNames.Admin
            });
        }

        private static void InitOrders(PizzaDeliveryDBContext context)
        {
            var order1 = new Order()
            {
                Id = Guid.Parse("00000000-0000-2222-0000-000000000001"),
                OrderingClient = context.Clients.First(x => x.Id == Guid.Parse("00000000-0000-0000-0000-000000000001")),
                CommentToOperator = "comment to operator",
                CreationDate = DateTime.Parse("01.05.2018"),
                OrderNumber = 1,
                OrderState = OrderState.Created,
                DeliveryInfo = new DeliveryInfo
                {
                    Id = Guid.Parse("00000000-0000-3333-0000-000000000001"),
                    DeliveryAddress = "Street 123",
                    ClientName = "Client1",
                    ClientPhoneNumber = "3123123123"
                },
                PaymentInfo = new PaymentInfo
                {
                    Id = Guid.Parse("00000000-0000-4444-0000-000000000001"),
                    CardOwnerName = "Name",
                    CardNumber = "123123",
                    DateTo = DateTime.Parse("01.02.2018")
                }
            };
            context.Add(order1);

            context.OrderPositions.Add(new OrderPosition()
            {
                Id = Guid.Parse("00000000-0000-5555-0000-000000000001"),
                Pizza = context.Pizzas.First(x => x.Id == Guid.Parse("00000000-0000-1111-0000-000000000001")),
                Count = 3,
                Order = order1
            });

            var order2 = new Order()
            {
                Id = Guid.Parse("00000000-0000-2222-0000-000000000002"),
                OrderingClient = context.Clients.First(x => x.Id == Guid.Parse("00000000-0000-0000-0000-000000000001")),
                CommentToOperator = "comment to operator",
                CreationDate = DateTime.Parse("02.05.2018"),
                OrderNumber = 2,
                OrderState = OrderState.WaitingForDeliveryman,
                DeliveryInfo = new DeliveryInfo
                {
                    Id = Guid.Parse("00000000-0000-3333-0000-000000000002"),
                    DeliveryAddress = "Street 123",
                    ClientName = "Client1",
                    ClientPhoneNumber = "3123123123"
                },
                PaymentInfo = new PaymentInfo
                {
                    Id = Guid.Parse("00000000-0000-4444-0000-000000000002"),
                    CardOwnerName = "Name",
                    CardNumber = "123123",
                    DateTo = DateTime.Parse("01.02.2018")
                },
                Operator = context.Employees.First(x => x.Id == Guid.Parse("00000000-0000-0000-0000-000000000007"))
            };
            context.Add(order2);

            context.OrderPositions.Add(new OrderPosition()
            {
                Id = Guid.Parse("00000000-0000-5555-0000-000000000002"),
                Pizza = context.Pizzas.First(x => x.Id == Guid.Parse("00000000-0000-1111-0000-000000000001")),
                Count = 2,
                Order = order2
            });
            context.OrderPositions.Add(new OrderPosition()
            {
                Id = Guid.Parse("00000000-0000-5555-0000-000000000003"),
                Pizza = context.Pizzas.First(x => x.Id == Guid.Parse("00000000-0000-1111-0000-000000000002")),
                Count = 2,
                Order = order2
            });
            
            var order3 = new Order()
            {
                Id = Guid.Parse("00000000-0000-2222-0000-000000000003"),
                OrderingClient = context.Clients.First(x => x.Id == Guid.Parse("00000000-0000-0000-0000-000000000001")),
                CommentToOperator = "comment to operator",
                CreationDate = DateTime.Parse("04.05.2018"),
                OrderNumber = 3,
                OrderState = OrderState.Paid,
                DeliveryInfo = new DeliveryInfo
                {
                    Id = Guid.Parse("00000000-0000-3333-0000-000000000003"),
                    DeliveryAddress = "Street 123",
                    ClientName = "Client1",
                    ClientPhoneNumber = "3123123123"
                },
                PaymentInfo = new PaymentInfo
                {
                    Id = Guid.Parse("00000000-0000-4444-0000-000000000003"),
                    CardOwnerName = "Name",
                    CardNumber = "123123",
                    DateTo = DateTime.Parse("01.02.2018")
                },
                Operator = context.Employees.First(x => x.Id == Guid.Parse("00000000-0000-0000-0000-000000000007"))
            };
            context.Add(order3);

            context.OrderPositions.Add(new OrderPosition()
            {
                Id = Guid.Parse("00000000-0000-5555-0000-000000000004"),
                Pizza = context.Pizzas.First(x => x.Id == Guid.Parse("00000000-0000-1111-0000-000000000003")),
                Count = 3,
                Order = order3
            });
            context.OrderPositions.Add(new OrderPosition()
            {
                Id = Guid.Parse("00000000-0000-5555-0000-000000000005"),
                Pizza = context.Pizzas.First(x => x.Id == Guid.Parse("00000000-0000-1111-0000-000000000001")),
                Count = 2,
                Order = order3
            });

            /*var order4 = new Order()
            {
                Id = Guid.Parse("00000000-0000-2222-0000-000000000004"),
                OrderingClient = context.Clients.First(x => x.Id == Guid.Parse("00000000-0000-0000-0000-000000000001")),
                CommentToOperator = "comment to operator",
                CommentToDeliveryman = "comment to deliveryman",
                CreationDate = DateTime.Parse("05.05.2018"),
                OrderNumber = 4,
                OrderState = OrderState.Cooking,
                DeliveryInfo = new DeliveryInfo
                {
                    Id = Guid.Parse("00000000-0000-3333-0000-000000000005"),
                    DeliveryAddress = "Street 123",
                    ClientName = "Client1",
                    ClientPhoneNumber = "3123123123"
                },
                PaymentInfo = new PaymentInfo
                {
                    Id = Guid.Parse("00000000-0000-4444-0000-000000000005"),
                    CardOwnerName = "Name",
                    CardNumber = "123123",
                    DateTo = DateTime.Parse("01.02.2018")
                },
                UpdateDate = DateTime.Parse("05.05.2018"),
                Operator = context.Employees.First(x => x.Id == Guid.Parse("00000000-0000-0000-0000-000000000007"))
            };
            context.Add(order4);

            context.OrderPositions.Add(new OrderPosition()
            {
                Id = Guid.Parse("00000000-0000-5555-0000-000000000006"),
                Pizza = context.Pizzas.First(x => x.Id == Guid.Parse("00000000-0000-1111-0000-000000000001")),
                Count = 3,
                Order = order4
            });
            context.OrderPositions.Add(new OrderPosition()
            {
                Id = Guid.Parse("00000000-0000-5555-0000-000000000007"),
                Pizza = context.Pizzas.First(x => x.Id == Guid.Parse("00000000-0000-1111-0000-000000000002")),
                Count = 2,
                Order = order4
            });*/
        }
    }
}
