using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery
{
    public static class SecurityRoles
    {
        public static string Client { get; } = "client";
        public static string Operator { get; } = "operator";
        public static string Deliveryman { get; } = "deliveryman";
        public static string Admin { get; } = "admin";
        public static string Developer { get; } = "developer";
    }
}
