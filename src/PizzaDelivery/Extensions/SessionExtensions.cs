using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace PizzaDelivery.Extensions
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            var stringValue = JsonConvert.SerializeObject(value);
            var array = Encoding.UTF8.GetBytes(stringValue);
            session.Set(key, array);
        }

        public static T Get<T>(this ISession session, string key) where T : class, new()
        {
            if (!session.TryGetValue(key, out var array))
            {
                var obj = new T();
                session.Set<T>(key, obj);
                return obj;
            }

            var stringValue = Encoding.UTF8.GetString(array);
            return JsonConvert.DeserializeObject<T>(stringValue);
        }

        public static Guid GetId(this ClaimsPrincipal user)
        {
            var sid = user.Identities
                .First(x => x.AuthenticationType == "MyCookieMiddlewareInstance")
                .Claims.First(x => x.Type == ClaimTypes.Sid)
                .Value;
            var userId = Guid.Parse(sid);

            return userId;
        }
    }
}
